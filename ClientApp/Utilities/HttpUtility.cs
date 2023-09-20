﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClientApp.Utilities
{
    internal class HttpUtility
    {
        private readonly HttpClient _httpClient;

        public HttpUtility()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7272/");

            // Autorizacijai ateityje
            // _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "YourAccessToken");
        }

        public async Task<T> GetAsync<T>(string endpoint)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                var deserializedObject = await response.Content.ReadFromJsonAsync<T>();
                if (deserializedObject != null)
                {
                    return deserializedObject;
                }
                else
                {
                    throw new HttpRequestException("Received empty JSON from HTTP request.");
                }
            }
            else
            {
                throw new HttpRequestException($"HTTP request failed with status code {response.StatusCode}");
            }
        }

        public async Task<T> PostAsync<T>(string endpoint, T data)
        {
            var jsonData = JsonSerializer.Serialize(data);
            var contentData = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync(endpoint, contentData);

            if (response.IsSuccessStatusCode)
            {
                var deserializedObject = await response.Content.ReadFromJsonAsync<T>();
                if (deserializedObject != null)
                {
                    return deserializedObject;
                }
                else
                {
                    throw new HttpRequestException("Received empty JSON from HTTP request.");
                }
            }
            else
            {
                throw new HttpRequestException($"HTTP request failed with status code {response.StatusCode}");
            }
        }

        public T Post<T>(string endpoint)
        {
            HttpResponseMessage response = _httpClient.PostAsync(endpoint, null).Result;

            if (response.IsSuccessStatusCode)
            {
                var deserializedObject = response.Content.ReadFromJsonAsync<T>().Result;
                if (deserializedObject != null)
                {
                    return deserializedObject;
                }
                else
                {
                    throw new HttpRequestException("Received empty JSON from HTTP request.");
                }
            }
            else
            {
                throw new HttpRequestException($"HTTP request failed with status code {response.StatusCode}");
            }
        }
    }
}
