using SharedLibrary.Interfaces;
using SharedLibrary.Models;
using SharedLibrary.Models.Decorators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApp.Forms
{
    public partial class DecorationsForm : Form
    {
        private IShip _selectedShip;

        public DecorationsForm(IShip ship)
        {
            InitializeComponent();

            _selectedShip = ship;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _selectedShip = new DamageDecorator(_selectedShip);
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _selectedShip = new StealthDecorator(_selectedShip);
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _selectedShip = new ArmorDecorator(_selectedShip);
            Hide();
        }
    }
}
