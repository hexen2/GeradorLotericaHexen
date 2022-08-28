using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorLotericaHexen
{
    class ArraySalvarEscolhas
    {
        int[,] ArraySalvarEscolhasC = new int[0,15];
        private int TAMANHO = 0;
        public int Tamanho
        {
            get
            {
                return this.TAMANHO;

            }
            set
            {
                this.TAMANHO = value;
            }
        }

        public void ArrayCTamanho(int Tamanho)
        {
            ArraySalvarEscolhasC = new int[Tamanho, 15];
        }
        public string ArrayCTamanho()
        {
            return ArraySalvarEscolhasC.GetLength(0).ToString();
        }
        public string ArraySalvarEscolhasTamanhoQuantidade()
        {
            return ArraySalvarEscolhasC.Length.ToString();
        }
        public int ArrayLC(int linha, int coluna)
        {
            return ArraySalvarEscolhasC[linha, coluna];
        }
        public void ArrayAdcionarLC(int linha, int coluna,int entrada)
        {
            ArraySalvarEscolhasC[linha, coluna]= entrada;
        }
    }
}
