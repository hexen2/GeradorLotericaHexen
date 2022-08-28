using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorLotericaHexen
{
    class JogosIndependencia
    {
        private int LINHA2 = 0;
        public int linha2
        {
            get
            {
                return this.LINHA2;

            }
            set
            {
                this.LINHA2 = value;
            }
        }
        private int LINHA3 = 0;
        public int linha3
        {
            get
            {
                return this.LINHA3;

            }
            set
            {
                this.LINHA3 = value;
            }
        }
        //Jogos da Lotérica
        private int[,] array = new int[,] {
//Carlos
/* 1 */{1,4,5,6,8,10,11,12,13,17,18,20,23,24,25},

        };
           
        public string ArrayTamanho()
        {
            return array.GetLength(0).ToString();
        }
        public int ArrayL(int linha, int coluna)
        {
            return array[linha, coluna];
        }
    }
}
