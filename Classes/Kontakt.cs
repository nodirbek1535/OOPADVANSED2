using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace KONTAKT.Classes
{
    class Kontakt
    {
        public string Name{ get ; set ;}
        public string Phonenumber{get ; set ;}

        public Kontakt(string name,string phonenumber)
        {
            Name=name;
            Phonenumber=phonenumber;
        }
        public override string ToString()
        {
            return $"{Name}: {Phonenumber}";
        }



        string filepath="D:\\input.txt";
        public List<Kontakt> Loadfiles()
        {
          
            List<Kontakt> kontakts=new List<Kontakt>();
            using(StreamReader reader=new StreamReader(filepath))
            {
                string line;
                while((line=reader.ReadLine())!=null)
                {
                    string[] parts=line.Split(' ');
                    if(parts.Length>=2)
                    {
                        string name=parts[0].Trim();
                        string phonenumber=parts[1].Trim();
                        kontakts.Add(new Kontakt(name,phonenumber));
                    }
                }
            }
            return kontakts;
        }


        public int buyruqlar()
        {
            Console.WriteLine("Kontaktlarni kormoqchi bolsangiz 1 ni kiriting");
            Console.WriteLine("kontaktlarni alifbo tartibida tartiblamoqchi4 bolsangiz 2 ni kiriting");
            Console.WriteLine("kontaktlarni tahrirlash uchun 3 ni kiriting");
            Console.WriteLine("chiqish uchun 4 ni kiriting");
            int a=int.Parse(Console.ReadLine());
            return a;
        }

        public void royxatnikorish(List<Kontakt> kontakts)
        {
            foreach(var k in kontakts)
            {
                Console.WriteLine(k.ToString());
            }
        }


        public void tartiblash(List<Kontakt> kontakts1 )
        {
            kontakts1.Sort((x,y)=>x.Name.CompareTo(y.Name));
        } 

        public void tahrirlash(List<Kontakt> kontakts1)
        {
            Console.WriteLine("tahrirlamoqchi bolgan kontakt ismini kiriting");
            string name=Console.ReadLine();
            Kontakt foundContact = kontakts1.Find(k => k.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if(foundContact!=null)
            {
                Console.WriteLine("Kontak topildi siz uni ismini ozgartirmoqchi bolsangiz 1ni kiriting");
                Console.WriteLine("raqamini ozgartirmoqchi bolsangiz 2 ni kiriting");
                Console.WriteLine("agar toliq tahrirlamoqchi bolsangiz 3 ni kiriting");
                int we=int.Parse(Console.ReadLine());
                switch(we)
                {
                    case 1:
                        Console.WriteLine("yangi ismni kiriting:");
                        string newname=Console.ReadLine();
                        foundContact.Name=newname;
                        Console.WriteLine("kontakt ozgartirildi");
                    break;

                    case 2:
                        Console.WriteLine("yangi raqamni kiriting:");
                        string newphonenumber=Console.ReadLine();
                        foundContact.Phonenumber=newphonenumber;
                    break;

                    case 3:
                        Console.WriteLine("yangi ismni kiriting:");
                        string newnamee=Console.ReadLine();
                        Console.WriteLine("yangi raqamni kiriting:");
                        string newnumber=Console.ReadLine();
                        foundContact.Name=newnamee;
                        foundContact.Phonenumber=newnumber;
                        Console.WriteLine("kontakt ozgartirildi");
                    break;
                }
            }
        }



        public void saqlash(List<Kontakt> kontakts1)
        {
            Console.WriteLine("ozgartirishlarni faylgaa saqlaysizmi?(ha yoki yoq)");
            string buyruq=Console.ReadLine();
            if(buyruq=="ha")
            {
                using(StreamWriter writer=new StreamWriter(filepath))
                {
                    foreach(var k in kontakts1)
                    {
                        writer.WriteLine($"{k.Name} {k.Phonenumber}");
                    }
                }
            }
        }
    }

}