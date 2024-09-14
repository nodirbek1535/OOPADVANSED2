using KONTAKT.Classes;

Console.WriteLine("Salom bu  OOPADVANSED bolimi uchun 2-vazifa");
Console.WriteLine("Ushbu dastur kontaktlar boyicha ishhlaydigan dastur siz ushbu dasturda yangi kontakt yaaratishingiz kontaktni ochirishingiz uni tahrirlashingi mumkin");
Kontakt kontakt=new Kontakt("hvvgt", "hibihyhb");
List<Kontakt> kontakts=kontakt.Loadfiles();
bool all=true;
while(all)
{
    int a=kontakt.buyruqlar();
    switch (a)
    {
        case 1:
            kontakt.royxatnikorish(kontakts);
        break;

        case 2:
            kontakt.tartiblash(kontakts);
            kontakt.saqlash(kontakts);
        break;

        case 3:
            kontakt.tahrirlash(kontakts);
            kontakt.saqlash(kontakts);
        break;
       
        case 4:
        all=false;
        break;
    }
}