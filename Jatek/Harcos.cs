using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace Jatek
{
    class Harcos
    {
        string nev;
        int szint;
        int tapasztalat;
        int eletero;
        int alapEletero;
        int alapSebzes;

        public Harcos(string nev,int statuszSablon) 
        {
            this.Nev = nev;
            szint = 1;
            tapasztalat = 0;
            if (statuszSablon == 1)
            {
                alapEletero = 15;
                alapSebzes = 3;
            }
            else if (statuszSablon == 2)
            {
                alapEletero = 12;
                alapSebzes = 4;
            }
            else if (statuszSablon == 3)
            {
                alapEletero = 8;
                alapSebzes = 5;
            }
            eletero = MaxEletero;
        }

        public string Nev { get => nev; set => nev = value; }
        public int Szint { get => szint; set => szint = value; }
        public int Tapasztalat { get => tapasztalat; set => tapasztalat = value; }
        public int Eletero { get => eletero; set => eletero = value; }
        public int AlapEletero { get => alapEletero;  }
        public int AlapSebzes { get => alapSebzes;  }
        public int Sebzes { get => AlapSebzes + szint;  }
        public int Szintlepes { get => 10 + szint*5 ; }
        public int MaxEletero { get => alapEletero+ szint*3; }
        public void Megkuzd(Harcos masikHarcos) 
        {
            if (masikHarcos == this)
            {

            }
            if (masikHarcos.eletero == 0 || this.eletero == 0)
            {
                Console.WriteLine("Hiba");
            }
            else
            {
                masikHarcos.eletero -= this.Sebzes;
            }
            if (masikHarcos.eletero > 0)
            {
                this.eletero -= masikHarcos.Sebzes;
            }
            if (masikHarcos.eletero >0 )
            {
                masikHarcos.tapasztalat += 5;
            }
            if (this.eletero > 0)
            {
                this.tapasztalat += 5;
            }
            if (this.eletero < 0 || masikHarcos.eletero < 0 )
            {
                if (this.eletero>0)
                {
                    this.tapasztalat += 10;
                }
                else if (masikHarcos.eletero > 0)
                {
                    masikHarcos.tapasztalat += 10;
                }
            }
            
        }
        public void Gyogyul() 
        {
            
        }
        public override string ToString()
        {
            return string.Format("{0} - LVL:{1} - EXP:{2}/{3} - HP:{4}/{5} - DMG:{6}", this.nev, this.szint, this.tapasztalat, this.Szintlepes, this.eletero, this.MaxEletero, this.Sebzes);
        }
    }
}
