Žaidimas skirtas dviem žaidėjams. Jame bus keturi lygiai, prie kurių galima prieiti bet kokia norima tvarka:
- Basic: nėra specialių taisyklių, reikia atspėti kur priešininkas padėjo laivus;
- Enhanced: atsiranda galimybė pakeisti dviejų laivų poziciją viduryje žaidimo;
- Advanced: yra įvairūs laivų tipai su skirtingomis gyvybėmis;
- Expert: leidžiama padėti radarus, kurie praneša apie pastatytus arba perkeltus laivus tam tikroje dalyje žemėlapio.

Objektų tipai:
- Laivai
- Sesija
- Jūra
- Radarai
- Ginklai

Technologinei implementacijai kliento pusėje bus naudojamas WinForm (Windows Forms .NET) vaizdinės sąsajos karkasas. Veiksmas vyks paeliui (angl. turn-based), kurį valdo serveris naudojantis RESTful API metodus. Žaidimas 2D grafikai naudos System.Drawing biblioteką.