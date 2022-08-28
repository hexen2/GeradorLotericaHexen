using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.InteropServices;
using System.Data.Common;
using System.Threading;
using ClosedXML.Excel;


namespace GeradorLotericaHexen
{
    public partial class TelaPrincipal : Form
    {
        //RESULTADO E SOBRA
        int[] ArrayResultadoJogos = new int[15];
        int[] ArrayResultadoSobra = new int[10];

        //LISTA DE JOGOS SALVOS SEGUNDA TELA
        List<int> ListaCombinacoesSalvos = new List<int>();

        int[] ArrayNumerosMagicos =  {5,6,7,12,13,14,19,20,21 };
        //Lista de elementos
        List<int> ListaCombinacoes = new List<int>();

        //Lista os elementos selecionados Ativos
        List<int> NumerosListaCombinar = new List<int>();

        //Lista Todos os Selecionado
        List<int> ListaTodosSelecionados = new List<int>();

        //Lista de elementos Criar e Sobra
        List<int> ElementosListaCriar = new List<int>();
        List<int> ElementosListaSobra = new List<int>();
        List<int> ElementosListaRepetidos = new List<int>();
        //Lista de Numeros Random Mega Sena
        List<int> ElementoslistaNumberMegas = new List<int>();
        
        //Lista de valores

        private int QuantNumerosInicio = 0;//3
        private int[] ElementosCombinacoes = new int[14];

        private int[,] ArrayJogosCombinacao = new int[30, 15];

        private int quantidade = 0;
        private int count = 1;//Inicio do Array posição
        private int BuscaLouC = 0;

        //Tela secundaria
        int[,] ArraySelecionado = new int[0, 16];
        int[,] ArraySalvarEscolhas = new int[0, 15];

        int[] ArrayRepetidos = new int[0];


        //int elementos = 15;
        //private int QuantidadeNumeros = 0;
        public FormSecundaria TelaSecundaria;

        //Resultados da LotoFacil
        ResultadosLotofacil arrays = new ResultadosLotofacil();
        //Jogos Grupo Independencia
        //JogosIndependencia arraysIndependencia = new JogosIndependencia();      

        ArraySalvarEscolhas Jogos = new ArraySalvarEscolhas();


        private int NUMEROLOJOGOS = 0;
        public int NumeroJogos
        {
            get
            {
                return this.NUMEROLOJOGOS;

            }
            set
            {
                this.NUMEROLOJOGOS = value;
            }
        }
        private int COMBINACAOPARESINDEX = 0;
        public int CombinacaoParesImparIndex
        {
            get
            {
                return this.COMBINACAOPARESINDEX;

            }
            set
            {
                this.COMBINACAOPARESINDEX = value;
            }
        }
        private int NUMEROREPETIDAS = 0;
        public int NumeroRepetidas
        {
            get
            {
                return this.NUMEROREPETIDAS;

            }
            set
            {
                this.NUMEROREPETIDAS = value;
            }
        }
        private int NUMEROMODULA = 0;
        public int NumeroModula
        {
            get
            {
                return this.NUMEROMODULA;

            }
            set
            {
                this.NUMEROMODULA = value;
            }
        }
        private int NUMEROPRIMOS = 0;
        public int NumeroPrimos
        {
            get
            {
                return this.NUMEROPRIMOS;

            }
            set
            {
                this.NUMEROPRIMOS = value;
            }
        }
        private int NUMEROFIBONACCI = 0;
        public int NumeroFibonacci
        {
            get
            {
                return this.NUMEROFIBONACCI;

            }
            set
            {
                this.NUMEROFIBONACCI = value;
            }
        }
        private int NUMEROMULTIPLODE3 = 0;
        public int NumeroMultiploDe3
        {
            get
            {
                return this.NUMEROMULTIPLODE3;

            }
            set
            {
                this.NUMEROMULTIPLODE3 = value;
            }
        }
        private int MININO_ELEMENTO = 0;
        public int MinimoElemento
        {
            get
            {
                return this.MININO_ELEMENTO;

            }
            set
            {
                this.MININO_ELEMENTO = value;
            }
        }
        private int MAXIMO_ELEMENTO = 0;
        public int maximoElemento
        {
            get
            {
                return this.MAXIMO_ELEMENTO;

            }
            set
            {
                this.MAXIMO_ELEMENTO = value;
            }
        }
        private int CONT_BUSCA = 0;
        public int ContBusca
        {
            get
            {
                return this.CONT_BUSCA;

            }
            set
            {
                this.CONT_BUSCA = value;
            }
        }
        private int CONT_BUSCA2 = 0;
        public int ContBusca2
        {
            get
            {
                return this.CONT_BUSCA2;

            }
            set
            {
                this.CONT_BUSCA2 = value;
            }
        }
        private int Entrada_NUMERO_MAGICO = 0;
        public int EntradaNumeroMagico
        {
            get
            {
                return this.Entrada_NUMERO_MAGICO;

            }
            set
            {
                this.Entrada_NUMERO_MAGICO = value;
            }
        }

        public TelaPrincipal()
        {
            InitializeComponent();

            label5.Text = "MOLDURA      = 1,2,3,4,5,6,10,11,15,16,20,21,22,23,24,25";
            label6.Text = "N.PRIMOS     = 2,3,5,7,11,13,17,19,23";
            label7.Text = "N.FIBONACCI  = 1,2,3,5,8,13,21";
            label8.Text = "N.MULTIPLO 3 = 3,6,9,12,15,18,21,24";
            label44.Text = "N.MÁGICOS = 5,6,7,12,13,14,19,20,21";

            //JogosLotoFacil();
            DezenasParesImpares();
            comboBoxParImpar.SelectedIndex = 0;
            NumerosRepetidas();
            comboBoxNumeroRepetidas.SelectedIndex = 0;
            NumerosMoldura();
            comboBoxMoldura.SelectedIndex = 0;
            NumerosPrimos();
            comboBoxPrimos.SelectedIndex = 0;
            NumerosFibonacci();
            comboBoxFibonacci.SelectedIndex = 0;
            NumerosMultiploDe3();
            comboBoxMultiploDe3.SelectedIndex = 0;
            
            dataGridViewSelecionado.Rows.Add("","", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
            dataGridViewCombinacoesEscolhidas.Rows.Add("","", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");            
        }
        public string VerificarTamanho() 
        {
            return Jogos.ArrayCTamanho();
        }


        public void InstaciaArray  (int Tamanho )
        {
            Jogos.ArrayCTamanho(Tamanho);
        }
        public void Salvar(int linha, int n1, int n2, int n3, int n4, int n5, int n6, int n7,
                      int n8, int n9, int n10, int n11, int n12, int n13, int n14, int n15)
        {
            Jogos.ArrayAdcionarLC(linha, 0, n1);
            Jogos.ArrayAdcionarLC(linha, 1, n2);
            Jogos.ArrayAdcionarLC(linha, 2, n3);
            Jogos.ArrayAdcionarLC(linha, 3, n4);
            Jogos.ArrayAdcionarLC(linha, 4, n5);
            Jogos.ArrayAdcionarLC(linha, 5, n6);
            Jogos.ArrayAdcionarLC(linha, 6, n7);
            Jogos.ArrayAdcionarLC(linha, 7, n8);
            Jogos.ArrayAdcionarLC(linha, 8, n9);
            Jogos.ArrayAdcionarLC(linha, 9, n10);
            Jogos.ArrayAdcionarLC(linha, 10, n11);
            Jogos.ArrayAdcionarLC(linha, 11, n12);
            Jogos.ArrayAdcionarLC(linha, 12, n13);
            Jogos.ArrayAdcionarLC(linha, 13, n14);
            Jogos.ArrayAdcionarLC(linha, 14, n15);
        }
        public int Armazanados(int linha,int coluna)
        {
            int Numero = Jogos.ArrayLC(linha, coluna);

            return Numero;
        }
        public void JogosPrint()
        {
            string numero = "";
            for (int coluna = 0; coluna < 15; coluna++)
            {
                if (coluna < 14)
                {
                    numero = numero + Jogos.ArrayLC(0, coluna) + ", ";
                }
                if (coluna == 14)
                {
                    numero = numero + Jogos.ArrayLC(0, coluna) + ".";
                }
            }
            Console.WriteLine(" JOGO " + 0 + " os números são: " + numero + ".");

        }
        public void DezenasParesImpares()
        {
            try
            {
                comboBoxParImpar.Items.Add("SELECIONAR CALC");
                comboBoxParImpar.Items.Add("7 PAR e 8 IMPAR");
                comboBoxParImpar.Items.Add("8 PAR e 7 IMPAR");
                comboBoxParImpar.Items.Add("6 PAR e 9 IMPAR");
                comboBoxParImpar.Items.Add("9 PAR e 6 IMPAR");
                comboBoxParImpar.Items.Add("5 PAR e 10 IMPAR");
                comboBoxParImpar.Items.Add("10 PAR e 5 IMPAR");
                comboBoxParImpar.Items.Add("4 PAR e 11 IMPAR");
                comboBoxParImpar.Items.Add("11 PAR e 4 IMPAR");
                comboBoxParImpar.Items.Add("3 PAR e 12 IMPAR");
                comboBoxParImpar.Items.Add("12 PAR e 3 IMPAR");
                comboBoxParImpar.Items.Add("2 PAR e 13 IMPAR");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void NumerosRepetidas()
        {
            try
            {
                comboBoxNumeroRepetidas.Items.Add("SELECIONAR CALC");
                comboBoxNumeroRepetidas.Items.Add("9");
                comboBoxNumeroRepetidas.Items.Add("8");
                comboBoxNumeroRepetidas.Items.Add("10");
                comboBoxNumeroRepetidas.Items.Add("7");
                comboBoxNumeroRepetidas.Items.Add("11");
                comboBoxNumeroRepetidas.Items.Add("12");
                comboBoxNumeroRepetidas.Items.Add("6");
                comboBoxNumeroRepetidas.Items.Add("13");
                comboBoxNumeroRepetidas.Items.Add("14");
                comboBoxNumeroRepetidas.Items.Add("5");
                comboBoxNumeroRepetidas.Items.Add("0");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void NumerosMoldura()
        {
            try
            {
                comboBoxMoldura.Items.Add("SELECIONAR CALC");
                comboBoxMoldura.Items.Add("10");
                comboBoxMoldura.Items.Add("9");
                comboBoxMoldura.Items.Add("11");
                comboBoxMoldura.Items.Add("8");
                comboBoxMoldura.Items.Add("12");
                comboBoxMoldura.Items.Add("7");
                comboBoxMoldura.Items.Add("13");
                comboBoxMoldura.Items.Add("6");
                comboBoxMoldura.Items.Add("14");
                comboBoxMoldura.Items.Add("15");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void NumerosPrimos()
        {
            try
            {
                comboBoxPrimos.Items.Add("SELECIONAR CALC");
                comboBoxPrimos.Items.Add("5");
                comboBoxPrimos.Items.Add("6");
                comboBoxPrimos.Items.Add("4");
                comboBoxPrimos.Items.Add("7");
                comboBoxPrimos.Items.Add("3");
                comboBoxPrimos.Items.Add("8");
                comboBoxPrimos.Items.Add("2");
                comboBoxPrimos.Items.Add("9");
                comboBoxPrimos.Items.Add("1");
                comboBoxPrimos.Items.Add("0");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void NumerosFibonacci()
        {
            try
            {
                comboBoxFibonacci.Items.Add("SELECIONAR CALC");
                comboBoxFibonacci.Items.Add("4");
                comboBoxFibonacci.Items.Add("5");
                comboBoxFibonacci.Items.Add("3");
                comboBoxFibonacci.Items.Add("6");
                comboBoxFibonacci.Items.Add("2");
                comboBoxFibonacci.Items.Add("7");
                comboBoxFibonacci.Items.Add("1");
                comboBoxFibonacci.Items.Add("0");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void NumerosMultiploDe3()
        {
            try
            {
                comboBoxMultiploDe3.Items.Add("SELECIONAR CALC");
                comboBoxMultiploDe3.Items.Add("5");
                comboBoxMultiploDe3.Items.Add("4");
                comboBoxMultiploDe3.Items.Add("6");
                comboBoxMultiploDe3.Items.Add("3");
                comboBoxMultiploDe3.Items.Add("7");
                comboBoxMultiploDe3.Items.Add("2");
                comboBoxMultiploDe3.Items.Add("8");
                comboBoxMultiploDe3.Items.Add("1");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void NumerosTexto()
        {
            textBoxCriaMen.Text = Convert.ToString(int.Parse(textBoxCriaM.Text) + int.Parse(textBoxSobraM.Text));

            if (int.Parse(textBoxCriaMen.Text) >= int.Parse(textBoxMinimo.Text)) { textBoxMinimo.ForeColor = Color.Red; }
            else { textBoxMinimo.ForeColor = Color.Black; }
        }
        //CRIAÇÃO DOS COMBINAÇOES + OU - 
        public void AdicionaSeleciado()
        {
            int valor = int.Parse(textBoxCriaM.Text);
            textBoxCriaM.Text = Convert.ToString(valor + 1);

            NumerosTexto();
        }
        public void DiminuiSeleciado()
        {
            int valor = int.Parse(textBoxCriaM.Text);
            textBoxCriaM.Text = Convert.ToString(valor - 1);

            NumerosTexto();
        }
        public void AdicionaSeleciado2()
        {
            int valor = int.Parse(textBoxSobraM.Text);
            textBoxSobraM.Text = Convert.ToString(valor + 1);

            NumerosTexto();
        }
        public void DiminuiSeleciado2()
        {
            int valor = int.Parse(textBoxSobraM.Text);
            textBoxSobraM.Text = Convert.ToString(valor - 1);

            NumerosTexto();
        }
        public void AdicionaPar()
        {
            int valor = int.Parse(textBoxPar.Text);
            textBoxPar.Text = Convert.ToString(valor + 1);
        }
        public void DiminuiPar()
        {
            int valor = int.Parse(textBoxPar.Text);
            textBoxPar.Text = Convert.ToString(valor - 1);
        }
        public void AdicionaImpar()
        {
            int valor = int.Parse(textBoxImpar.Text);
            textBoxImpar.Text = Convert.ToString(valor + 1);
        }
        public void DiminuiImpar()
        {
            int valor = int.Parse(textBoxImpar.Text);
            textBoxImpar.Text = Convert.ToString(valor - 1);
        }

        public void AdcionaRepetidas()
        {
            int valor = int.Parse(textBoxRepeticao.Text);
            textBoxRepeticao.Text = Convert.ToString(valor + 1);
        }
        public void DiminiuRepetidas()
        {
            int valor = int.Parse(textBoxRepeticao.Text);
            textBoxRepeticao.Text = Convert.ToString(valor - 1);
        }
        public void AdcionaModula()
        {
            int valor = int.Parse(textBoxModula.Text);
            textBoxModula.Text = Convert.ToString(valor + 1);
        }
        public void DiminiuModula()
        {
            int valor = int.Parse(textBoxModula.Text);
            textBoxModula.Text = Convert.ToString(valor - 1);
        }
        public void AdcionaPrimos()
        {
            int valor = int.Parse(textBoxPrimos.Text);
            textBoxPrimos.Text = Convert.ToString(valor + 1);
        }
        public void DiminiuPrimos()
        {
            int valor = int.Parse(textBoxPrimos.Text);
            textBoxPrimos.Text = Convert.ToString(valor - 1);
        }
        public void AdcionaFibonacci()
        {
            int valor = int.Parse(textBoxFibonacci.Text);
            textBoxFibonacci.Text = Convert.ToString(valor + 1);
        }
        public void DiminiuFibonacci()
        {
            int valor = int.Parse(textBoxFibonacci.Text);
            textBoxFibonacci.Text = Convert.ToString(valor - 1);
        }
        public void AdicionaMult3()
        {
            int valor = int.Parse(textBoxMult3.Text);
            textBoxMult3.Text = Convert.ToString(valor + 1);
        }
        public void DiminiuMult3()
        {
            int valor = int.Parse(textBoxMult3.Text);
            textBoxMult3.Text = Convert.ToString(valor - 1);
        }
        public void AdicionaMagico()
        {
            int valor = int.Parse(textBoxMinimoMagico.Text);
            textBoxMinimoMagico.Text = Convert.ToString(valor + 1);
        }
        public void DiminiuMagico()
        {
            int valor = int.Parse(textBoxMinimoMagico.Text);
            textBoxMinimoMagico.Text = Convert.ToString(valor - 1);
        }

        //-----------------------------------------------
        private void comboBoxLotoFacil_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.NumeroJogos = int.Parse(comboBoxLotoFacil.Text);
        }
        private void buttonvalor_Click(object sender, EventArgs e)
        {
            //array();
            //MessageBox.Show(this.NumeroCombinacaoPares.ToString() + "   " + this.NumeroCombinacaoImpar.ToString() + "\n" +
            //    this.NumeroRepetidas.ToString() + "  " + this.NumeroModula.ToString() + "  " + this.NumeroPrimos.ToString() + "\n" +
            //    this.NumeroFibonacci.ToString() + " " + this.NumeroMultiploDe3.ToString());
        }

        private void comboBoxParImpar_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CombinacaoParesImparIndex = int.Parse(this.comboBoxParImpar.SelectedIndex.ToString());
        }
        private void comboBoxNumeroRepetidas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.NumeroRepetidas = int.Parse(this.comboBoxNumeroRepetidas.SelectedIndex.ToString());
        }
        private void comboBoxMoldura_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.NumeroModula = int.Parse(this.comboBoxMoldura.SelectedIndex.ToString());
        }

        private void TelaPrincipal_Load(object sender, EventArgs e)
        {

        }
        private void comboBoxPrimos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.NumeroPrimos = int.Parse(this.comboBoxPrimos.SelectedIndex.ToString());
        }

        private void comboBoxFibonacci_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.NumeroFibonacci = int.Parse(this.comboBoxFibonacci.SelectedIndex.ToString());
        }

        private void comboBoxMultiploDe3_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.NumeroMultiploDe3 = int.Parse(this.comboBoxMultiploDe3.SelectedIndex.ToString());
        }
        private void buttonSalvaUltimoResultado_Click(object sender, EventArgs e)
        {
            try
            {
                AdicionarResultadoUltimo();
                VerificarNumerosResto();
                AdicionarCriacaoJogos();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void buttonLimpaDados_Click(object sender, EventArgs e)
        {
            try
            {
                this.BuscaLouC = 0;
                LimpaResultadoJogos();
                limpaTodosSelecionado();
                limpaCombinacoesEscolhidas();
                limpaCheckERadio();

                comboBoxParImpar.Items.Clear();
                comboBoxNumeroRepetidas.Items.Clear();
                comboBoxMoldura.Items.Clear();
                comboBoxPrimos.Items.Clear();
                comboBoxFibonacci.Items.Clear();
                comboBoxMultiploDe3.Items.Clear();

                //JogosLotoFacil();
                DezenasParesImpares();
                comboBoxParImpar.SelectedIndex = 0;
                NumerosRepetidas();
                comboBoxNumeroRepetidas.SelectedIndex = 0;
                NumerosMoldura();
                comboBoxMoldura.SelectedIndex = 0;
                NumerosPrimos();
                comboBoxPrimos.SelectedIndex = 0;
                NumerosFibonacci();
                comboBoxFibonacci.SelectedIndex = 0;
                NumerosMultiploDe3();
                comboBoxMultiploDe3.SelectedIndex = 0;
            }
            catch (Exception err)
            {
                err.ToString();
            }
        }
        public void AdicionarResultadoUltimo()
        {
            try
            {

                for (int i = 1; i <= 15; i++)
                {
                    //Painel Resultado Jogo
                    string textBoxEntrada2 = "textBoxNr";
                    StringBuilder sb = new StringBuilder(textBoxEntrada2);
                    sb.Append(i);
                    Panel panel = Application.OpenForms["TelaPrincipal"].Controls["panelTotal"].Controls["panelResultado"] as Panel;
                    TextBox TextBoxN = panel.Controls[sb.ToString()] as TextBox;
                    //TextBoxN.Enabled = false;

                    if (i == 1)
                    {
                        TextBoxN.Text = arrays.ArrayL(int.Parse(arrays.ArrayTamanho()) - 1, 0).ToString();
                    }
                    else
                    {
                        TextBoxN.Text = arrays.ArrayL(int.Parse(arrays.ArrayTamanho()) - 1, i - 1).ToString();
                    }

                }             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void IniciarResultado()
        {
            int temp = 0, posicao = 0, posicao2 = 0;
            for(int numero = 1; numero <= 25; numero++)
            {
                for (int coluna = temp; coluna < 15; coluna++)
                {
                    if ( numero == arrays.ArrayL(int.Parse(arrays.ArrayTamanho()) - 1, coluna))
                    {
                        //Painel CRIAR JOGOS.
                        string textBoxEntrada = "circularButton";
                        StringBuilder sb = new StringBuilder(textBoxEntrada);
                        sb.Append(arrays.ArrayL(int.Parse(arrays.ArrayTamanho()) - 1, coluna));
                        Panel panel = Application.OpenForms["TelaPrincipal"].Controls["panelTotal"].Controls["panelNumeros"] as Panel;
                        Button Button = panel.Controls[sb.ToString()] as Button;
                        Button.Enabled = true;
                        Button.ForeColor = Color.BlueViolet;
  
                        //LightSkyBlue
                        int numeroG = numero;
                        ArrayResultadoJogos[posicao] = numeroG;
                        posicao++;
                        //Painel  NUMEROS QUE NÃO SAIRAM
                        string textBoxEntrada2 = "circularButtonX";
                        StringBuilder sb2 = new StringBuilder(textBoxEntrada2);
                        sb2.Append(arrays.ArrayL(int.Parse(arrays.ArrayTamanho()) - 1, coluna));
                        Panel panel2 = Application.OpenForms["TelaPrincipal"].Controls["panelTotal"].Controls["panelNumeros2"] as Panel;
                        Button Button2 = panel2.Controls[sb2.ToString()] as Button;
                        Button2.Enabled = false;//Button2.BackColor = Color.Gainsboro;
                        coluna = temp;
                        coluna = 15;
                    }
                    else
                    {
                        if (numero < arrays.ArrayL(int.Parse(arrays.ArrayTamanho()) - 1, coluna))
                        {
                            //Painel CRIAR JOGOS.
                            string textBoxEntrada = "circularButton";
                            StringBuilder sb = new StringBuilder(textBoxEntrada);
                            sb.Append(numero);
                            Panel panel = Application.OpenForms["TelaPrincipal"].Controls["panelTotal"].Controls["panelNumeros"] as Panel;
                            Button Button = panel.Controls[sb.ToString()] as Button;
                            Button.Enabled = false;
                            //Painel  NUMEROS QUE NÃO SAIRAM
                            ArrayResultadoSobra[posicao2] = numero;
                            posicao2++;
                            string textBoxEntrada2 = "circularButtonX";
                            StringBuilder sb2 = new StringBuilder(textBoxEntrada2);
                            sb2.Append(numero);
                            Panel panel2 = Application.OpenForms["TelaPrincipal"].Controls["panelTotal"].Controls["panelNumeros2"] as Panel;
                            Button Button2 = panel2.Controls[sb2.ToString()] as Button;
                            Button2.Enabled = true;
                            Button2.ForeColor = Color.Red;
                            coluna = temp;
                            coluna = 15;
                        }
                        else
                        {
                            if (numero > arrays.ArrayL(int.Parse(arrays.ArrayTamanho()) - 1, 14))
                            {
                                //Painel CRIAR JOGOS.
                                string textBoxEntrada = "circularButton";
                                StringBuilder sb = new StringBuilder(textBoxEntrada);
                                sb.Append(numero);
                                Panel panel = Application.OpenForms["TelaPrincipal"].Controls["panelTotal"].Controls["panelNumeros"] as Panel;
                                Button Button = panel.Controls[sb.ToString()] as Button;
                                Button.Enabled = false;
                                //Painel  NUMEROS QUE NÃO SAIRAM
                                ArrayResultadoSobra[posicao2] = numero;
                                posicao2++;
                                string textBoxEntrada2 = "circularButtonX";
                                StringBuilder sb2 = new StringBuilder(textBoxEntrada2);
                                sb2.Append(numero);
                                Panel panel2 = Application.OpenForms["TelaPrincipal"].Controls["panelTotal"].Controls["panelNumeros2"] as Panel;
                                Button Button2 = panel2.Controls[sb2.ToString()] as Button;
                                Button2.Enabled = true;
                                Button2.ForeColor = Color.Red;
                                coluna = temp;
                                coluna = 15;
                            }
                        }
                    }

                }
             }
        }
        public void SelecionaTodosNumeros()
        {
            for (int numero = 1; numero <= 25; numero++)
            {
            }
        }

        public void VerificarNumerosResto()
        {
            try
            {
                for (int i = 1; i <= 25; i++)
                {
                    //Painel Resultado Jogo
                    string textBoxEntrada = "circularButtonX";
                    StringBuilder sb = new StringBuilder(textBoxEntrada);
                    sb.Append(+i);
                    Panel panel = Application.OpenForms["TelaPrincipal"].Controls["panelTotal"].Controls["panelNumeros2"] as Panel;
                    Button Button = panel.Controls[sb.ToString()] as Button;
                    Button.Enabled = false;
                    Button.BackColor = Color.Gainsboro;
                }
                int posicao = 0;
                for (int n = 1; n <= 25; n++)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        string Valor = ArrayResultadoJogos[i].ToString();
                        int numero = int.Parse(Valor);

                        if (n == numero)
                        {
                            i = 15;
                        }
                        if ((i == 14) & (numero != n))
                        {
                            ArrayResultadoSobra[posicao] = n;
                            posicao++;

                            string textBoxEntrada = "circularButtonX";
                            StringBuilder sb = new StringBuilder(textBoxEntrada);
                            sb.Append(+n);
                            Panel panel = Application.OpenForms["TelaPrincipal"].Controls["panelTotal"].Controls["panelNumeros2"] as Panel;
                            Button Button = panel.Controls[sb.ToString()] as Button;
                            Button.Enabled = true;
                            Button.ForeColor = Color.Red;
                        }
                    }
                }
            }
            catch (Exception err)
            {
                err.ToString();
            }
        }
        public void AdicionarCriacaoJogos()
        {
            try
            {
                for (int i = 1; i <= 25; i++)
                {
                    //Painel Resultado Jogo
                    string textBoxEntrada = "circularButton";
                    StringBuilder sb = new StringBuilder(textBoxEntrada);
                    sb.Append(+i);
                    Panel panel = Application.OpenForms["TelaPrincipal"].Controls["panelTotal"].Controls["panelNumeros"] as Panel;
                    Button Button = panel.Controls[sb.ToString()] as Button;
                    Button.Enabled = true;
                    Button.ForeColor = Color.BlueViolet;
                }

                for (int sobraP = 0; sobraP < ArrayResultadoSobra.Length; sobraP++)
                {
                    string Valor = ArrayResultadoSobra[sobraP].ToString();
                    string textBoxEntrada = "circularButton";
                    StringBuilder sb = new StringBuilder(textBoxEntrada);
                    sb.Append(Valor);
                    Panel panel = Application.OpenForms["TelaPrincipal"].Controls["panelTotal"].Controls["panelNumeros"] as Panel;
                    Button Button = panel.Controls[sb.ToString()] as Button;
                    Button.Enabled = false;
                    Button.ForeColor = Color.Black;
                }
            }

            catch (Exception err)
            {
                err.ToString();
            }
        }

        public void limpaTodosSelecionado()
        {
            dataGridViewSelecionado.Rows.Clear();
            dataGridViewSelecionado.Rows.Add("","", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
        }
        public void limpaCombinacoesEscolhidas()
        {
            dataGridViewCombinacoesEscolhidas.Rows.Clear();
            dataGridViewCombinacoesEscolhidas.Rows.Add("","", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
        }
        public void limpaCheckERadio()
        {
            radioButtonLivre.Checked = false;
            radioButtonCombinacao.Checked = false;
            checkBoxCombinacaoEscolhida.Checked = false;
            checkBoxPI.Checked = false;
            checkBoxNumeroRepetidos.Checked = false;
            checkBoxMoldura.Checked = false;
            checkBoxNumerosFibonacci.Checked = false;
            checkBoxMultiploDe3.Checked = false;
            radioButtonTodosJogos.Checked = false;
            radioButtonParImpar.Checked = false;
            radioButtonNumeroRepetidas.Checked = false;
            radioButtonMoldura.Checked = false;
            radioButtonPrimos.Checked = false;
            radioButtonFibonacci.Checked = false;
            radioButtonMultiploDe3.Checked = false;
        }
        public void LimpaResultadoJogos()
        {
            try
            {
                textBoxMinimoEscolha.Text = "0";
                textBoxMaximoEscolha.Text = "0";
                textBoxPar.Text = "0";
                textBoxImpar.Text = "0";
                textBoxRepeticao.Text = "0";
                textBoxModula.Text = "0";
                textBoxPrimos.Text = "0";
                textBoxFibonacci.Text = "0";
                textBoxMult3.Text = "0";
                textBoxCriaM.Text = "0";
                textBoxSobraM.Text = "0";
                textBoxCriaMen.Text = "0";
                label37.Text = "QUANT: ";
                label38.Text = "TOTAL: ";

                //Lista de elementos Criar e Sobra
                ElementosListaCriar.Clear();
                ElementosListaSobra.Clear();

                //this.QuantidadeNumeros = 0;
                this.QuantNumerosInicio = 0;//3
                //Lista de valores
                int[] ElementosCombinacoes = new int[14];
                int[,] ArrayJogosCombinacao = new int[30, 15];
                this.quantidade = 0;
                this.count = 0;

                //LIMPA CRIAR JOGOS
                for (int i = 1; i <= 25; i++)
                {
                    //Painel Resultado Jogo
                    string textBoxEntrada = "circularButton";
                    StringBuilder sb = new StringBuilder(textBoxEntrada);
                    sb.Append(+i);
                    Panel panel = Application.OpenForms["TelaPrincipal"].Controls["panelTotal"].Controls["panelNumeros"] as Panel;
                    Button Button = panel.Controls[sb.ToString()] as Button;
                    Button.Enabled = true;
                    Button.BackColor = Color.Gainsboro;
                    Button.ForeColor = Color.Black;
                }
                //LIMPA NUMEROS QUE NÃO SAIRAM
                for (int i = 1; i <= 25; i++)
                {
                    //Painel Resultado Jogo
                    string textBoxEntrada = "circularButtonx";
                    StringBuilder sb = new StringBuilder(textBoxEntrada);
                    sb.Append(+i);
                    Panel panel = Application.OpenForms["TelaPrincipal"].Controls["panelTotal"].Controls["panelNumeros2"] as Panel;
                    Button Button = panel.Controls[sb.ToString()] as Button;
                    Button.Enabled = true;
                    Button.BackColor = Color.Gainsboro;
                    Button.ForeColor = Color.Black;
                }
                for (int i = 1; i <= 15; i++)
                {
                    //Painel Resultado Jogo Limpa os numeros.
                    string textBoxEntrada = "textBox";
                    StringBuilder sb = new StringBuilder(textBoxEntrada);
                    sb.Append("Nr" + i);
                    Panel panel = Application.OpenForms["TelaPrincipal"].Controls["panelTotal"].Controls["panelResultado"] as Panel;
                    TextBox textbox = panel.Controls[sb.ToString()] as TextBox;
                    textbox.Clear();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void buttonCombinar_Click(object sender, EventArgs e)
        {
            try
            {
                this.MinimoElemento = int.Parse(textBoxMinimoEscolha.Text);
                this.maximoElemento = int.Parse(textBoxMaximoEscolha.Text);
                if (checkBoxNumeros.Checked == true) 
                {
                    NumerosListaCombinar.Clear();
                    //Amazenar Numeros Selecionados
                    for (int i = 1; i <= 25; i++)
                    {
                        //Painel Resultado Jogo
                        string textBoxEntrada = "circularButtonN";
                        StringBuilder sb = new StringBuilder(textBoxEntrada);
                        sb.Append(+i);
                        Panel panel = Application.OpenForms["TelaPrincipal"].Controls["panelNumerosAtivos"] as Panel;
                        Button Button = panel.Controls[sb.ToString()] as Button;

                        if (Button.BackColor == Color.LightSkyBlue)
                        {
                            NumerosListaCombinar.Add(i);
                        }
                    }
                    //Arruma
                    CombinacoesEscolhidas1(CombinacaoParesImparIndex, NumeroRepetidas, NumeroModula, NumeroPrimos, NumeroFibonacci, NumeroMultiploDe3,
                        int.Parse(textBoxCheboxInicio.Text), int.Parse(textBoxCheboxFim.Text));
                    label42.Text = "QUANT: " + Convert.ToString(dataGridViewCombinacoesEscolhidas.Rows.Count - 1);
                }
                if (checkBoxNumeros.Checked == false) 
                {
                    this.MinimoElemento = int.Parse(textBoxMinimoEscolha.Text);
                    this.maximoElemento = int.Parse(textBoxMaximoEscolha.Text);
                    CombinacoesEscolhidas(CombinacaoParesImparIndex, NumeroRepetidas, NumeroModula, NumeroPrimos, NumeroFibonacci, NumeroMultiploDe3,
                    int.Parse(textBoxCheboxInicio.Text), int.Parse(textBoxCheboxFim.Text));
                    label42.Text = "QUANT: " + Convert.ToString(dataGridViewCombinacoesEscolhidas.Rows.Count - 1);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public void CombinacoesEscolhidas1(int PI, int R, int M, int P, int F, int M3, int INICIO, int FIM)
        {
            try
            {
                ListaCombinacoes.Clear();
                limpaCombinacoesEscolhidas();
                int contN = 0;
                int PosicaoC = 0;
                int proximaBusca = 0;

                if (NumerosListaCombinar.Count > 0)
                {
                    for (int i = 0; i < ListaTodosSelecionados.Count; i++)
                    {
                        //INICIO NUMEROS LISTADOS
                        for (int Pnumero = 0; Pnumero < NumerosListaCombinar.Count; Pnumero++)
                        {
                            for (int coluna = PosicaoC; coluna < 15; coluna++)
                            {
                                if (NumerosListaCombinar[Pnumero] < ArrayJogosCombinacao[ListaTodosSelecionados[i], coluna])
                                {
                                    PosicaoC = 15;
                                }
                                if (NumerosListaCombinar[Pnumero] == ArrayJogosCombinacao[ListaTodosSelecionados[i], coluna])
                                {
                                    contN++;
                                    PosicaoC = coluna + 1;
                                    coluna = 15;
                                }                                  
                            }
                        }
                        if (NumerosListaCombinar.Count == contN)
                        {
                            ListaCombinacoes.Add(ListaTodosSelecionados[i]);
                        }
                        PosicaoC = 0;
                        contN = 0;

                    }
                }//FIM
                proximaBusca = 0;
                if (checkBoxInicioEFim.Checked == true)//INICIO E FIM COLUNAS
                {
                    if (ListaCombinacoes.Count > 0)
                    {
                        int Nivel = 0;                       
                        if ((INICIO != 0) && (FIM != 0)) { Nivel = 1; }
                        if ((INICIO != 0) && (FIM == 0)) { Nivel = 2; }
                        if ((INICIO == 0) && (FIM != 0)) { Nivel = 3; }
                        if ((INICIO == 0) && (FIM == 0)) { Nivel = 4; }

                        for (int posicao = 0; posicao < ListaCombinacoes.Count; posicao++)
                        {
                            if (Nivel == 1)
                            {
                                //As duas posicao
                                if ((ArrayJogosCombinacao[ListaCombinacoes[posicao], 0] != INICIO) || (ArrayJogosCombinacao[ListaCombinacoes[posicao], 14] != FIM))
                                {
                                    ListaCombinacoes.RemoveAt(posicao);
                                    --posicao;
                                }                                                                                        
                            }
                            if (Nivel == 2)
                            {
                                //Possicao Inicio
                                if (ArrayJogosCombinacao[ListaCombinacoes[posicao], 0] != INICIO)
                                {
                                    ListaCombinacoes.RemoveAt(posicao);
                                    --posicao;
                                }                              
                            }
                            if (Nivel == 3)
                            {
                                //Posicao Final
                                if (ArrayJogosCombinacao[ListaCombinacoes[posicao], 14] != FIM)
                                {
                                    ListaCombinacoes.RemoveAt(posicao);
                                    --posicao;
                                }
                            }
                        }
                        Nivel = 0;
                    }
                }//FIM
                proximaBusca = 0;
                if (checkBoxPI.Checked == true)// CONJUNTO DE IMPAR E PARES
                {
                    if (ListaCombinacoes.Count > 0)
                    {
                        int par = 0, impar = 0;
                        int cont = 0, cont2 = 0;
 
                        if (PI == 1) { par = 7; impar = 8; }
                        if (PI == 2) { par = 8; impar = 7; }
                        if (PI == 3) { par = 6; impar = 9; }
                        if (PI == 4) { par = 9; impar = 6; }
                        if (PI == 5) { par = 5; impar = 10; }
                        if (PI == 6) { par = 10; impar = 5; }
                        if (PI == 7) { par = 4; impar = 11; }
                        if (PI == 8) { par = 11; impar = 4; }
                        if (PI == 9) { par = 3; impar = 12; }
                        if (PI == 10) { par = 12; impar = 3; }
                        if (PI == 11) { par = 2; impar = 13; }

                        for (int posicao = 0; posicao < ListaCombinacoes.Count; posicao++)
                        {
                            for (int coluna = 0; coluna < 15; coluna++)
                            {
                                if (ArrayJogosCombinacao[ListaCombinacoes[posicao], coluna] % 2 == 0)
                                {//par
                                    cont++;
                                }
                                else
                                {//impar
                                    cont2++;
                                }
                            }
                            if ((par != cont) || (impar != cont2))
                            {
                                ListaCombinacoes.RemoveAt(posicao);
                                --posicao;
                            }
                            cont = 0; cont2 = 0;                                                    
                        }
                    }
                }//FIM
                proximaBusca = 0;
                if (checkBoxNumeroRepetidos.Checked == true)// CONJUNTOS PRIMOS
                {
                    if (ListaCombinacoes.Count > 0)
                    {
                        int cont = 0;
                        int repeticao = 0;
                        int buscaR = 0;
                        if (R == 1) { repeticao = 9; }
                        if (R == 2) { repeticao = 8; }
                        if (R == 3) { repeticao = 10; }
                        if (R == 4) { repeticao = 7; }
                        if (R == 5) { repeticao = 11; }
                        if (R == 6) { repeticao = 12; }
                        if (R == 7) { repeticao = 6; }
                        if (R == 8) { repeticao = 13; }
                        if (R == 9) { repeticao = 14; }
                        if (R == 10) { repeticao = 15; }

                        for (int posicao = 0; posicao < ListaCombinacoes.Count; posicao++)
                        {
                            for (int coluna = 0; coluna < 15; coluna++)
                            {
                                for (int arrayM = buscaR; arrayM < ArrayRepetidos.Length; arrayM++)
                                {
                                    if (ArrayRepetidos[arrayM] > ArrayJogosCombinacao[ListaCombinacoes[posicao], coluna])
                                    {
                                        arrayM = ArrayRepetidos.Length;
                                    }
                                    else
                                    {
                                        if (ArrayJogosCombinacao[ListaCombinacoes[posicao], coluna] == ArrayRepetidos[arrayM])
                                        {
                                            cont++;
                                            buscaR = arrayM + 1;
                                            arrayM = ArrayRepetidos.Length;
                                        }
                                    }
                                }
                            }
                            if (cont != repeticao)
                            {
                                ListaCombinacoes.RemoveAt(posicao);
                                --posicao;
                            }
                            cont = 0;
                            buscaR = 0;                                                                     
                        }
                    }
                }//FIM
                proximaBusca = 0;
                if (checkBoxMoldura.Checked == true)//MOLDURA
                {
                    int cont = 0;
                    int modula = 0;
                    int buscaM = 0;
                    int[] ArrayMoldura = new int[] { 1, 2, 3, 4, 5, 6, 10, 11, 15, 16, 20, 21, 22, 23, 24, 25 };

                    if (M == 1) { modula = 10; }
                    if (M == 2) { modula = 9; }
                    if (M == 3) { modula = 11; }
                    if (M == 4) { modula = 8; }
                    if (M == 5) { modula = 12; }
                    if (M == 6) { modula = 7; }
                    if (M == 7) { modula = 13; }
                    if (M == 8) { modula = 6; }
                    if (M == 9) { modula = 14; }
                    if (M == 10) { modula = 15; }

                    if (ListaCombinacoes.Count > 0)
                    {
                        for (int posicao = 0; posicao < ListaCombinacoes.Count; posicao++)
                        {     
                            for (int coluna = 0; coluna < 15; coluna++)
                            {
                                for (int arrayM = buscaM; arrayM < ArrayMoldura.Length; arrayM++)
                                {
                                    if (ArrayMoldura[arrayM] > ArrayJogosCombinacao[ListaCombinacoes[posicao], coluna])
                                    {
                                        arrayM = ArrayMoldura.Length;
                                    }
                                    else
                                    {
                                        if (ArrayJogosCombinacao[ListaCombinacoes[posicao], coluna] == ArrayMoldura[arrayM])
                                        {
                                            cont++;
                                            buscaM = arrayM + 1;
                                            arrayM = ArrayMoldura.Length;
                                        }
                                    }
                                }
                            }
                            if (cont != modula)
                            {
                                ListaCombinacoes.RemoveAt(posicao);
                                --posicao;
                            }
                            cont = 0;
                            buscaM = 0;
                            proximaBusca++;                      
                        }
                    }
                }//FIM
                proximaBusca = 0;
                if (checkBoxPrimos.Checked == true) //PRIMOS
                {
                    int cont = 0;
                    int primos = 0;
                    int buscaP = 0;
                    int[] ArrayPrimos = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23 };

                    if (P == 1) { primos = 5; }
                    if (P == 2) { primos = 6; }
                    if (P == 3) { primos = 4; }
                    if (P == 4) { primos = 7; }
                    if (P == 5) { primos = 3; }
                    if (P == 6) { primos = 8; }
                    if (P == 7) { primos = 2; }
                    if (P == 8) { primos = 9; }
                    if (P == 9) { primos = 1; }
                    if (P == 10) { primos = 0; }

                    if (ListaCombinacoes.Count > 0)
                    {
                        for (int posicao = 0; posicao < ListaCombinacoes.Count; posicao++)
                        {
                            for (int coluna = 0; coluna < 15; coluna++)
                            {
                                for (int arrayM = buscaP; arrayM < ArrayPrimos.Length; arrayM++)
                                {
                                    if (ArrayPrimos[arrayM] > ArrayJogosCombinacao[ListaCombinacoes[posicao], coluna])
                                    {
                                        arrayM = ArrayPrimos.Length;
                                    }
                                    else
                                    {
                                        if (ArrayJogosCombinacao[ListaCombinacoes[posicao], coluna] == ArrayPrimos[arrayM])
                                        {
                                            cont++;
                                            buscaP = arrayM + 1;
                                            arrayM = ArrayPrimos.Length;
                                        }
                                    }
                                }
                            }
                            if (cont != primos)
                            {
                                ListaCombinacoes.RemoveAt(posicao);
                                --posicao;
                            }
                            cont = 0;
                            buscaP = 0;                                                                                
                        }
                    }
                }//FIM
                proximaBusca = 0;
                if (checkBoxNumerosFibonacci.Checked == true) //FIBONACCI
                {
                    int cont = 0;
                    int Fibonnacci = 0;
                    int buscaF = 0;
                    int[] Fibonacci = new int[] { 1, 2, 3, 5, 8, 13, 21 };

                    if (F == 1) { Fibonnacci = 4; }
                    if (F == 2) { Fibonnacci = 5; }
                    if (F == 3) { Fibonnacci = 3; }
                    if (F == 4) { Fibonnacci = 6; }
                    if (F == 5) { Fibonnacci = 2; }
                    if (F == 6) { Fibonnacci = 7; }
                    if (F == 7) { Fibonnacci = 1; }
                    if (F == 8) { Fibonnacci = 0; }

                    if (ListaCombinacoes.Count > 0)
                    {
                        for (int posicao = 0; posicao < ListaCombinacoes.Count; posicao++)
                        {
                            for (int coluna = 0; coluna < 15; coluna++)
                            {
                                for (int arrayM = buscaF; arrayM < Fibonacci.Length; arrayM++)
                                {
                                    if (Fibonacci[arrayM] > ArrayJogosCombinacao[ListaCombinacoes[posicao], coluna])
                                    {
                                        arrayM = Fibonacci.Length;
                                    }
                                    else
                                    {
                                        if (ArrayJogosCombinacao[ListaCombinacoes[posicao], coluna] == Fibonacci[arrayM])
                                        {
                                            cont++;
                                            buscaF = arrayM + 1;
                                            arrayM = Fibonacci.Length;
                                        }
                                    }
                                }
                            }
                            if (cont != Fibonnacci) //&& (MinimoElemento <= quantidade) && (quantidade <= maximoElemento))
                            {
                                ListaCombinacoes.RemoveAt(posicao);
                                --posicao;
                            }
                            cont = 0;
                            buscaF = 0;                                                                      
                        }
                    }
                }//FIM
                proximaBusca = 0;
                if (checkBoxMultiploDe3.Checked == true)//MULT DE 3
                {
                    int cont = 0;
                    int Mult = 0;
                    int buscaM3 = 0;
                    int[] ArrayMult = new int[] { 3, 6, 9, 12, 15, 18, 21, 24 };

                    if (M3 == 1) { Mult = 5; }
                    if (M3 == 2) { Mult = 4; }
                    if (M3 == 3) { Mult = 6; }
                    if (M3 == 4) { Mult = 3; }
                    if (M3 == 5) { Mult = 7; }
                    if (M3 == 6) { Mult = 2; }
                    if (M3 == 7) { Mult = 8; }

                    if (ListaCombinacoes.Count > 0)
                    {
                        for (int posicao = 0; posicao < ListaCombinacoes.Count; posicao++)
                        {
                            for (int coluna = 0; coluna < 15; coluna++)
                            {
                                for (int arrayM = buscaM3; arrayM < ArrayMult.Length; arrayM++)
                                {
                                    if (ArrayMult[arrayM] > ArrayJogosCombinacao[ListaCombinacoes[posicao], coluna])
                                    {
                                        arrayM = ArrayMult.Length;
                                    }
                                    else
                                    {
                                        if (ArrayJogosCombinacao[ListaCombinacoes[posicao], coluna] == ArrayMult[arrayM])
                                        {
                                            cont++;
                                            ContBusca = arrayM + 1;
                                            arrayM = ArrayMult.Length;
                                        }
                                    }
                                }
                            }
                            if (cont != Mult)
                            {
                                ListaCombinacoes.RemoveAt(posicao);
                                --posicao;
                            }
                            cont = 0;
                            buscaM3 = 0;                                                
                        }
                    }
                }
                proximaBusca = 0;
                if (ListaCombinacoes.Count == 0)
                {
                    Console.WriteLine("\n  Nem um Números + Combinação encotrado! \n");
                }
                else if (ListaCombinacoes.Count > 0)
                {
                    for (int linha = 0; linha < ListaCombinacoes.Count; linha++)
                    {
                        dataGridViewCombinacoesEscolhidas.Rows[dataGridViewCombinacoesEscolhidas.Rows.Count - 1].Cells[0].Value = dataGridViewCombinacoesEscolhidas.Rows.Count;
                        dataGridViewCombinacoesEscolhidas.Rows[dataGridViewCombinacoesEscolhidas.Rows.Count - 1].Cells[1].Value = ListaCombinacoes[linha];
                        for (int coluna = 0; coluna < 15; coluna++)
                        {
                            dataGridViewCombinacoesEscolhidas.Rows[dataGridViewCombinacoesEscolhidas.Rows.Count - 1].Cells[coluna + 2].Value = Convert.ToString(ArrayJogosCombinacao[ListaCombinacoes[linha], coluna]);
                        }
                        dataGridViewCombinacoesEscolhidas.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally { Console.WriteLine(" \n Números + Combinação : " + ListaCombinacoes.Count + " \n"); }
        }
        public void CombinacoesEscolhidas(int PI, int R, int M, int P, int F, int M3,int INICIO,int FIM)
        {
            try
            {
                ListaCombinacoes.Clear();
                limpaCombinacoesEscolhidas();

                Boolean ativado = false;

                if (checkBoxInicioEFim.Checked == true)//INICIO E FIM COLUNAS
                {
                    int Nivel = 0;
                    if (!(INICIO == 0) && !(FIM == 0)) { Nivel = 1; }
                    if (!(INICIO == 0) && (FIM == 0)) { Nivel = 2; }
                    if ((INICIO == 0) && !(FIM == 0)) { Nivel = 3; }
                    if ((INICIO == 0) && (FIM == 0)) { Nivel = 4; }

                    //As duas posicao
                    for (int i = 0; i < ListaTodosSelecionados.Count; i++)
                    {
                        if(Nivel == 1)
                        {
                            if ((ArrayJogosCombinacao[ListaTodosSelecionados[i], 0] == INICIO) && (ArrayJogosCombinacao[ListaTodosSelecionados[i], 14] == FIM))
                            {
                                ListaCombinacoes.Add(ListaTodosSelecionados[i]);
                            }
                        }
                        if (Nivel == 2)
                        {
                            if (ArrayJogosCombinacao[ListaTodosSelecionados[i], 0] == INICIO)
                            {
                                ListaCombinacoes.Add(ListaTodosSelecionados[i]);
                            }
                        }
                        if (Nivel == 3)
                        {
                            if (ArrayJogosCombinacao[ListaTodosSelecionados[i], 14] == FIM)
                            {
                                ListaCombinacoes.Add(ListaTodosSelecionados[i]);
                            }
                        }
                    }
                    ativado = true;
                }//FIM
                if (checkBoxPI.Checked == true)// CONJUNTO DE IMPAR E PARES
                {
                    int par = 0, impar = 0;
                    int cont = 0, cont2 = 0;

                    if (PI == 1) { par = 7; impar = 8; }
                    if (PI == 2) { par = 8; impar = 7; }
                    if (PI == 3) { par = 6; impar = 9; }
                    if (PI == 4) { par = 9; impar = 6; }
                    if (PI == 5) { par = 5; impar = 10; }
                    if (PI == 6) { par = 10; impar = 5; }
                    if (PI == 7) { par = 4; impar = 11; }
                    if (PI == 8) { par = 11; impar = 4; }
                    if (PI == 9) { par = 3; impar = 12; }
                    if (PI == 10) { par = 12; impar = 3; }
                    if (PI == 11) { par = 2; impar = 13; }

                    if (ativado == false)
                    {
                        for (int i = 0; i < ListaTodosSelecionados.Count; i++)
                        {
                            for (int coluna = 0; coluna < 15; coluna++)
                            {
                                if (ArrayJogosCombinacao[ListaTodosSelecionados[i], coluna] % 2 == 0)
                                {//par
                                    cont++;
                                }
                                else
                                {//impar
                                    cont2++;
                                }
                            }
                            if ((par == cont) && (impar == cont2))
                            {
                                ListaCombinacoes.Add(ListaTodosSelecionados[i]);
                            }
                            cont = 0; cont2 = 0;
                        }
                        ativado = true;
                    }
                    else
                    {
                        if (ListaCombinacoes.Count > 0)
                        {
                            for (int posicao = 0; posicao < ListaCombinacoes.Count; posicao++)
                            {
                                for (int coluna = 0; coluna < 15; coluna++)
                                {
                                    if (ArrayJogosCombinacao[ListaCombinacoes[posicao], coluna] % 2 == 0)
                                    {//par
                                        cont++;
                                    }
                                    else
                                    {//impar
                                        cont2++;
                                    }
                                }
                                if ((par != cont) || (impar != cont2))
                                {
                                    ListaCombinacoes.RemoveAt(posicao);
                                    --posicao;
                                }
                                cont = 0; cont2 = 0;
                                                              
                            }
                        }
                    }
                }//FIM
                if (checkBoxNumeroRepetidos.Checked == true)// CONJUNTOS PRIMOS
                {
                    int cont = 0;
                    int repeticao = 0;
                    int buscaR = 0;
                    if (R == 1) { repeticao = 9; }
                    if (R == 2) { repeticao = 8; }
                    if (R == 3) { repeticao = 10; }
                    if (R == 4) { repeticao = 7; }
                    if (R == 5) { repeticao = 11; }
                    if (R == 6) { repeticao = 12; }
                    if (R == 7) { repeticao = 6; }
                    if (R == 8) { repeticao = 13; }
                    if (R == 9) { repeticao = 14; }
                    if (R == 10) { repeticao = 15; }
                    
                    if(ativado == false)
                    {
                        for (int i = 0; i < ListaTodosSelecionados.Count; i++)
                        {
                            for (int coluna = 0; coluna < 15; coluna++)
                            {
                                for (int arrayM = buscaR; arrayM < ArrayRepetidos.Length; arrayM++)
                                {
                                    if (ArrayRepetidos[arrayM] > ArrayJogosCombinacao[ListaTodosSelecionados[i], coluna])
                                    {
                                        arrayM = ArrayRepetidos.Length;
                                    }
                                    else
                                    {
                                        if (ArrayJogosCombinacao[ListaTodosSelecionados[i], coluna] == ArrayRepetidos[arrayM])
                                        {
                                            cont++;
                                            buscaR = arrayM + 1;
                                            arrayM = ArrayRepetidos.Length;
                                        }
                                    }
                                }
                            }
                            if (cont == repeticao)
                            {
                                ListaCombinacoes.Add(ListaTodosSelecionados[i]);
                            }
                            cont = 0;
                            buscaR = 0;                            
                        }
                        ativado = true;
                    }
                    else
                    {
                        if (ListaCombinacoes.Count > 0)
                        {
                            for (int posicao = 0; posicao < ListaCombinacoes.Count; posicao++)
                            {
                                for (int coluna = 0; coluna < 15; coluna++)
                                {
                                    for (int arrayM = buscaR; arrayM < ArrayRepetidos.Length; arrayM++)
                                    {
                                        if (ArrayRepetidos[arrayM] > ArrayJogosCombinacao[ListaCombinacoes[posicao], coluna])
                                        {
                                            arrayM = ArrayRepetidos.Length;
                                        }
                                        else
                                        {
                                            if (ArrayJogosCombinacao[ListaCombinacoes[posicao], coluna] == ArrayRepetidos[arrayM])
                                            {
                                                cont++;
                                                buscaR = arrayM + 1;
                                                arrayM = ArrayRepetidos.Length;
                                            }
                                        }
                                    }
                                }
                                if (cont != repeticao)
                                {
                                    ListaCombinacoes.RemoveAt(posicao);
                                    --posicao;
                                }
                                cont = 0;
                                buscaR = 0;
                                                             
                            }
                        }
                    }                   
                }//FIM
                if (checkBoxMoldura.Checked == true)//MOLDURA
                {
                    int cont = 0;
                    int modula = 0;
                    int buscaM = 0;
                    int[] ArrayMoldura = new int[] { 1, 2, 3, 4, 5, 6, 10, 11, 15, 16, 20, 21, 22, 23, 24, 25 };

                    if (M == 1) { modula = 10; }
                    if (M == 2) { modula = 9; }
                    if (M == 3) { modula = 11; }
                    if (M == 4) { modula = 8; }
                    if (M == 5) { modula = 12; }
                    if (M == 6) { modula = 7; }
                    if (M == 7) { modula = 13; }
                    if (M == 8) { modula = 6; }
                    if (M == 9) { modula = 14; }
                    if (M == 10) { modula = 15; }

                    if(ativado == false)
                    {
                        for (int i = 0; i < ListaTodosSelecionados.Count; i++)
                        {
                            for (int coluna = 0; coluna < 15; coluna++)
                            {
                                for (int arrayM = buscaM; arrayM < ArrayMoldura.Length; arrayM++)
                                {
                                    if (ArrayMoldura[arrayM] > ArrayJogosCombinacao[ListaTodosSelecionados[i], coluna])
                                    {
                                        arrayM = ArrayMoldura.Length;
                                    }
                                    else
                                    {
                                        if (ArrayJogosCombinacao[ListaTodosSelecionados[i], coluna] == ArrayMoldura[arrayM])
                                        {
                                            cont++;
                                            buscaM = arrayM + 1;
                                            arrayM = ArrayMoldura.Length;
                                        }
                                    }
                                }
                            }
                            if (cont == modula)
                            {
                                ListaCombinacoes.Add(ListaTodosSelecionados[i]);
                            }
                            cont = 0;
                            buscaM = 0;                           
                        }
                        ativado = true;
                    }
                    else
                    {
                        if (ListaCombinacoes.Count > 0)
                        {
                            for (int posicao = 0; posicao < ListaCombinacoes.Count; posicao++)
                            {
                                for (int coluna = 0; coluna < 15; coluna++)
                                {
                                    for (int arrayM = buscaM; arrayM < ArrayMoldura.Length; arrayM++)
                                    {
                                        if (ArrayMoldura[arrayM] > ArrayJogosCombinacao[ListaCombinacoes[posicao], coluna])
                                        {
                                            arrayM = ArrayMoldura.Length;
                                        }
                                        else
                                        {
                                            if (ArrayJogosCombinacao[ListaCombinacoes[posicao], coluna] == ArrayMoldura[arrayM])
                                            {
                                                cont++;
                                                buscaM = arrayM + 1;
                                                arrayM = ArrayMoldura.Length;
                                            }
                                        }
                                    }
                                }
                                if (cont != modula)
                                {
                                    ListaCombinacoes.RemoveAt(posicao);
                                    --posicao;
                                }
                                cont = 0;
                                buscaM = 0;
                                                              
                            }
                        }
                    }                  
                }//FIM
                if (checkBoxPrimos.Checked == true) //PRIMOS
                {
                    int cont = 0;
                    int primos = 0;
                    int buscaP = 0;
                    int[] ArrayPrimos = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23 };

                    if (P == 1) { primos = 5; }
                    if (P == 2) { primos = 6; }
                    if (P == 3) { primos = 4; }
                    if (P == 4) { primos = 7; }
                    if (P == 5) { primos = 3; }
                    if (P == 6) { primos = 8; }
                    if (P == 7) { primos = 2; }
                    if (P == 8) { primos = 9; }
                    if (P == 9) { primos = 1; }
                    if (P == 10) { primos = 0; }

                    if(ativado == false)
                    {
                        for (int i = 0; i < ListaTodosSelecionados.Count; i++)
                        {
                            for (int coluna = 0; coluna < 15; coluna++)
                            {
                                for (int arrayM = buscaP; arrayM < ArrayPrimos.Length; arrayM++)
                                {
                                    if (ArrayPrimos[arrayM] > ArrayJogosCombinacao[ListaTodosSelecionados[i], coluna])
                                    {
                                        arrayM = ArrayPrimos.Length;
                                    }
                                    else
                                    {
                                        if (ArrayJogosCombinacao[ListaTodosSelecionados[i], coluna] == ArrayPrimos[arrayM])
                                        {
                                            cont++;
                                            buscaP = arrayM + 1;
                                            arrayM = ArrayPrimos.Length;
                                        }
                                    }
                                }
                            }
                            if (cont == primos)
                            {
                                ListaCombinacoes.Add(ListaTodosSelecionados[i]);
                            }
                            cont = 0;
                            buscaP = 0;                                    
                        }
                        ativado = true;
                    }
                    else
                    {
                        if (ListaCombinacoes.Count > 0)
                        {
                            for (int posicao = 0; posicao < ListaCombinacoes.Count; posicao++)
                            {
                                for (int coluna = 0; coluna < 15; coluna++)
                                {
                                    for (int arrayM = buscaP; arrayM < ArrayPrimos.Length; arrayM++)
                                    {
                                        if (ArrayPrimos[arrayM] > ArrayJogosCombinacao[ListaCombinacoes[posicao], coluna])
                                        {
                                            arrayM = ArrayPrimos.Length;
                                        }
                                        else
                                        {
                                            if (ArrayJogosCombinacao[ListaCombinacoes[posicao], coluna] == ArrayPrimos[arrayM])
                                            {
                                                cont++;
                                                buscaP = arrayM + 1;
                                                arrayM = ArrayPrimos.Length;
                                            }
                                        }
                                    }
                                }
                                if (cont != primos)
                                {
                                    ListaCombinacoes.RemoveAt(posicao);
                                    --posicao;
                                }
                                cont = 0;
                                buscaP = 0;
                                                              
                            }
                        }
                    }
                    
                }//FIM
                if (checkBoxNumerosFibonacci.Checked == true) //FIBONACCI
                {
                    int cont = 0;
                    int Fibonnacci = 0;
                    int buscaF = 0;
                    int[] Fibonacci = new int[] { 1, 2, 3, 5, 8, 13, 21 };

                    if (F == 1) { Fibonnacci = 4; }
                    if (F == 2) { Fibonnacci = 5; }
                    if (F == 3) { Fibonnacci = 3; }
                    if (F == 4) { Fibonnacci = 6; }
                    if (F == 5) { Fibonnacci = 2; }
                    if (F == 6) { Fibonnacci = 7; }
                    if (F == 7) { Fibonnacci = 1; }
                    if (F == 8) { Fibonnacci = 0; }

                    if(ativado == false)
                    {
                        for (int i = 0; i < ListaTodosSelecionados.Count; i++)
                        {
                            for (int coluna = 0; coluna < 15; coluna++)
                            {
                                for (int arrayM = buscaF; arrayM < Fibonacci.Length; arrayM++)
                                {
                                    if (Fibonacci[arrayM] > ArrayJogosCombinacao[ListaTodosSelecionados[i], coluna])
                                    {
                                        arrayM = Fibonacci.Length;
                                    }
                                    else
                                    {
                                        if (ArrayJogosCombinacao[ListaTodosSelecionados[i], coluna] == Fibonacci[arrayM])
                                        {
                                            cont++;
                                            buscaF = arrayM + 1;
                                            arrayM = Fibonacci.Length;
                                        }
                                    }
                                }
                            }
                            if (cont == Fibonnacci) //&& (MinimoElemento <= quantidade) && (quantidade <= maximoElemento))
                            {
                                ListaCombinacoes.Add(ListaTodosSelecionados[i]);
                            }
                            cont = 0;
                            buscaF = 0;                                    
                        }
                        ativado = true;
                    }
                    else
                    {
                        if (ListaCombinacoes.Count > 0)
                        {
                            for (int posicao = 0; posicao < ListaCombinacoes.Count; posicao++)
                            {
                                for (int coluna = 0; coluna < 15; coluna++)
                                {
                                    for (int arrayM = buscaF; arrayM < Fibonacci.Length; arrayM++)
                                    {
                                        if (Fibonacci[arrayM] > ArrayJogosCombinacao[ListaCombinacoes[posicao], coluna])
                                        {
                                            arrayM = Fibonacci.Length;
                                        }
                                        else
                                        {
                                            if (ArrayJogosCombinacao[ListaCombinacoes[posicao], coluna] == Fibonacci[arrayM])
                                            {
                                                cont++;
                                                buscaF = arrayM + 1;
                                                arrayM = Fibonacci.Length;
                                            }
                                        }
                                    }
                                }
                                if (cont != Fibonnacci) //&& (MinimoElemento <= quantidade) && (quantidade <= maximoElemento))
                                {
                                    ListaCombinacoes.RemoveAt(posicao);
                                    --posicao;
                                }
                                cont = 0;
                                buscaF = 0;                                                        
                            }
                        }
                    }                    
                }//FIM
                if (checkBoxMultiploDe3.Checked == true)//MULT DE 3
                {
                    int cont = 0;
                    int Mult = 0;
                    int buscaM3 = 0;
                    int[] ArrayMult = new int[] { 3, 6, 9, 12, 15, 18, 21, 24 };

                    if (M3 == 1) { Mult = 5; }
                    if (M3 == 2) { Mult = 4; }
                    if (M3 == 3) { Mult = 6; }
                    if (M3 == 4) { Mult = 3; }
                    if (M3 == 5) { Mult = 7; }
                    if (M3 == 6) { Mult = 2; }
                    if (M3 == 7) { Mult = 8; }

                    if(ativado == false)
                    {
                        for (int i = 0; i < ListaTodosSelecionados.Count; i++)
                        {
                            for (int coluna = 0; coluna < 15; coluna++)
                            {
                                for (int arrayM = buscaM3; arrayM < ArrayMult.Length; arrayM++)
                                {
                                    if (ArrayMult[arrayM] > ArrayJogosCombinacao[ListaTodosSelecionados[i], coluna])
                                    {
                                        arrayM = ArrayMult.Length;
                                    }
                                    else
                                    {
                                        if (ArrayJogosCombinacao[ListaTodosSelecionados[i], coluna] == ArrayMult[arrayM])
                                        {
                                            cont++;
                                            ContBusca = arrayM + 1;
                                            arrayM = ArrayMult.Length;
                                        }
                                    }
                                }
                            }
                            if (cont == Mult)
                            {
                                ListaCombinacoes.Add(ListaTodosSelecionados[i]);
                            }
                            cont = 0;
                            buscaM3 = 0;                                   
                        }
                        ativado = true;
                    }
                    else
                    {
                        if (ListaCombinacoes.Count > 0)
                        {
                            for (int posicao = 0; posicao < ListaCombinacoes.Count; posicao++)
                            {
                                for (int coluna = 0; coluna < 15; coluna++)
                                {
                                    for (int arrayM = buscaM3; arrayM < ArrayMult.Length; arrayM++)
                                    {
                                        if (ArrayMult[arrayM] > ArrayJogosCombinacao[ListaCombinacoes[posicao], coluna])
                                        {
                                            arrayM = ArrayMult.Length;
                                        }
                                        else
                                        {
                                            if (ArrayJogosCombinacao[ListaCombinacoes[posicao], coluna] == ArrayMult[arrayM])
                                            {
                                                cont++;
                                                ContBusca = arrayM + 1;
                                                arrayM = ArrayMult.Length;
                                            }
                                        }
                                    }
                                }
                                if (cont != Mult)
                                {
                                    ListaCombinacoes.RemoveAt(posicao);
                                    --posicao;
                                }
                                cont = 0;
                                buscaM3 = 0;                                                          
                            }
                        }
                    }                
                }
                if (ListaCombinacoes.Count == 0)
                {
                    Console.WriteLine("\n  Nem uma Combinação encotrado! \n");
                }
                else if (ListaCombinacoes.Count > 0)
                {
                    for (int linha = 0; linha < ListaCombinacoes.Count; linha++)
                    {
                        dataGridViewCombinacoesEscolhidas.Rows[dataGridViewCombinacoesEscolhidas.Rows.Count - 1].Cells[0].Value = dataGridViewCombinacoesEscolhidas.Rows.Count;
                        dataGridViewCombinacoesEscolhidas.Rows[dataGridViewCombinacoesEscolhidas.Rows.Count - 1].Cells[1].Value = Convert.ToString(ListaCombinacoes[linha]);
                        for (int coluna = 0; coluna < 15; coluna++)
                        {
                            dataGridViewCombinacoesEscolhidas.Rows[dataGridViewCombinacoesEscolhidas.Rows.Count - 1].Cells[coluna + 2].Value = Convert.ToString(ArrayJogosCombinacao[ListaCombinacoes[linha], coluna]);
                        }
                        dataGridViewCombinacoesEscolhidas.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally { Console.WriteLine(" \n Combinação : " + ListaCombinacoes.Count + " \n");}
        }

        public void InicioEFim(int inicio, int fim)
        {
            try
            {
                Console.WriteLine(" Começo!" + "\n");
                Boolean Valido = false;
                int quantidade = 0;

                int linha = 1;

                for (int i = 0; i < int.Parse(ArrayJogosCombinacao.GetLength(0).ToString()); i++)
                {
                    if (ArrayJogosCombinacao[i, 0] == 0)
                    {
                        i = int.Parse(ArrayJogosCombinacao.GetLength(0).ToString());
                    }
                    else
                    {
                        if (checkBoxAtivado.Checked == true)
                        {
                            if(( inicio != 0) && (fim == 0)) 
                            {
                                if (inicio == ArrayJogosCombinacao[i, 0])
                                {
                                    Valido = true;
                                }
                            }
                            if ((inicio != 0) && (fim != 0))
                            {
                                if ((inicio == ArrayJogosCombinacao[i, 0]) && (fim == ArrayJogosCombinacao[i, 14]))
                                {
                                    Valido = true;
                                }
                            }
                            if ((inicio == 0) && (fim != 0)) 
                            {
                                if (fim == ArrayJogosCombinacao[i, 14])
                                {
                                    Valido = true;
                                }
                            }                          
                            for (int coluna = 0; coluna < 15; coluna++)
                            {
                                for (int e = 0; e < ArrayResultadoSobra.Length; e++)
                                {
                                    if (ArrayJogosCombinacao[i, coluna] == ArrayResultadoSobra[e])
                                    {
                                        e = ArrayResultadoSobra.Length;
                                        quantidade++;
                                    }
                                    else
                                    {
                                        if (ArrayResultadoSobra[e] > ArrayJogosCombinacao[i, coluna])
                                        {
                                            e = ArrayResultadoSobra.Length;
                                        }
                                    }
                                }
                            }
                            if ((Valido == true) && (MinimoElemento <= quantidade) && (quantidade <= maximoElemento))
                            {
                                linha++;
                             
                                dataGridViewSelecionado.Rows[dataGridViewSelecionado.Rows.Count - 1].Cells[0].Value = dataGridViewSelecionado.Rows.Count;
                                for (int coluna = 0; coluna < dataGridViewSelecionado.Columns.Count; coluna++)
                                {
                                    if (coluna < 15)
                                    {
                                        dataGridViewSelecionado.Rows[dataGridViewSelecionado.Rows.Count - 1].Cells[coluna + 1].Value = ArrayJogosCombinacao[i, coluna];
                                    }
                                }
                                dataGridViewSelecionado.Rows.Add("","", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                            }
                            Valido = false;
                            quantidade = 0;
                        }
                        else
                        {
                            if ((inicio != 0) && (fim == 0))
                            {
                                if (inicio == ArrayJogosCombinacao[i, 0])
                                {
                                    Valido = true;
                                }
                            }
                            if ((inicio != 0) && (fim != 0))
                            {
                                if ((inicio == ArrayJogosCombinacao[i, 0]) && (fim == ArrayJogosCombinacao[i, 14]))
                                {
                                    Valido = true;
                                }
                            }
                            if ((inicio == 0) && (fim != 0))
                            {
                                if (fim == ArrayJogosCombinacao[i, 14])
                                {
                                    Valido = true;
                                }
                            }
                            if (Valido == true)
                            {
                                dataGridViewSelecionado.Rows[dataGridViewSelecionado.Rows.Count - 1].Cells[0].Value = dataGridViewSelecionado.Rows.Count;
                                for (int coluna = 0; coluna < dataGridViewSelecionado.Columns.Count; coluna++)
                                {
                                    if (coluna < 15)
                                    {
                                        dataGridViewSelecionado.Rows[dataGridViewSelecionado.Rows.Count - 1].Cells[coluna + 1].Value = ArrayJogosCombinacao[i, coluna];
                                    }
                                }
                                dataGridViewSelecionado.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                            }
                        }
                        Valido = false;
                        quantidade = 0;
                    }
                }
            }
            catch (Exception err)
            {
                err.ToString();
            }
            finally { Console.WriteLine(" \n Inici e Fim \n"); }
        }
        public void ParesEImpares(int NumeroCombinacaoPares)
        {
            try
            {
                Console.WriteLine(" Começo!" + "\n");
                int par = 0, impar = 0;
                int cont = 0, cont2 = 0;
                int quantidade = 0;

                int linha = 1;
                if (NumeroCombinacaoPares == 1) { par = 7; impar = 8; }
                if (NumeroCombinacaoPares == 2) { par = 8; impar = 7; }
                if (NumeroCombinacaoPares == 3) { par = 6; impar = 9; }
                if (NumeroCombinacaoPares == 4) { par = 9; impar = 6; }
                if (NumeroCombinacaoPares == 5) { par = 5; impar = 10; }
                if (NumeroCombinacaoPares == 6) { par = 10; impar = 5; }
                if (NumeroCombinacaoPares == 7) { par = 4; impar = 11; }
                if (NumeroCombinacaoPares == 8) { par = 11; impar = 4; }
                if (NumeroCombinacaoPares == 9) { par = 3; impar = 12; }
                if (NumeroCombinacaoPares == 10) { par = 12; impar = 3; }
                if (NumeroCombinacaoPares == 11) { par = 2; impar = 13; }

                for (int i = 0; i < int.Parse(ArrayJogosCombinacao.GetLength(0).ToString()); i++)
                {
                    if (ArrayJogosCombinacao[i, 0] == 0)
                    {
                        i = int.Parse(ArrayJogosCombinacao.GetLength(0).ToString());
                    }
                    else
                    {
                        if (checkBoxAtivado.Checked == true)
                        {
                            for (int coluna = 0; coluna < 15; coluna++)
                            {
                                if (ArrayJogosCombinacao[i, coluna] % 2 == 0)
                                {   //par
                                    cont++;
                                }
                                else
                                {   //impar
                                    cont2++;
                                }
                            }
                            for (int coluna = 0; coluna < 15; coluna++)
                            {
                                for (int e = 0; e < ArrayResultadoSobra.Length; e++)
                                {
                                    if (ArrayJogosCombinacao[i, coluna] == ArrayResultadoSobra[e])
                                    {
                                        e = ArrayResultadoSobra.Length;
                                        quantidade++;
                                    }
                                    else
                                    {
                                        if (ArrayResultadoSobra[e] > ArrayJogosCombinacao[i, coluna])
                                        {
                                            e = ArrayResultadoSobra.Length;
                                        }
                                    }
                                }
                            }
                            if ((par == cont) && (impar == cont2) && (MinimoElemento <= quantidade) && (quantidade <= maximoElemento))
                            {
                                Console.WriteLine(" linha: " + i + " quantidade: " + linha);
                                linha++;
                                dataGridViewSelecionado.Rows[dataGridViewSelecionado.Rows.Count - 1].Cells[0].Value = dataGridViewSelecionado.Rows.Count;
                                for (int coluna = 0; coluna < dataGridViewSelecionado.Columns.Count; coluna++)
                                {
                                    if (coluna < 15)
                                    {
                                        dataGridViewSelecionado.Rows[dataGridViewSelecionado.Rows.Count - 1].Cells[coluna + 1].Value = ArrayJogosCombinacao[i, coluna];
                                    }
                                }
                                dataGridViewSelecionado.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                            }
                            cont = 0; cont2 = 0;
                            quantidade = 0;
                        }
                        else
                        {
                            for (int coluna = 0; coluna < 15; coluna++)
                            {
                                if (ArrayJogosCombinacao[i, coluna] % 2 == 0)
                                {   //par
                                    cont++;
                                }
                                else
                                {   //impar
                                    cont2++;
                                }
                            }
                            if ((par == cont) && (impar == cont2))
                            {
                                // linha-1    linha = dataGridViewSelecionado.Rows.Count;
                                dataGridViewSelecionado.Rows[dataGridViewSelecionado.Rows.Count - 1].Cells[0].Value = dataGridViewSelecionado.Rows.Count;
                                for (int coluna = 0; coluna < dataGridViewSelecionado.Columns.Count; coluna++)
                                {
                                    if (coluna < 15)
                                    {
                                        dataGridViewSelecionado.Rows[dataGridViewSelecionado.Rows.Count - 1].Cells[coluna + 1].Value = ArrayJogosCombinacao[i, coluna];
                                    }
                                }
                                dataGridViewSelecionado.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                            }
                        }
                        cont = 0; cont2 = 0;
                        quantidade = 0;
                    }
                }
            }
            catch (Exception err)
            {
                err.ToString();
            }
            finally { Console.WriteLine(" \n ParesEImpares \n"); }
        }
        public void RepetidosNumeros(int Repetidos)
        {
            try
            {
                int cont = 0;
                int repeticao = 0;
 
                if (Repetidos == 1) { repeticao = 9; }
                if (Repetidos == 2) { repeticao = 8; }
                if (Repetidos == 3) { repeticao = 10; }
                if (Repetidos == 4) { repeticao = 7; }
                if (Repetidos == 5) { repeticao = 11; }
                if (Repetidos == 6) { repeticao = 12; }
                if (Repetidos == 7) { repeticao = 6; }
                if (Repetidos == 8) { repeticao = 13; }
                if (Repetidos == 9) { repeticao = 14; }
                if (Repetidos == 10) { repeticao = 15; }

                for (int i = 0; i < int.Parse(ArrayJogosCombinacao.GetLength(0).ToString()); i++)
                {
                    if (ArrayJogosCombinacao[i, 0] == 0)
                    {
                        i = int.Parse(ArrayJogosCombinacao.GetLength(0).ToString());
                    }
                    else
                    {
                        if (checkBoxAtivado.Checked == true)
                        {
                            for (int coluna = 0; coluna < 15; coluna++)
                            {
                                for (int arrayM = 0; arrayM < ArrayRepetidos.Length; arrayM++)
                                {
                                    if (ArrayJogosCombinacao[i, coluna] == ArrayRepetidos[arrayM]) { cont++; }

                                }
                            }
                            for (int coluna = 0; coluna < 15; coluna++)
                            {
                                for (int e = 0; e < ArrayResultadoSobra.Length; e++)
                                {
                                    if (ArrayJogosCombinacao[i, coluna] == ArrayResultadoSobra[e])
                                    {
                                        e = ArrayResultadoSobra.Length;
                                        quantidade++;
                                    }
                                    else
                                    {
                                        if (ArrayResultadoSobra[e] > ArrayJogosCombinacao[i, coluna])
                                        {
                                            e = ArrayResultadoSobra.Length;
                                        }
                                    }
                                }
                            }
                            if (cont == repeticao && (MinimoElemento <= quantidade) && (quantidade <= maximoElemento))
                            {
                                dataGridViewSelecionado.Rows[dataGridViewSelecionado.Rows.Count - 1].Cells[0].Value = dataGridViewSelecionado.Rows.Count;
                                for (int coluna = 0; coluna < dataGridViewSelecionado.Columns.Count; coluna++)
                                {
                                    if (coluna < 15)
                                    {
                                        dataGridViewSelecionado.Rows[dataGridViewSelecionado.Rows.Count - 1].Cells[coluna + 1].Value = ArrayJogosCombinacao[i, coluna];
                                    }
                                }
                                dataGridViewSelecionado.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                            }
                            cont = 0;
                            quantidade = 0;
                        }
                        else
                        {
                            for (int coluna = 0; coluna < 15; coluna++)
                            {
                                for (int arrayM = 0; arrayM < ArrayRepetidos.Length; arrayM++)
                                {
                                    if (ArrayJogosCombinacao[i, coluna] == ArrayRepetidos[arrayM]) { cont++; }
                                }
                            }
                            if (cont == repeticao)
                            {
                                dataGridViewSelecionado.Rows[dataGridViewSelecionado.Rows.Count - 1].Cells[0].Value = dataGridViewSelecionado.Rows.Count;
                                for (int coluna = 0; coluna < dataGridViewSelecionado.Columns.Count; coluna++)
                                {
                                    if (coluna < 15)
                                    {
                                        dataGridViewSelecionado.Rows[dataGridViewSelecionado.Rows.Count - 1].Cells[coluna + 1].Value = ArrayJogosCombinacao[i, coluna];
                                    }
                                }
                                dataGridViewSelecionado.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                            }
                            cont = 0;
                        }
                    }
                }
            }
            catch (Exception err)
            {
                err.ToString();
            }
            finally { Console.WriteLine(" \n Numeros Repetidos \n"); }
        }

        public void ModulaNumeros(int NumerosModura)
        {
            try
            {
                int cont = 0;
                int modula = 0;
                int[] ArrayMoldura = new int[] { 1, 2, 3, 4, 5, 6, 10, 11, 15, 16, 20, 21, 22, 23, 24, 25 };

                if (NumerosModura == 1) { modula = 10; }
                if (NumerosModura == 2) { modula = 9; }
                if (NumerosModura == 3) { modula = 11; }
                if (NumerosModura == 4) { modula = 8; }
                if (NumerosModura == 5) { modula = 12; }
                if (NumerosModura == 6) { modula = 7; }
                if (NumerosModura == 7) { modula = 13; }
                if (NumerosModura == 8) { modula = 6; }
                if (NumerosModura == 9) { modula = 14; }
                if (NumerosModura == 10) { modula = 15; }

                for (int i = 0; i < int.Parse(ArrayJogosCombinacao.GetLength(0).ToString()); i++)
                {
                    if (ArrayJogosCombinacao[i, 0] == 0)
                    {
                        i = int.Parse(ArrayJogosCombinacao.GetLength(0).ToString());
                    }
                    else
                    {
                        if (checkBoxAtivado.Checked == true)
                        {
                            for (int coluna = 0; coluna < 15; coluna++)
                            {
                                for (int arrayM = 0; arrayM < ArrayMoldura.Length; arrayM++)
                                {
                                    if (ArrayJogosCombinacao[i, coluna] == ArrayMoldura[arrayM]) { cont++; }

                                }
                            }
                            for (int coluna = 0; coluna < 15; coluna++)
                            {
                                for (int e = 0; e < ArrayResultadoSobra.Length; e++)
                                {
                                    if (ArrayJogosCombinacao[i, coluna] == ArrayResultadoSobra[e])
                                    {
                                        e = ArrayResultadoSobra.Length;
                                        quantidade++;
                                    }
                                    else
                                    {
                                        if (ArrayResultadoSobra[e] > ArrayJogosCombinacao[i, coluna])
                                        {
                                            e = ArrayResultadoSobra.Length;
                                        }
                                    }
                                }
                            }
                            if (cont == modula && (MinimoElemento <= quantidade) && (quantidade <= maximoElemento))
                            {
                                //linha -1  ; linha = dataGridViewSelecionado.Rows.Count;
                                dataGridViewSelecionado.Rows[dataGridViewSelecionado.Rows.Count - 1].Cells[0].Value = dataGridViewSelecionado.Rows.Count;
                                for (int coluna = 0; coluna < dataGridViewSelecionado.Columns.Count; coluna++)
                                {
                                    if (coluna < 15)
                                    {
                                        dataGridViewSelecionado.Rows[dataGridViewSelecionado.Rows.Count - 1].Cells[coluna + 1].Value = ArrayJogosCombinacao[i, coluna];
                                    }
                                }
                                dataGridViewSelecionado.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                            }
                            cont = 0;
                        }
                        else
                        {
                            for (int coluna = 0; coluna < 15; coluna++)
                            {
                                for (int arrayM = 0; arrayM < ArrayMoldura.Length; arrayM++)
                                {
                                    if (ArrayJogosCombinacao[i, coluna] == ArrayMoldura[arrayM]) { cont++; }
                                }
                            }
                            if (cont == modula)
                            {
                                dataGridViewSelecionado.Rows[dataGridViewSelecionado.Rows.Count - 1].Cells[0].Value = dataGridViewSelecionado.Rows.Count;
                                for (int coluna = 0; coluna < dataGridViewSelecionado.Columns.Count; coluna++)
                                {
                                    if (coluna < 15)
                                    {
                                        dataGridViewSelecionado.Rows[dataGridViewSelecionado.Rows.Count - 1].Cells[coluna + 1].Value = ArrayJogosCombinacao[i, coluna];
                                    }
                                }
                                dataGridViewSelecionado.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                            }
                            cont = 0;
                        }
                    }
                }
            }
            catch (Exception err)
            {
                err.ToString();
            }
            finally { Console.WriteLine(" \n Modula \n"); }
        }
        public void NumerosPrimos(int NumerosPrimos)
        {
            try
            {
                int cont = 0;
                int primos = 0;
                int[] ArrayPrimos = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23 };

                if (NumerosPrimos == 1) { primos = 5; }
                if (NumerosPrimos == 2) { primos = 6; }
                if (NumerosPrimos == 3) { primos = 4; }
                if (NumerosPrimos == 4) { primos = 7; }
                if (NumerosPrimos == 5) { primos = 3; }
                if (NumerosPrimos == 6) { primos = 8; }
                if (NumerosPrimos == 7) { primos = 2; }
                if (NumerosPrimos == 8) { primos = 9; }
                if (NumerosPrimos == 9) { primos = 1; }
                if (NumerosPrimos == 10) { primos = 0; }

                for (int i = 0; i < int.Parse(ArrayJogosCombinacao.GetLength(0).ToString()); i++)
                {
                    if (ArrayJogosCombinacao[i, 0] == 0)
                    {
                        i = int.Parse(ArrayJogosCombinacao.GetLength(0).ToString());
                    }
                    else
                    {
                        if (checkBoxAtivado.Checked == true)
                        {
                            for (int coluna = 0; coluna < 15; coluna++)
                            {
                                for (int arrayM = 0; arrayM < ArrayPrimos.Length; arrayM++)
                                {
                                    if (ArrayJogosCombinacao[i, coluna] == ArrayPrimos[arrayM]) { cont++; }

                                }
                            }
                            for (int coluna = 0; coluna < 15; coluna++)
                            {
                                for (int e = 0; e < ArrayResultadoSobra.Length; e++)
                                {
                                    if (ArrayJogosCombinacao[i, coluna] == ArrayResultadoSobra[e])
                                    {
                                        e = ArrayResultadoSobra.Length;
                                        quantidade++;
                                    }
                                    else
                                    {
                                        if (ArrayResultadoSobra[e] > ArrayJogosCombinacao[i, coluna])
                                        {
                                            e = ArrayResultadoSobra.Length;
                                        }
                                    }
                                }
                            }
                            if (cont == primos && (MinimoElemento <= quantidade) && (quantidade <= maximoElemento))
                            {
                                //linha -1  ; linha = dataGridViewSelecionado.Rows.Count;
                                dataGridViewSelecionado.Rows[dataGridViewSelecionado.Rows.Count - 1].Cells[0].Value = dataGridViewSelecionado.Rows.Count;
                                for (int coluna = 0; coluna < dataGridViewSelecionado.Columns.Count; coluna++)
                                {
                                    if (coluna < 15)
                                    {
                                        dataGridViewSelecionado.Rows[dataGridViewSelecionado.Rows.Count - 1].Cells[coluna + 1].Value = ArrayJogosCombinacao[i, coluna];
                                    }
                                }
                                dataGridViewSelecionado.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                            }
                            cont = 0;
                        }
                        else
                        {
                            for (int coluna = 0; coluna < 15; coluna++)
                            {
                                for (int arrayM = 0; arrayM < ArrayPrimos.Length; arrayM++)
                                {
                                    if (ArrayJogosCombinacao[i, coluna] == ArrayPrimos[arrayM]) { cont++; }
                                }
                            }
                            if (cont == primos)
                            {
                                dataGridViewSelecionado.Rows[dataGridViewSelecionado.Rows.Count - 1].Cells[0].Value = dataGridViewSelecionado.Rows.Count;
                                for (int coluna = 0; coluna < dataGridViewSelecionado.Columns.Count; coluna++)
                                {
                                    if (coluna < 15)
                                    {
                                        dataGridViewSelecionado.Rows[dataGridViewSelecionado.Rows.Count - 1].Cells[coluna + 1].Value = ArrayJogosCombinacao[i, coluna];
                                    }
                                }
                                dataGridViewSelecionado.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                            }
                            cont = 0;
                        }
                    }
                }
            }
            catch (Exception err)
            {
                err.ToString();
            }
            finally { Console.WriteLine(" \n Numeros Primos \n"); }
        }
        public void NumerosFibonacci(int NumerosFibonacci)
        {
            try
            {
                int cont = 0;
                int Fibonnacci = 0;
                int[] Fibonacci = new int[] { 1, 2, 3, 5, 8, 13, 21 };

                if (NumerosFibonacci == 1) { Fibonnacci = 4; }
                if (NumerosFibonacci == 2) { Fibonnacci = 5; }
                if (NumerosFibonacci == 3) { Fibonnacci = 3; }
                if (NumerosFibonacci == 4) { Fibonnacci = 6; }
                if (NumerosFibonacci == 5) { Fibonnacci = 2; }
                if (NumerosFibonacci == 6) { Fibonnacci = 7; }
                if (NumerosFibonacci == 7) { Fibonnacci = 1; }
                if (NumerosFibonacci == 8) { Fibonnacci = 0; }

                for (int i = 0; i < int.Parse(ArrayJogosCombinacao.GetLength(0).ToString()); i++)
                {
                    if (ArrayJogosCombinacao[i, 0] == 0)
                    {
                        i = int.Parse(ArrayJogosCombinacao.GetLength(0).ToString());
                    }
                    else
                    {
                        if (checkBoxAtivado.Checked == true)
                        {
                            for (int coluna = 0; coluna < 15; coluna++)
                            {
                                for (int arrayF = 0; arrayF < Fibonacci.Length; arrayF++)
                                {
                                    if (ArrayJogosCombinacao[i, coluna] == Fibonacci[arrayF]) { cont++; }

                                }
                            }
                            for (int coluna = 0; coluna < 15; coluna++)
                            {
                                for (int e = 0; e < ArrayResultadoSobra.Length; e++)
                                {
                                    if (ArrayJogosCombinacao[i, coluna] == ArrayResultadoSobra[e])
                                    {
                                        e = ArrayResultadoSobra.Length;
                                        quantidade++;
                                    }
                                    else
                                    {
                                        if (ArrayResultadoSobra[e] > ArrayJogosCombinacao[i, coluna])
                                        {
                                            e = ArrayResultadoSobra.Length;
                                        }
                                    }
                                }
                            }
                            //Console.WriteLine("Linha: " + (i + 1) + " quant: " + cont + "\n");
                            if (cont == Fibonnacci && (MinimoElemento <= quantidade) && (quantidade <= maximoElemento))
                            {
                                //linha -1  ; linha = dataGridViewSelecionado.Rows.Count;
                                dataGridViewSelecionado.Rows[dataGridViewSelecionado.Rows.Count - 1].Cells[0].Value = dataGridViewSelecionado.Rows.Count;
                                for (int coluna = 0; coluna < dataGridViewSelecionado.Columns.Count; coluna++)
                                {
                                    if (coluna < 15)
                                    {
                                        dataGridViewSelecionado.Rows[dataGridViewSelecionado.Rows.Count - 1].Cells[coluna + 1].Value = ArrayJogosCombinacao[i, coluna];
                                    }
                                }
                                dataGridViewSelecionado.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                            }
                            cont = 0;
                        }
                        else
                        {
                            for (int coluna = 0; coluna < 15; coluna++)
                            {
                                for (int arrayM = 0; arrayM < Fibonacci.Length; arrayM++)
                                {
                                    if (ArrayJogosCombinacao[i, coluna] == Fibonacci[arrayM]) { cont++; }
                                }
                            }
                            if (cont == Fibonnacci)
                            {
                                dataGridViewSelecionado.Rows[dataGridViewSelecionado.Rows.Count - 1].Cells[0].Value = dataGridViewSelecionado.Rows.Count;
                                for (int coluna = 0; coluna < dataGridViewSelecionado.Columns.Count; coluna++)
                                {
                                    if (coluna < 15)
                                    {
                                        dataGridViewSelecionado.Rows[dataGridViewSelecionado.Rows.Count - 1].Cells[coluna + 1].Value = ArrayJogosCombinacao[i, coluna];
                                    }
                                }
                                dataGridViewSelecionado.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                            }
                            cont = 0;
                        }
                    }
                }
            }
            catch (Exception err)
            {
                err.ToString();
            }
            finally { Console.WriteLine(" \n Numeros Fibonacci \n"); }
        }
        public void NumerosMult(int NumerosMult)
        {
            try
            {
                int cont = 0;
                int Mult = 0;
                int[] ArrayMult = new int[] { 3, 6, 9, 12, 15, 18, 21, 24 };

                if (NumerosMult == 1) { Mult = 5; }
                if (NumerosMult == 2) { Mult = 4; }
                if (NumerosMult == 3) { Mult = 6; }
                if (NumerosMult == 4) { Mult = 3; }
                if (NumerosMult == 5) { Mult = 7; }
                if (NumerosMult == 6) { Mult = 2; }
                if (NumerosMult == 7) { Mult = 8; }

                for (int i = 0; i < int.Parse(ArrayJogosCombinacao.GetLength(0).ToString()); i++)
                {
                    if (ArrayJogosCombinacao[i, 0] == 0)
                    {
                        i = int.Parse(ArrayJogosCombinacao.GetLength(0).ToString());
                    }
                    else
                    {
                        if (checkBoxAtivado.Checked == true)
                        {
                            for (int coluna = 0; coluna < 15; coluna++)
                            {
                                for (int arrayM = 0; arrayM < ArrayMult.Length; arrayM++)
                                {
                                    if (ArrayJogosCombinacao[i, coluna] == ArrayMult[arrayM]) { cont++; }
                                }
                            }
                            for (int coluna = 0; coluna < 15; coluna++)
                            {
                                for (int e = 0; e < ArrayResultadoSobra.Length; e++)
                                {
                                    if (ArrayJogosCombinacao[i, coluna] == ArrayResultadoSobra[e])
                                    {
                                        e = ArrayResultadoSobra.Length;
                                        quantidade++;
                                    }
                                    else
                                    {
                                        if (ArrayResultadoSobra[e] > ArrayJogosCombinacao[i, coluna])
                                        {
                                            e = ArrayResultadoSobra.Length;
                                        }
                                    }
                                }
                            }
                            if (cont == Mult && (MinimoElemento <= quantidade) && (quantidade <= maximoElemento))
                            {
                                dataGridViewSelecionado.Rows[dataGridViewSelecionado.Rows.Count - 1].Cells[0].Value = dataGridViewSelecionado.Rows.Count;
                                for (int coluna = 0; coluna < dataGridViewSelecionado.Columns.Count; coluna++)
                                {
                                    if (coluna < 15)
                                    {
                                        dataGridViewSelecionado.Rows[dataGridViewSelecionado.Rows.Count - 1].Cells[coluna + 1].Value = ArrayJogosCombinacao[i, coluna];
                                    }
                                }
                                dataGridViewSelecionado.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                            }
                            cont = 0;
                        }
                        else
                        {
                            for (int coluna = 0; coluna < 15; coluna++)
                            {
                                for (int arrayM = 0; arrayM < ArrayMult.Length; arrayM++)
                                {
                                    if (ArrayJogosCombinacao[i, coluna] == ArrayMult[arrayM]) { cont++; }
                                }
                            }
                        }
                        if (cont == Mult)
                        {
                            dataGridViewSelecionado.Rows[dataGridViewSelecionado.Rows.Count - 1].Cells[0].Value = dataGridViewSelecionado.Rows.Count;
                            for (int coluna = 0; coluna < dataGridViewSelecionado.Columns.Count; coluna++)
                            {
                                if (coluna < 15)
                                {
                                    dataGridViewSelecionado.Rows[dataGridViewSelecionado.Rows.Count - 1].Cells[coluna + 1].Value = ArrayJogosCombinacao[i, coluna];
                                }
                            }
                            dataGridViewSelecionado.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                        }
                        cont = 0;
                    }
                }
            }
            catch (Exception err)
            {
                err.ToString();
            }
            finally { Console.WriteLine(" \n Numeros Mult 3 \n"); }
        }
        public void OrganizarArray()
        {
            try
            {
                for (int i = 0; i < ArrayJogosCombinacao.GetLength(0); i++)
                {
                    for (int j = ArrayJogosCombinacao.GetLength(1) - 1; j > 0; j--)
                    {
                        for (int k = 0; k < j; k++)
                        {
                            if (ArrayJogosCombinacao[i, k] > ArrayJogosCombinacao[i, k + 1])
                            {
                                int myTemp = ArrayJogosCombinacao[i, k];
                                ArrayJogosCombinacao[i, k] = ArrayJogosCombinacao[i, k + 1];
                                ArrayJogosCombinacao[i, k + 1] = myTemp;
                            }
                        }
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception err)
            {
                err.ToString();
            }
        }
        public void TodosJogosCombinacoesA()
        {
            try
            {
                int quantidade = 0;
                for (int i = 0; i < int.Parse(ArrayJogosCombinacaoTamanho()); i++)
                {
                    for (int coluna = 0; coluna < 15; coluna++)
                    {
                        for (int e = 0; e < ArrayResultadoSobra.Length; e++)
                        {
                            if (ArrayJogosCombinacao[i, coluna] == ArrayResultadoSobra[e])
                            {//Quantidade
                                e = ArrayResultadoSobra.Length;
                                quantidade++;
                                //Console.WriteLine(quantidade);
                            }
                            else
                            {
                                if (ArrayResultadoSobra[e] > ArrayJogosCombinacao[i, coluna])
                                {//Quantidade
                                    e = ArrayResultadoSobra.Length;
                                }
                            }
                        }
                    }
                    if ((MinimoElemento <= quantidade) && (quantidade <= maximoElemento) && (i != 0))
                    {
                        dataGridViewSelecionado.Rows[dataGridViewSelecionado.Rows.Count - 1].Cells[0].Value = dataGridViewSelecionado.Rows.Count;
                        dataGridViewSelecionado.Rows[dataGridViewSelecionado.Rows.Count - 1].Cells[1].Value = Convert.ToString(i);

                        for (int coluna = 2; coluna < dataGridViewSelecionado.Columns.Count; coluna++)
                        {
                            if (coluna <= 16)
                            {
                                dataGridViewSelecionado.Rows[dataGridViewSelecionado.Rows.Count - 1].Cells[coluna ].Value = Convert.ToString(ArrayJogosCombinacao[i, coluna - 2]);
                            }
                        }
                        dataGridViewSelecionado.Rows.Add("","", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                    }
                    quantidade = 0;
                }
            }
            catch (Exception err)
            {
                err.ToString();
            }
        }
        public void TodosJogosCombinacoesD()
        {
            try
            {
                for (int i = 0; i < int.Parse(ArrayJogosCombinacao.GetLength(0).ToString()); i++)
                {
                    if (ArrayJogosCombinacao[i, 0] == 0)
                    {
                        i = int.Parse(ArrayJogosCombinacao.GetLength(0).ToString());
                    }
                    else
                    {
                        dataGridViewSelecionado.Rows[dataGridViewSelecionado.Rows.Count - 1].Cells[0].Value = dataGridViewSelecionado.Rows.Count;
                        dataGridViewSelecionado.Rows[dataGridViewSelecionado.Rows.Count - 1].Cells[1].Value = Convert.ToString(i);
                        for (int coluna = 0; coluna < dataGridViewSelecionado.Columns.Count; coluna++)
                        {
                            if (coluna < 15)
                            {
                                dataGridViewSelecionado.Rows[dataGridViewSelecionado.Rows.Count - 1].Cells[coluna + 2].Value = Convert.ToString(ArrayJogosCombinacao[i, coluna]);
                            }
                        }
                        dataGridViewSelecionado.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                      
                    }
                }
            }
            catch (Exception err)
            {
                err.ToString();
            }
        }
        public void ArmazenarResultadoLista()
        {
            try
            {
                if (dataGridViewSelecionado.RowCount > 2)
                {
                    ListaTodosSelecionados.Clear();

                    for (int linha = 0; linha < dataGridViewSelecionado.Rows.Count - 1; linha++)
                    {
                        ListaTodosSelecionados.Add(int.Parse(dataGridViewSelecionado.Rows[linha].Cells[1].Value.ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void buttonSelecao_Click(object sender, EventArgs e)
        {
            try
            {
                this.MinimoElemento = int.Parse(textBoxMinimoEscolha.Text);
                this.maximoElemento = int.Parse(textBoxMaximoEscolha.Text);

                if (radioButtonLivre.Checked == true)
                {
                    this.BuscaLouC = 1;
                    PesquisaModoCombinacao();
                }

                //if (radioButtonCombinacao.Checked == true)
                //{
                //    int ValidaCombinacoes = 0;
                //    this.BuscaLouC = 2;

                //    if (checkBoxPI.Checked == true)
                //    {
                //        if (comboBoxParImpar.Text == "SELECIONAR CALC") { ValidaCombinacoes = 1; }
                //    }
                //    if (checkBoxMoldura.Checked == true)
                //    {
                //        if (comboBoxMoldura.Text == "SELECIONAR CALC") { ValidaCombinacoes = 1; }
                //    }
                //    if (checkBoxPrimos.Checked == true)
                //    {
                //        if (comboBoxPrimos.Text == "SELECIONAR CALC") { ValidaCombinacoes = 1; }
                //    }
                //    if (checkBoxNumerosFibonacci.Checked == true)
                //    {
                //        if (comboBoxFibonacci.Text == "SELECIONAR CALC") { ValidaCombinacoes = 1; }
                //    }
                //    if (checkBoxMultiploDe3.Checked == true)
                //    {
                //        if (comboBoxMultiploDe3.Text == "SELECIONAR CALC") { ValidaCombinacoes = 1; }
                //    }
                //    if (checkBoxInicioEFim.Checked == true)
                //    {
                //        if ((textBoxCheboxInicio.Text == "") || (textBoxCheboxInicio.Text == "")) { ValidaCombinacoes = 1; }
                //    }
                //    if (ValidaCombinacoes == 1)
                //    {
                //        MessageBox.Show("Selecione um BUS X");
                //}
                //if (ValidaCombinacoes == 0)
                //{
                //    if (radioButtonTodosJogos.Checked == true)
                //    {
                //        PesquisaModoCombinacao();
                //    }
                //    else
                //    {
                //        //BustX();
                //    }
                //}
            }
            //}
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public void PesquisaModoCombinacao()
        {
            try
            {
                if (radioButtonLivre.Checked == true)
                {
                    EntradaValoresCriarJogoLivre();
                    EntradaValoresSobraJogo();
                    ArrayRepetidasForm();
                    OrganizarArrayLista();

                    ArrayRepetidos = new int[ElementosListaRepetidos.Count];
                    for (int coluna = 0; coluna < ArrayRepetidos.Length; coluna++)
                    {
                        ArrayRepetidos[coluna] = ElementosListaRepetidos[coluna];
                    }
                    ElementosCombinacoes = new int[15];
                    quantidade = 15;
            
                    ArrayJogosCombinacao = new int[combinacoes((ElementosListaSobra.Count + ElementosListaRepetidos.Count), 15) + 1, 15];

                    busca(0, (ElementosListaCriar.Count - 15), 0);

                    //ArrayJogosCombinacao = new int[(ElementosListaCriar.Count, 15) + 5, 15];
                }
                if (radioButtonTodosJogos.Checked == true)
                {                
                    if(checkBoxAtivado.Checked == true)
                    {
                        TodosJogosCombinacoesA();
                    }
                    else
                    {
                        TodosJogosCombinacoesD();
                    }
                    ArmazenarResultadoLista();

                    label37.Text = "QUANT: " + Convert.ToString(dataGridViewSelecionado.Rows.Count - 1);
                    label38.Text = "TOTAL: " + this.count;
                }

                //if (radioButtonTodosJogos.Checked == true)
                //{
                //    Console.WriteLine("Combinação: " + combinacoes((ElementosListaSobra.Count + ElementosListaRepetidos.Count), 15));


                //string temp = "";
                //for (int linha = 0; linha < int.Parse(ArraySelecionadoTamanho()); linha++)
                //{
                //    for (int coluna = 0; coluna < 16; coluna++)
                //    {
                //        temp = temp + ArraySelecionado[linha, coluna].ToString() + ",";
                //    }
                //    Console.WriteLine((linha + 1) + ": " + temp);
                //    temp = "";
                //}
            //}

                //if (radioButtonParImpar.Checked == true)
                //{
                //    if (this.CombinacaoParesImparIndex != 0)
                //    {
                //        ParesEImpares(CombinacaoParesImparIndex);
                //        label37.Text = "QUANT: " + Convert.ToString(dataGridViewSelecionado.Rows.Count - 1);
                //        label38.Text = "TOTAL: " + this.count;
                //    }
                //    else { MessageBox.Show("Sem informação de busca!"); }
                //}
                //if (radioButtonNumeroRepetidas.Checked == true)
                //{
                //    if (this.NumeroRepetidas != 0)
                //    {
                //        RepetidosNumeros(NumeroRepetidas);
                //        label37.Text = "QUANT: " + Convert.ToString(dataGridViewSelecionado.Rows.Count - 1);
                //        label38.Text = "TOTAL: " + this.count;
                //    }
                //    else { MessageBox.Show("Sem informação de busca!"); }
                //}
                //if (radioButtonMoldura.Checked == true)
                //{
                //    if (this.NumeroModula != 0)
                //    {
                //        ModulaNumeros(NumeroModula);
                //        label37.Text = "QUANT: " + Convert.ToString(dataGridViewSelecionado.Rows.Count - 1);
                //        label38.Text = "TOTAL: " + this.count;
                //    }
                //    else { MessageBox.Show("Sem informação de busca!"); }
                //}
                //if (radioButtonPrimos.Checked == true)
                //{
                //    if (this.NumeroPrimos != 0)
                //    {
                //        NumerosPrimos(NumeroPrimos);
                //        label37.Text = "QUANT: " + Convert.ToString(dataGridViewSelecionado.Rows.Count - 1);
                //        label38.Text = "TOTAL: " + this.count;
                //    }
                //    else { MessageBox.Show("Sem informação de busca!"); }
                //}
                //if (radioButtonFibonacci.Checked == true)
                //{
                //    if (this.NumeroFibonacci != 0)
                //    {
                //        NumerosFibonacci(NumeroFibonacci);
                //        label37.Text = "QUANT: " + Convert.ToString(dataGridViewSelecionado.Rows.Count - 1);
                //        label38.Text = "TOTAL: " + this.count;
                //    }
                //    else { MessageBox.Show("Sem informação de busca!"); }
                //}
                //if (radioButtonMultiploDe3.Checked == true)
                //{
                //    if (this.NumeroMultiploDe3 != 0)
                //    {
                //        NumerosMult(NumeroMultiploDe3);
                //        label37.Text = "QUANT: " + Convert.ToString(dataGridViewSelecionado.Rows.Count - 1);
                //        label38.Text = "TOTAL: " + this.count;
                //    }
                //    else { MessageBox.Show("Sem informação de busca!"); }
                //}
                //if (checkBoxInicioEFim.Checked == true)
                //{
                //    if ((textBoxCheboxInicio.Text != "") && (textBoxCheboxFim.Text != ""))
                //    {
                //        InicioEFim(int.Parse(textBoxCheboxInicio.Text), int.Parse(textBoxCheboxFim.Text));
                //        label37.Text = "QUANT: " + Convert.ToString(dataGridViewSelecionado.Rows.Count - 1);
                //        label38.Text = "TOTAL: " + this.count;
                //    }
                //    else { MessageBox.Show("Sem informação de busca!"); }
                //}
                //if (radioButtonCombinacao.Checked == true)
                //{
                //    EntradaValoresCriarJogo();
                //    EntradaValoresSobraJogo();

            //    this.QuantidadeNumeros = ElementosListaCriar.Count;
            //    this.QuantNumerosInicio = 15 - ElementosListaSobra.Count;
            //    this.quantidade = QuantNumerosInicio;
            //    busca(0, (QuantidadeNumeros - QuantNumerosInicio), 0);

            //    OrganizarArray();
            //}
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public void busca(int inicio, int fim, int profundidade)
        {
            try
            {
                if ((profundidade + 1) >= quantidade)
                {
                    for (int x = inicio; x <= fim; x++)
                    {
                        ElementosCombinacoes[profundidade] = ElementosListaCriar[x];

                        if (radioButtonLivre.Checked == true)
                        {
                            //adicionar Array de ElementosCombinacoes
                            for (int coluna = 0; coluna < 15; coluna++)
                            {
                                //Coluna Adicionar
                                ArrayJogosCombinacao[count, coluna] = ElementosCombinacoes[coluna];
                            }
                            count++;
                        }
                        else //(radioButtonCombinacao.Checked == true)
                        {
                            //adicionar Array de ElementosCombinacoes
                            for (int coluna = 0; coluna < QuantNumerosInicio; coluna++)
                            {
                                //Coluna Adicionar
                                ArrayJogosCombinacao[count, coluna] = ElementosCombinacoes[coluna];
                            }
                            ////adicionar Array de Sobras
                            for (int coluna = 0; coluna < ElementosListaSobra.Count; coluna++)
                            {
                                //Coluna Adicionar
                                ArrayJogosCombinacao[count, QuantNumerosInicio + coluna] = ElementosListaSobra[coluna];
                            }
                            count++;
                        }
                        //if (count == (int.Parse(ArrayJogosCombinacao.GetLength(0).ToString())))
                        //{
                        //    int[,] temp = (int[,])ArrayJogosCombinacao.Clone();

                        //    ArrayJogosCombinacao = new int[int.Parse(ArrayJogosCombinacao.GetLength(0).ToString()) + 10, 15];

                        //    for (int linha = 0; linha < int.Parse(temp.GetLength(0).ToString()); linha++)
                        //    {
                        //        for (int coluna = 0; coluna < 15; coluna++)
                        //        {
                        //            ArrayJogosCombinacao[linha, coluna] = temp[linha, coluna];
                        //        }
                        //    }
                        //}
                    }
                }
                else
                {
                    for (int x = inicio; x <= fim; x++)
                    {
                        ElementosCombinacoes[profundidade] = ElementosListaCriar[x];
                        busca(x + 1, fim + 1, profundidade + 1);
                    }
                }
            }
            catch (Exception ex){ex.ToString();
            }
        }
    
        public void EntradaValoresCriarJogo()
        {
            try
            {
                for (int i = 1; i <= 25; i++)
                {
                    //Painel Resultado Jogo
                    string textBoxEntrada = "circularButton";
                    StringBuilder sb = new StringBuilder(textBoxEntrada);
                    sb.Append(+i);
                    Panel panel = Application.OpenForms["TelaPrincipal"].Controls["panelTotal"].Controls["panelNumeros"] as Panel;
                    Button Button = panel.Controls[sb.ToString()] as Button;
                    if (Button.BackColor == Color.LightSkyBlue)
                    {
                        ElementosListaCriar.Add(i);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public void EntradaValoresSobraJogo()
        {
            try
            {
                for (int i = 1; i <= 25; i++)
                {
                    //Painel Resultado Jogo
                    string textBoxEntrada = "circularButtonX";
                    StringBuilder sb = new StringBuilder(textBoxEntrada);
                    sb.Append(+i);
                    Panel panel = Application.OpenForms["TelaPrincipal"].Controls["panelTotal"].Controls["panelNumeros2"] as Panel;
                    Button Button = panel.Controls[sb.ToString()] as Button;
                    if (Button.BackColor == Color.LightSkyBlue)
                    {
                        ElementosListaSobra.Add(i);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public void EntradaValoresCriarJogoLivre()
        {
            try
            {
                for (int i = 1; i <= 25; i++)
                {
                    //Painel Resultado Jogo
                    string textBoxEntrada = "circularButton";
                    StringBuilder sb = new StringBuilder(textBoxEntrada);
                    sb.Append(+i);
                    Panel panel = Application.OpenForms["TelaPrincipal"].Controls["panelTotal"].Controls["panelNumeros"] as Panel;
                    Button Button = panel.Controls[sb.ToString()] as Button;
                    //ArrayNumeros_selecionadosJogos[0] = 1;
                    if (Button.BackColor == Color.LightSkyBlue)
                    {
                        ElementosListaCriar.Add(i);
                    }
                }
                for (int i = 1; i <= 25; i++)
                {
                    //Painel Resultado Jogo
                    string textBoxEntrada = "circularButtonX";
                    StringBuilder sb = new StringBuilder(textBoxEntrada);
                    sb.Append(+i);
                    Panel panel = Application.OpenForms["TelaPrincipal"].Controls["panelTotal"].Controls["panelNumeros2"] as Panel;
                    Button Button = panel.Controls[sb.ToString()] as Button;
                    //ArrayNumeros_selecionadosJogos[0] = 1;
                    if (Button.BackColor == Color.LightSkyBlue)
                    {
                        ElementosListaCriar.Add(i);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public void ArrayRepetidasForm()
        {
            try
            {
                for (int i = 1; i <= 25; i++)
                {
                    //Painel Resultado Jogo
                    string textBoxEntrada = "circularButton";
                    StringBuilder sb = new StringBuilder(textBoxEntrada);
                    sb.Append(+i);
                    Panel panel = Application.OpenForms["TelaPrincipal"].Controls["panelTotal"].Controls["panelNumeros"] as Panel;
                    Button Button = panel.Controls[sb.ToString()] as Button;
                    if (Button.BackColor == Color.LightSkyBlue)
                    {
                        ElementosListaRepetidos.Add(i);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public void OrganizarArrayLista()
        {
            try
            {
                int aux = 0;
                for (int i = 0; i < ElementosListaCriar.Count; i++)
                {
                    for (int j = 0; j < ElementosListaCriar.Count; j++)
                    {
                        if (ElementosListaCriar[i] < ElementosListaCriar[j])
                        {
                            //aqui acontece a troca, do maior cara  vaia para a direita e o menor para a esquerda
                            aux = ElementosListaCriar[i];
                            ElementosListaCriar[i] = ElementosListaCriar[j];
                            ElementosListaCriar[j] = aux;
                        }
                    }
                }
            }
            catch (Exception err)
            {
                err.ToString();
            }
        }
        public void OrganizarArrayListaMega()
        {
            try
            {
                int aux = 0;
                for (int i = 0; i < ElementoslistaNumberMegas.Count; i++)
                {
                    for (int j = 0; j < ElementoslistaNumberMegas.Count; j++)
                    {
                        if (ElementoslistaNumberMegas[i] < ElementoslistaNumberMegas[j])
                        {
                            //aqui acontece a troca, do maior cara  vaia para a direita e o menor para a esquerda
                            aux = ElementoslistaNumberMegas[i];
                            ElementoslistaNumberMegas[i] = ElementoslistaNumberMegas[j];
                            ElementoslistaNumberMegas[j] = aux;
                        }
                    }
                }
            }
            catch (Exception err)
            {
                err.ToString();
            }
        }

        // BOTÃO CRIAR JOGOS   ---------------
        private void circularButton1_Click(object sender, EventArgs e)
        {
            if (circularButton1.BackColor == Color.Gainsboro)
            {
                circularButton1.BackColor = Color.LightSkyBlue;
                AdicionaImpar();
                AdcionaRepetidas();
                AdcionaModula();
                AdcionaFibonacci();
                AdicionaSeleciado();
            }
            else
            {
                circularButton1.BackColor = Color.Gainsboro;
                DiminuiImpar();
                DiminiuRepetidas();
                DiminiuModula();
                DiminiuFibonacci();
                DiminuiSeleciado();
            }
        }

        private void circularButton2_Click(object sender, EventArgs e)
        {
            if (circularButton2.BackColor == Color.Gainsboro)
            {
                circularButton2.BackColor = Color.LightSkyBlue;
                AdicionaPar();
                AdcionaRepetidas();
                AdcionaModula();
                AdcionaPrimos();
                AdcionaFibonacci();
                AdicionaSeleciado();
            }
            else
            {
                circularButton2.BackColor = Color.Gainsboro;
                DiminuiPar();
                DiminiuRepetidas();
                DiminiuModula();
                DiminiuPrimos();
                DiminiuFibonacci();
                DiminuiSeleciado();
            }
        }

        private void circularButton3_Click(object sender, EventArgs e)
        {
            if (circularButton3.BackColor == Color.Gainsboro)
            {
                circularButton3.BackColor = Color.LightSkyBlue;
                AdicionaImpar();
                AdcionaRepetidas();
                AdcionaModula();
                AdcionaPrimos();
                AdcionaFibonacci();
                AdicionaMult3();
                AdicionaSeleciado();
            }
            else
            {
                circularButton3.BackColor = Color.Gainsboro;
                DiminuiImpar();
                DiminiuRepetidas();
                DiminiuModula();
                DiminiuPrimos();
                DiminiuFibonacci();
                DiminiuMult3();
                DiminuiSeleciado();
            }
        }

        private void circularButton4_Click(object sender, EventArgs e)
        {
            if (circularButton4.BackColor == Color.Gainsboro)
            {
                circularButton4.BackColor = Color.LightSkyBlue;
                AdicionaPar();
                AdcionaRepetidas();
                AdcionaModula();
                AdicionaSeleciado();
            }
            else
            {
                circularButton4.BackColor = Color.Gainsboro;
                DiminuiPar();
                DiminiuRepetidas();
                DiminiuModula();
                DiminuiSeleciado();
            }
        }

        private void circularButton5_Click(object sender, EventArgs e)
        {
            if (circularButton5.BackColor == Color.Gainsboro)
            {
                circularButton5.BackColor = Color.LightSkyBlue;
                AdicionaImpar();
                AdcionaRepetidas();
                AdcionaModula();
                AdcionaPrimos();
                AdcionaFibonacci();
                AdicionaMagico();
                AdicionaSeleciado();
            }
            else
            {
                circularButton5.BackColor = Color.Gainsboro;
                DiminuiImpar();
                DiminiuRepetidas();
                DiminiuModula();
                DiminiuPrimos();
                DiminiuFibonacci();
                DiminiuMagico();
                DiminuiSeleciado();
            }
        }

        private void circularButton6_Click(object sender, EventArgs e)
        {
            if (circularButton6.BackColor == Color.Gainsboro)
            {
                circularButton6.BackColor = Color.LightSkyBlue;
                AdicionaPar();
                AdcionaRepetidas();
                AdcionaModula();
                AdicionaMult3();
                AdicionaMagico();
                AdicionaSeleciado();
            }
            else
            {
                circularButton6.BackColor = Color.Gainsboro;
                DiminuiPar();
                DiminiuRepetidas();
                DiminiuModula();
                DiminiuMult3();
                DiminiuMagico();
                DiminuiSeleciado();
            }
        }

        private void circularButton7_Click(object sender, EventArgs e)
        {
            if (circularButton7.BackColor == Color.Gainsboro)
            {
                circularButton7.BackColor = Color.LightSkyBlue;
                AdicionaImpar();
                AdcionaRepetidas();
                AdcionaPrimos();
                AdicionaMagico();
                AdicionaSeleciado();
            }
            else
            {
                circularButton7.BackColor = Color.Gainsboro;
                DiminuiImpar();
                DiminiuRepetidas();
                DiminiuPrimos();
                DiminiuMagico();
                DiminuiSeleciado();
            }
        }

        private void circularButton8_Click(object sender, EventArgs e)
        {
            if (circularButton8.BackColor == Color.Gainsboro)
            {
                circularButton8.BackColor = Color.LightSkyBlue;
                AdicionaPar();
                AdcionaRepetidas();
                AdcionaFibonacci();
                AdicionaSeleciado();
            }
            else
            {
                circularButton8.BackColor = Color.Gainsboro;
                DiminuiPar();
                DiminiuRepetidas();
                DiminiuFibonacci();
                DiminuiSeleciado();
            }
        }

        private void circularButton9_Click(object sender, EventArgs e)
        {
            if (circularButton9.BackColor == Color.Gainsboro)
            {
                circularButton9.BackColor = Color.LightSkyBlue;
                AdicionaImpar();
                AdcionaRepetidas();
                AdicionaMult3();
                AdicionaSeleciado();
            }
            else
            {
                circularButton9.BackColor = Color.Gainsboro;
                DiminuiImpar();
                DiminiuRepetidas();
                DiminiuMult3();
                DiminuiSeleciado();
            }
        }

        private void circularButton10_Click(object sender, EventArgs e)
        {
            if (circularButton10.BackColor == Color.Gainsboro)
            {
                circularButton10.BackColor = Color.LightSkyBlue;
                AdicionaPar();
                AdcionaRepetidas();
                AdcionaModula();
                AdicionaSeleciado();
            }
            else
            {
                circularButton10.BackColor = Color.Gainsboro;
                DiminuiPar();
                DiminiuRepetidas();
                DiminiuModula();
                DiminuiSeleciado();
            }
        }

        private void circularButton11_Click(object sender, EventArgs e)
        {
            if (circularButton11.BackColor == Color.Gainsboro)
            {
                circularButton11.BackColor = Color.LightSkyBlue;
                AdicionaImpar();
                AdcionaRepetidas();
                AdcionaModula();
                AdcionaPrimos();
                AdicionaSeleciado();
            }
            else
            {
                circularButton11.BackColor = Color.Gainsboro;
                DiminuiImpar();
                DiminiuRepetidas();
                DiminiuModula();
                DiminiuPrimos();
                DiminuiSeleciado();
            }
        }

        private void circularButton12_Click(object sender, EventArgs e)
        {
            if (circularButton12.BackColor == Color.Gainsboro)
            {
                circularButton12.BackColor = Color.LightSkyBlue;
                AdicionaPar();
                AdcionaRepetidas();
                AdicionaMult3();
                AdicionaMagico();
                AdicionaSeleciado();
            }
            else
            {
                circularButton12.BackColor = Color.Gainsboro;
                DiminuiPar();
                DiminiuRepetidas();
                DiminiuMult3();
                DiminiuMagico();
                DiminuiSeleciado();
            }
        }

        private void circularButton13_Click(object sender, EventArgs e)
        {
            if (circularButton13.BackColor == Color.Gainsboro)
            {
                circularButton13.BackColor = Color.LightSkyBlue;
                AdicionaImpar();
                AdcionaRepetidas();
                AdcionaPrimos();
                AdcionaFibonacci();
                AdicionaMagico();
                AdicionaSeleciado();
            }
            else
            {
                circularButton13.BackColor = Color.Gainsboro;
                DiminuiImpar();
                DiminiuRepetidas();
                DiminiuPrimos();
                DiminiuFibonacci();
                DiminiuMagico();
                DiminuiSeleciado();
            }
        }

        private void circularButton14_Click(object sender, EventArgs e)
        {
            if (circularButton14.BackColor == Color.Gainsboro)
            {
                circularButton14.BackColor = Color.LightSkyBlue;
                AdicionaPar();
                AdcionaRepetidas();
                AdicionaMagico();
                AdicionaSeleciado();
            }
            else
            {
                circularButton14.BackColor = Color.Gainsboro;
                DiminuiPar();
                DiminiuRepetidas();
                DiminiuMagico();
                DiminuiSeleciado();
            }
        }

        private void circularButton15_Click(object sender, EventArgs e)
        {
            if (circularButton15.BackColor == Color.Gainsboro)
            {
                circularButton15.BackColor = Color.LightSkyBlue;
                AdicionaImpar();
                AdcionaModula();
                AdicionaMult3();
                AdcionaRepetidas();
                AdicionaSeleciado();
            }
            else
            {
                circularButton15.BackColor = Color.Gainsboro;
                DiminuiImpar();
                DiminiuModula();
                DiminiuMult3();
                DiminiuRepetidas();
                DiminuiSeleciado();
            }
        }
        private void circularButton16_Click(object sender, EventArgs e)
        {
            if (circularButton16.BackColor == Color.Gainsboro)
            {
                circularButton16.BackColor = Color.LightSkyBlue;
                AdicionaPar();
                AdcionaModula();
                AdcionaRepetidas();
                AdicionaSeleciado();
            }
            else
            {
                circularButton16.BackColor = Color.Gainsboro;
                DiminuiPar();
                DiminiuModula();
                DiminiuRepetidas();
                DiminuiSeleciado();
            }
        }
        private void circularButton17_Click(object sender, EventArgs e)
        {
            if (circularButton17.BackColor == Color.Gainsboro)
            {
                circularButton17.BackColor = Color.LightSkyBlue;
                AdicionaImpar();
                AdcionaPrimos();
                AdcionaRepetidas();
                AdicionaSeleciado();
            }
            else
            {
                circularButton17.BackColor = Color.Gainsboro;
                DiminuiImpar();
                DiminiuPrimos();
                DiminiuRepetidas();
                DiminuiSeleciado();
            }
        }

        private void circularButton18_Click(object sender, EventArgs e)
        {
            if (circularButton18.BackColor == Color.Gainsboro)
            {
                circularButton18.BackColor = Color.LightSkyBlue;
                AdicionaPar();
                AdicionaMult3();
                AdcionaRepetidas();
                AdicionaSeleciado();
            }
            else
            {
                circularButton18.BackColor = Color.Gainsboro;
                DiminuiPar();
                DiminiuMult3();
                DiminiuRepetidas();
                DiminuiSeleciado();
            }
        }

        private void circularButton19_Click(object sender, EventArgs e)
        {
            if (circularButton19.BackColor == Color.Gainsboro)
            {
                circularButton19.BackColor = Color.LightSkyBlue;
                AdicionaImpar();
                AdcionaPrimos();
                AdcionaRepetidas();
                AdicionaMagico();
                AdicionaSeleciado();
            }
            else
            {
                circularButton19.BackColor = Color.Gainsboro;
                DiminuiImpar();
                DiminiuPrimos();
                DiminiuRepetidas();
                DiminiuMagico();
                DiminuiSeleciado();
            }
        }

        private void circularButton20_Click(object sender, EventArgs e)
        {
            if (circularButton20.BackColor == Color.Gainsboro)
            {
                circularButton20.BackColor = Color.LightSkyBlue;
                AdicionaPar();
                AdcionaModula();
                AdcionaRepetidas();
                AdicionaMagico();
                AdicionaSeleciado();
            }
            else
            {
                circularButton20.BackColor = Color.Gainsboro;
                DiminuiPar();
                DiminiuModula();
                DiminiuRepetidas();
                DiminiuMagico();
                DiminuiSeleciado();
            }
        }

        private void circularButton21_Click(object sender, EventArgs e)
        {
            if (circularButton21.BackColor == Color.Gainsboro)
            {
                circularButton21.BackColor = Color.LightSkyBlue;
                AdicionaImpar();
                AdcionaModula();
                AdcionaFibonacci();
                AdicionaMult3();
                AdcionaRepetidas();
                AdicionaMagico();
                AdicionaSeleciado();
            }
            else
            {
                circularButton21.BackColor = Color.Gainsboro;
                DiminuiImpar();
                DiminiuModula();
                DiminiuFibonacci();
                DiminiuMult3();
                DiminiuRepetidas();
                DiminiuMagico();
                DiminuiSeleciado();
            }
        }

        private void circularButton22_Click(object sender, EventArgs e)
        {
            if (circularButton22.BackColor == Color.Gainsboro)
            {
                circularButton22.BackColor = Color.LightSkyBlue;
                AdicionaPar();
                AdcionaModula();
                AdcionaRepetidas();
                AdicionaSeleciado();
            }
            else
            {
                circularButton22.BackColor = Color.Gainsboro;
                DiminuiPar();
                DiminiuModula();
                DiminiuRepetidas();
                DiminuiSeleciado();
            }
        }

        private void circularButton23_Click(object sender, EventArgs e)
        {
            if (circularButton23.BackColor == Color.Gainsboro)
            {
                circularButton23.BackColor = Color.LightSkyBlue;
                AdicionaImpar();
                AdcionaModula();
                AdcionaPrimos();
                AdcionaRepetidas();
                AdicionaSeleciado();
            }
            else
            {
                circularButton23.BackColor = Color.Gainsboro;
                DiminuiImpar();
                DiminiuModula();
                DiminiuPrimos();
                DiminiuRepetidas();
                DiminuiSeleciado();
            }
        }

        private void circularButton24_Click(object sender, EventArgs e)
        {
            if (circularButton24.BackColor == Color.Gainsboro)
            {
                circularButton24.BackColor = Color.LightSkyBlue;
                AdicionaPar();
                AdcionaModula();
                AdicionaMult3();
                AdcionaRepetidas();
                AdicionaSeleciado();
            }
            else
            {
                circularButton24.BackColor = Color.Gainsboro;
                DiminuiPar();
                DiminiuModula();
                DiminiuMult3();
                DiminiuRepetidas();
                DiminuiSeleciado();
            }
        }

        private void circularButton25_Click(object sender, EventArgs e)
        {
            if (circularButton25.BackColor == Color.Gainsboro)
            {
                circularButton25.BackColor = Color.LightSkyBlue;
                AdicionaImpar();
                AdcionaModula();
                AdcionaRepetidas();
                AdicionaSeleciado();
            }
            else
            {
                circularButton25.BackColor = Color.Gainsboro;
                DiminuiImpar();
                DiminiuModula();
                DiminiuRepetidas();
                DiminuiSeleciado();
            }
        }
        private void circularButtonX1_Click(object sender, EventArgs e)
        {
            if (circularButtonX1.BackColor == Color.Gainsboro)
            {
                circularButtonX1.BackColor = Color.LightSkyBlue;
                AdicionaImpar();
                AdcionaModula();
                AdcionaFibonacci();
                AdicionaSeleciado2();
            }
            else
            {
                circularButtonX1.BackColor = Color.Gainsboro;
                DiminuiImpar();
                DiminiuModula();
                DiminiuFibonacci();
                DiminuiSeleciado2();
            }
        }

        private void circularButtonX2_Click(object sender, EventArgs e)
        {
            if (circularButtonX2.BackColor == Color.Gainsboro)
            {
                circularButtonX2.BackColor = Color.LightSkyBlue;
                AdicionaPar();
                AdcionaModula();
                AdcionaPrimos();
                AdcionaFibonacci();
                AdicionaSeleciado2();
            }
            else
            {
                circularButtonX2.BackColor = Color.Gainsboro;
                DiminuiPar();
                DiminiuModula();
                DiminiuPrimos();
                DiminiuFibonacci();
                DiminuiSeleciado2();
            }
        }
        private void circularButtonX3_Click(object sender, EventArgs e)
        {
            if (circularButtonX3.BackColor == Color.Gainsboro)
            {
                circularButtonX3.BackColor = Color.LightSkyBlue;
                AdicionaImpar();
                AdcionaModula();
                AdcionaPrimos();
                AdcionaFibonacci();
                AdicionaMult3();
                AdicionaSeleciado2();
            }
            else
            {
                circularButtonX3.BackColor = Color.Gainsboro;
                DiminuiImpar();
                DiminiuModula();
                DiminiuPrimos();
                DiminiuFibonacci();
                DiminiuMult3();
                DiminuiSeleciado2();
            }
        }

        private void circularButtonX4_Click(object sender, EventArgs e)
        {
            if (circularButtonX4.BackColor == Color.Gainsboro)
            {
                circularButtonX4.BackColor = Color.LightSkyBlue;
                AdicionaPar();
                AdcionaModula();
                AdicionaSeleciado2();
            }
            else
            {
                circularButtonX4.BackColor = Color.Gainsboro;
                DiminuiPar();
                DiminiuModula();
                DiminuiSeleciado2();
            }
        }

        private void circularButtonX5_Click(object sender, EventArgs e)
        {
            if (circularButtonX5.BackColor == Color.Gainsboro)
            {
                circularButtonX5.BackColor = Color.LightSkyBlue;
                AdicionaImpar();
                AdcionaModula();
                AdcionaPrimos();
                AdcionaFibonacci();
                AdicionaMagico();
                AdicionaSeleciado2();
            }
            else
            {
                circularButtonX5.BackColor = Color.Gainsboro;
                DiminuiImpar();
                DiminiuModula();
                DiminiuPrimos();
                DiminiuFibonacci();
                DiminiuMagico();
                DiminuiSeleciado2();
            }
        }

        private void circularButtonX6_Click(object sender, EventArgs e)
        {
            if (circularButtonX6.BackColor == Color.Gainsboro)
            {
                circularButtonX6.BackColor = Color.LightSkyBlue;
                AdicionaPar();
                AdcionaModula();
                AdicionaMult3();
                AdicionaMagico();
                AdicionaSeleciado2();
            }
            else
            {
                circularButtonX6.BackColor = Color.Gainsboro;
                DiminuiPar();
                DiminiuModula();
                DiminiuMult3();
                DiminiuMagico();
                DiminuiSeleciado2();
            }
        }

        private void circularButtonX7_Click(object sender, EventArgs e)
        {
            if (circularButtonX7.BackColor == Color.Gainsboro)
            {
                circularButtonX7.BackColor = Color.LightSkyBlue;
                AdicionaImpar();
                AdcionaPrimos();
                AdicionaMagico();
                AdicionaSeleciado2();
            }
            else
            {
                circularButtonX7.BackColor = Color.Gainsboro;
                DiminuiImpar();
                DiminiuPrimos();
                DiminiuMagico();
                DiminuiSeleciado2();
            }
        }

        private void circularButtonX8_Click(object sender, EventArgs e)
        {
            if (circularButtonX8.BackColor == Color.Gainsboro)
            {
                circularButtonX8.BackColor = Color.LightSkyBlue;
                AdicionaPar();
                AdcionaFibonacci();
                AdicionaSeleciado2();
            }
            else
            {
                circularButtonX8.BackColor = Color.Gainsboro;
                DiminuiPar();
                DiminiuFibonacci();
                DiminuiSeleciado2();
            }
        }

        private void circularButtonX9_Click(object sender, EventArgs e)
        {
            if (circularButtonX9.BackColor == Color.Gainsboro)
            {
                circularButtonX9.BackColor = Color.LightSkyBlue;
                AdicionaImpar();
                AdicionaMult3();
                AdicionaSeleciado2();
            }
            else
            {
                circularButtonX9.BackColor = Color.Gainsboro;
                DiminuiImpar();
                DiminiuMult3();
                DiminuiSeleciado2();
            }
        }

        private void circularButtonX10_Click(object sender, EventArgs e)
        {
            if (circularButtonX10.BackColor == Color.Gainsboro)
            {
                circularButtonX10.BackColor = Color.LightSkyBlue;
                AdicionaPar();
                AdcionaModula();
                AdicionaSeleciado2();
            }
            else
            {
                circularButtonX10.BackColor = Color.Gainsboro;
                DiminuiPar();
                DiminiuModula();
                DiminuiSeleciado2();
            }
        }

        private void circularButtonX11_Click(object sender, EventArgs e)
        {
            if (circularButtonX11.BackColor == Color.Gainsboro)
            {
                circularButtonX11.BackColor = Color.LightSkyBlue;
                AdicionaImpar();
                AdcionaModula();
                AdcionaPrimos();
                AdicionaSeleciado2();
            }
            else
            {
                circularButtonX11.BackColor = Color.Gainsboro;
                DiminuiImpar();
                DiminiuModula();
                DiminiuPrimos();
                DiminuiSeleciado2();
            }
        }

        private void circularButtonX12_Click(object sender, EventArgs e)
        {
            if (circularButtonX12.BackColor == Color.Gainsboro)
            {
                circularButtonX12.BackColor = Color.LightSkyBlue;
                AdicionaPar();
                AdicionaMult3();
                AdicionaMagico();
                AdicionaSeleciado2();
            }
            else
            {
                circularButtonX12.BackColor = Color.Gainsboro;
                DiminuiPar();
                DiminiuMult3();
                DiminiuMagico();
                DiminuiSeleciado2();
            }
        }

        private void circularButtonX13_Click(object sender, EventArgs e)
        {
            if (circularButtonX13.BackColor == Color.Gainsboro)
            {
                circularButtonX13.BackColor = Color.LightSkyBlue;
                AdicionaImpar();
                AdcionaPrimos();
                AdcionaFibonacci();
                AdicionaMagico();
                AdicionaSeleciado2();
            }
            else
            {
                circularButtonX13.BackColor = Color.Gainsboro;
                DiminuiImpar();
                DiminiuPrimos();
                DiminiuFibonacci();
                DiminiuMagico();
                DiminuiSeleciado2();
            }
        }

        private void circularButtonX14_Click(object sender, EventArgs e)
        {
            if (circularButtonX14.BackColor == Color.Gainsboro)
            {
                circularButtonX14.BackColor = Color.LightSkyBlue;
                AdicionaPar();
                AdicionaMagico();
                AdicionaSeleciado2();
            }
            else
            {
                circularButtonX14.BackColor = Color.Gainsboro;
                DiminuiPar();
                DiminiuMagico();
                DiminuiSeleciado2();
            }
        }

        private void circularButtonX15_Click(object sender, EventArgs e)
        {
            if (circularButtonX15.BackColor == Color.Gainsboro)
            {
                circularButtonX15.BackColor = Color.LightSkyBlue;
                AdicionaImpar();
                AdcionaModula();
                AdicionaMult3();
                AdicionaSeleciado2();
            }
            else
            {
                circularButtonX15.BackColor = Color.Gainsboro;
                DiminuiImpar();
                DiminiuModula();
                DiminiuMult3();
                DiminuiSeleciado2();
            }
        }

        private void circularButtonX16_Click(object sender, EventArgs e)
        {
            if (circularButtonX16.BackColor == Color.Gainsboro)
            {
                circularButtonX16.BackColor = Color.LightSkyBlue;
                AdicionaPar();
                AdcionaModula();
                AdicionaSeleciado2();
            }
            else
            {
                circularButtonX16.BackColor = Color.Gainsboro;
                DiminuiPar();
                DiminiuModula();
                DiminuiSeleciado2();
            }
        }

        private void circularButtonX17_Click(object sender, EventArgs e)
        {
            if (circularButtonX17.BackColor == Color.Gainsboro)
            {
                circularButtonX17.BackColor = Color.LightSkyBlue;
                AdicionaImpar();
                AdcionaPrimos();
                AdicionaSeleciado2();
            }
            else
            {
                circularButtonX17.BackColor = Color.Gainsboro;
                DiminuiImpar();
                DiminiuPrimos();
                DiminuiSeleciado2();

            }
        }

        private void circularButtonX18_Click(object sender, EventArgs e)
        {
            if (circularButtonX18.BackColor == Color.Gainsboro)
            {
                circularButtonX18.BackColor = Color.LightSkyBlue;
                AdicionaPar();
                AdicionaMult3();
                AdicionaSeleciado2();
            }
            else
            {
                circularButtonX18.BackColor = Color.Gainsboro;
                DiminuiPar();
                DiminiuMult3();
                DiminuiSeleciado2();
            }
        }

        private void circularButtonX19_Click(object sender, EventArgs e)
        {
            if (circularButtonX19.BackColor == Color.Gainsboro)
            {
                circularButtonX19.BackColor = Color.LightSkyBlue;
                AdicionaImpar();
                AdcionaPrimos();
                AdicionaMagico();
                AdicionaSeleciado2();
            }
            else
            {
                circularButtonX19.BackColor = Color.Gainsboro;
                DiminuiImpar();
                DiminiuPrimos();
                DiminiuMagico();
                DiminuiSeleciado2();
            }
        }

        private void circularButtonX20_Click(object sender, EventArgs e)
        {
            if (circularButtonX20.BackColor == Color.Gainsboro)
            {
                circularButtonX20.BackColor = Color.LightSkyBlue;
                AdicionaPar();
                AdcionaModula();
                AdicionaMagico();
                AdicionaSeleciado2();
            }
            else
            {
                circularButtonX20.BackColor = Color.Gainsboro;
                DiminuiPar();
                DiminiuModula();
                DiminiuMagico();
                DiminuiSeleciado2();
            }
        }

        private void circularButtonX21_Click(object sender, EventArgs e)
        {
            if (circularButtonX21.BackColor == Color.Gainsboro)
            {
                circularButtonX21.BackColor = Color.LightSkyBlue;
                AdicionaImpar();
                AdcionaModula();
                AdcionaFibonacci();
                AdicionaMult3();
                AdicionaMagico();
                AdicionaSeleciado2();
            }
            else
            {
                circularButtonX21.BackColor = Color.Gainsboro;
                DiminuiImpar();
                DiminiuModula();
                DiminiuFibonacci();
                DiminiuMult3();
                DiminiuMagico();
                DiminuiSeleciado2();
            }
        }

        private void circularButtonX22_Click(object sender, EventArgs e)
        {
            if (circularButtonX22.BackColor == Color.Gainsboro)
            {
                circularButtonX22.BackColor = Color.LightSkyBlue;
                AdicionaPar();
                AdcionaModula();
                AdicionaSeleciado2();
            }
            else
            {
                circularButtonX22.BackColor = Color.Gainsboro;
                DiminuiPar();
                DiminiuModula();
                DiminuiSeleciado2();
            }
        }

        private void circularButtonX23_Click(object sender, EventArgs e)
        {
            if (circularButtonX23.BackColor == Color.Gainsboro)
            {
                circularButtonX23.BackColor = Color.LightSkyBlue;
                AdicionaImpar();
                AdcionaModula();
                AdcionaPrimos();
                AdicionaSeleciado2();
            }
            else
            {
                circularButtonX23.BackColor = Color.Gainsboro;
                DiminuiImpar();
                DiminiuModula();
                DiminiuPrimos();
                DiminuiSeleciado2();
            }
        }

        private void circularButtonX24_Click(object sender, EventArgs e)
        {
            if (circularButtonX24.BackColor == Color.Gainsboro)
            {
                circularButtonX24.BackColor = Color.LightSkyBlue;
                AdicionaPar();
                AdcionaModula();
                AdicionaMult3();
                AdicionaSeleciado2();
            }
            else
            {
                circularButtonX24.BackColor = Color.Gainsboro;
                DiminuiPar();
                DiminiuModula();
                DiminiuMult3();
                DiminuiSeleciado2();
            }
        }

        private void circularButtonX25_Click(object sender, EventArgs e)
        {
            if (circularButtonX25.BackColor == Color.Gainsboro)
            {
                circularButtonX25.BackColor = Color.LightSkyBlue;
                AdicionaImpar();
                AdcionaModula();
                AdicionaSeleciado2();
            }
            else
            {
                circularButtonX25.BackColor = Color.Gainsboro;
                DiminuiImpar();
                DiminiuModula();
                DiminuiSeleciado2();
            }
        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxJogos_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCombinacaoEscolhida.Checked == true)
            {
                checkBoxPI.Checked = true;
                checkBoxMoldura.Checked = true;
                checkBoxPrimos.Checked = true;
                checkBoxNumerosFibonacci.Checked = true;
                checkBoxMultiploDe3.Checked = true;
            }
            else
            {
                checkBoxPI.Checked = false;
                checkBoxMoldura.Checked = false;
                checkBoxPrimos.Checked = false;
                checkBoxNumerosFibonacci.Checked = false;
                checkBoxMultiploDe3.Checked = false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButtonLivre_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLivre.Checked == true)
            {
                textBoxMinimoEscolha.Enabled = true;
                textBoxMinimoEscolha.Text = "5";
                textBoxMaximoEscolha.Enabled = true;
                textBoxMaximoEscolha.Text = "7";

            }
        }

        private void radioButtonCombinacao_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCombinacao.Checked == true)
            {
                textBoxMinimoEscolha.Enabled = false;
                textBoxMinimoEscolha.Text = "0";
                textBoxMaximoEscolha.Enabled = false;
                textBoxMaximoEscolha.Text = "";
            }
        }

        private void buttonResultado_Click(object sender, EventArgs e)
        {
            //Ultimo();
            AdicionarResultadoUltimo();
            IniciarResultado();
        }
        private void buttonBusX_Click(object sender, EventArgs e)
        {
            BustX();
        }
        private void BustX()
        {
            try
            {
                this.MinimoElemento = int.Parse(textBoxMinimoEscolha.Text);
                this.maximoElemento = int.Parse(textBoxMaximoEscolha.Text);

                if (this.BuscaLouC == 0) { MessageBox.Show("Os calculos não foram realizado ainda!"); }
                if (this.BuscaLouC == 1)
                {
                    if (radioButtonParImpar.Checked == true)
                    {
                        if (comboBoxParImpar.Text == "SELECIONAR CALC") { MessageBox.Show("Selecione um BUS X"); } else { limpaTodosSelecionado(); ParesEImpares(CombinacaoParesImparIndex); }
                    }
                    if (radioButtonNumeroRepetidas.Checked == true)
                    {
                        if (comboBoxNumeroRepetidas.Text == "SELECIONAR CALC") { MessageBox.Show("Selecione um BUS X"); } else { limpaTodosSelecionado(); RepetidosNumeros(NumeroRepetidas); }
                    }
                    if (radioButtonMoldura.Checked == true)
                    {
                        if (comboBoxMoldura.Text == "SELECIONAR CALC") { MessageBox.Show("Selecione um BUS X"); } else { limpaTodosSelecionado(); ModulaNumeros(NumeroModula); }
                    }
                    if (radioButtonPrimos.Checked == true)
                    {
                        if (comboBoxPrimos.Text == "SELECIONAR CALC") { MessageBox.Show("Selecione um BUS X"); } else { limpaTodosSelecionado(); NumerosPrimos(NumeroPrimos); }
                    }
                    if (radioButtonFibonacci.Checked == true)
                    {
                        if (comboBoxFibonacci.Text == "SELECIONAR CALC") { MessageBox.Show("Selecione um BUS X"); } else { limpaTodosSelecionado(); NumerosFibonacci(NumeroFibonacci); }
                    }
                    if (radioButtonMultiploDe3.Checked == true)
                    {
                        if (comboBoxMultiploDe3.Text == "SELECIONAR CALC") { MessageBox.Show("Selecione um BUS X"); } else { limpaTodosSelecionado(); NumerosMult(NumeroMultiploDe3); }
                    }
                    if (radioButtonInicioFim.Checked == true)
                    {
                        if ((textBoxRadioInicio.Text == "") || (textBoxRadioFim.Text == "")) { MessageBox.Show("Branco não válido"); } else { limpaTodosSelecionado(); InicioEFim(int.Parse(textBoxRadioInicio.Text), int.Parse(textBoxRadioFim.Text)); }
                    }
                    if (radioButtonTodosJogos.Checked == true) { 
                        limpaTodosSelecionado();
                        if (checkBoxAtivado.Checked == true)
                        {
                            TodosJogosCombinacoesA();
                        }
                        else
                        {
                            TodosJogosCombinacoesD();
                        }
                 
                    }
                    label37.Text = "QUANT: " + Convert.ToString(dataGridViewSelecionado.Rows.Count - 1);
                    label38.Text = "TOTAL: " + this.count;
                }
                if (this.BuscaLouC == 2)
                {
                    if (radioButtonParImpar.Checked == true)
                    {
                        if (comboBoxParImpar.Text == "SELECIONAR CALC") { MessageBox.Show("Selecione um BUS X"); } else { limpaTodosSelecionado(); ParesEImpares(CombinacaoParesImparIndex); }
                    }
                    if (radioButtonMoldura.Checked == true)
                    {
                        if (comboBoxMoldura.Text == "SELECIONAR CALC") { MessageBox.Show("Selecione um BUS X"); } else { limpaTodosSelecionado(); ModulaNumeros(NumeroModula); }
                    }
                    if (radioButtonPrimos.Checked == true)
                    {
                        if (comboBoxPrimos.Text == "SELECIONAR CALC") { MessageBox.Show("Selecione um BUS X"); } else { limpaTodosSelecionado(); NumerosPrimos(NumeroPrimos); }
                    }
                    if (radioButtonFibonacci.Checked == true)
                    {
                        if (comboBoxFibonacci.Text == "SELECIONAR CALC") { MessageBox.Show("Selecione um BUS X"); } else { limpaTodosSelecionado(); NumerosFibonacci(NumeroFibonacci); }
                    }
                    if (radioButtonMultiploDe3.Checked == true)
                    {
                        if (comboBoxMultiploDe3.Text == "SELECIONAR CALC") { MessageBox.Show("Selecione um BUS X"); } else { limpaTodosSelecionado(); NumerosMult(NumeroMultiploDe3); }
                    }
                    if (radioButtonInicioFim.Checked == true)
                    {
                        if ((textBoxRadioInicio.Text == "") || (textBoxRadioFim.Text == "")) { MessageBox.Show("Branco não válido"); } else { limpaTodosSelecionado(); InicioEFim(int.Parse(textBoxRadioInicio.Text), int.Parse(textBoxRadioFim.Text)); }
                    }
                    if (radioButtonTodosJogos.Checked == true) 
                    { 
                        limpaTodosSelecionado();
                        if (checkBoxAtivado.Checked == true)
                        {
                            TodosJogosCombinacoesA();
                        }
                        else
                        {
                            TodosJogosCombinacoesD();
                        }
                    }
                    label37.Text = "QUANT: " + Convert.ToString(dataGridViewSelecionado.Rows.Count - 1);
                    label38.Text = "TOTAL: " + this.count;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }
        private void buttonTelaJogos_Click(object sender, EventArgs e)
        {
            AbrirNovaJanela();
        }

        public void AbrirNovaJanela()
        {
            try
            {
                if(checkBoxSomaLinha.Checked == true)
                {
                    int Modo = 0;

                    if (radioButtonSelecionado.Checked == true)
                    {
                        if (dataGridViewSelecionado.RowCount < 2)
                        {
                            MessageBox.Show("Sem Jogos na Tela Selecionado.");
                        }
                        else
                        {
                          //  ArraySelecionadoTP();
                            Modo = 1;
                            FormSecundaria FormSecundariaS = new FormSecundaria(this, Modo,int.Parse(textBoxLinhaM.Text),int.Parse(textBoxLinhaMa.Text));
                            FormSecundariaS.Show();
                            FormSecundariaS.Top = 100;
                            FormSecundariaS.Left = 100;
                        }
                    }
                    if (radioButtonEscolhas.Checked == true)
                    {
                        if (ListaCombinacoes.Count == 0)
                        {
                            MessageBox.Show("Sem Jogos na Tela Escolhas.");
                        }
                        else
                        {
                           // ArraySelecionadoTP();
                            Modo = 2;
                            FormSecundaria FormSecundariaS = new FormSecundaria(this, Modo, int.Parse(textBoxLinhaM.Text), int.Parse(textBoxLinhaMa.Text));
                            FormSecundariaS.Show();
                            FormSecundariaS.Top = 100;
                            FormSecundariaS.Left = 100;
                        }
                    }
                }
                else
                {
                    int Modo = 0;

                    if (radioButtonSelecionado.Checked == true)
                    {
                        if (dataGridViewSelecionado.RowCount < 2)
                        {
                            MessageBox.Show("Sem Jogos na Tela Selecionado.");
                        }
                        else
                        {
                           // ArraySelecionadoTP();

                            Modo = 1;
                            FormSecundaria FormSecundariaS = new FormSecundaria(this,Modo);
                            FormSecundariaS.ShowDialog();
                            FormSecundariaS.Top = 100;
                            FormSecundariaS.Left = 100;
                        }
                    }

                    if (radioButtonEscolhas.Checked == true)
                    {
                        if (ListaCombinacoes.Count == 0)
                        {
                            MessageBox.Show("Sem Jogos na Tela Escolhas.");
                        }
                        else
                        {
                           // ArraySelecionadoTP();
                            Modo = 2;
                            FormSecundaria FormSecundariaS = new FormSecundaria(this, Modo);
                            FormSecundariaS.ShowDialog();
                            FormSecundariaS.Top = 100;
                            FormSecundariaS.Left = 100;
                        }
                    }
                    //if (radioButtonEscolhas.Checked == true)
                    //{
                    //    if (ListaCombinacoes.Count == 0)
                    //    {
                    //        MessageBox.Show("Sem Jogos na Tela Escolhas.");
                    //    }
                    //    else
                    //    {
                    //        Modo = 2;
                    //        FormSecundaria FormSecundariaS = new FormSecundaria( Modo);
                    //        FormSecundariaS.ShowDialog();
                    //        FormSecundariaS.Top = 100;
                    //        FormSecundariaS.Left = 100;
                    //    }
                    //}
                }                
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("1" + ex.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("2" + ex.ToString());
            }
        }
        public void ArraySelecionadoTP()
        {
            try
            {
                if (radioButtonSelecionado.Checked == true)
                {
                    //if(dataGridViewSelecionado.RowCount < 2)
                    //{

                    //}
                    //else
                    //{
                    //    ArraySelecionado = new int[dataGridViewSelecionado.Rows.Count - 1, 16];       
                    //    for (int linha = 0; linha < dataGridViewSelecionado.Rows.Count - 1; linha++)
                    //    {
                    //        for (int coluna = 0; coluna < 16; coluna++)
                    //        {
                    //            ArraySelecionado[linha, coluna] = int.Parse(dataGridViewSelecionado.Rows[linha].Cells[coluna + 1].Value.ToString());
                    //        }
                    //    }
                    //}
                }
                if (radioButtonEscolhas.Checked == true)
                {
                    if (dataGridViewCombinacoesEscolhidas.RowCount < 2)
                    {

                    }
                    else
                    {
                        ArraySelecionado = new int[dataGridViewCombinacoesEscolhidas.Rows.Count - 1, 16];
                        for (int linha = 0; linha < dataGridViewCombinacoesEscolhidas.Rows.Count - 1; linha++)
                        {
                            for (int coluna = 0; coluna < 16; coluna++)
                            {
                                ArraySelecionado[linha, coluna] = int.Parse(dataGridViewCombinacoesEscolhidas.Rows[linha].Cells[coluna + 1].Value.ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        
        int combinacoes(int n, int k)
        {
            int dif = n - k;
            int combinacoes = 0;
            if (k < dif)
            {
                dif = k;
                k = n - dif;
            }
            combinacoes = k + 1;

            if (dif == 0)
            {
                combinacoes = 1;
            }
            else
            {
                if (dif >= 2)
                {
                    for (int i = 2; i <= dif; i = i + 1)
                    {
                        combinacoes = (combinacoes * (k + i)) / i;
                    }
                }
            }
            return combinacoes;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //JogoDuplicado();
            JogosIndependencia();
        }
        public void JogoDuplicado()
        {
            try
            {
                Boolean repetido = false;
                for (int inicio = 0; inicio < int.Parse(arrays.ArrayTamanho())-1; inicio++)
                {
                    for(int proximo = inicio + 1; proximo < int.Parse(arrays.ArrayTamanho()); proximo++)
                    {
                        for (int coluna = 0; coluna < 15; coluna++)
                        {
                            if (arrays.ArrayL(inicio, coluna) == arrays.ArrayL(proximo, coluna))
                            {
                                if(coluna == 14)
                                {
                                    int concurso = inicio + 1;
                                    int concurso2 = proximo + 1;
                                    repetido = true;
                                    MessageBox.Show("Jogo :" + concurso + " Já consta no: " + concurso2 +".");
                                }
                            }
                            else
                            {
                                coluna = 15;
                            }
                        }
                    }               
                }
                if(repetido == false)
                {
                    MessageBox.Show("Não existe jogo repetido.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Err: " + ex.ToString());
            }
        }
        public void JogosIndependencia()
        {
            //try
            //{
            //    Boolean repetido = false;
            //    for ( int JogosGrupos = 0; JogosGrupos < int.Parse(arraysIndependencia.ArrayTamanho()) ; JogosGrupos++)
            //    {
            //        for (int JogosConcursos = 0; JogosConcursos < int.Parse(arrays.ArrayTamanho()); JogosConcursos++)
            //        {
            //            for (int coluna = 0; coluna < 15; coluna++)
            //            {
            //                if (arraysIndependencia.ArrayL(JogosGrupos, coluna) == arrays.ArrayL(JogosConcursos, coluna))
            //                {
            //                    if (coluna == 14)
            //                    {
            //                        int JogoG = JogosGrupos + 1;
            //                        int JogoC = JogosConcursos + 1;
            //                        repetido = true;
            //                        Console.WriteLine("Jogo da Independência :" + JogoG + " é do concurso: " + JogoC + ".");
            //                        JogosConcursos = int.Parse(arrays.ArrayTamanho());
            //                    }
            //                }
            //                else
            //                {
            //                    coluna = 15;
            //                }
            //            }
            //        }
            //    }
            //    if (repetido == false)
            //    {
            //        MessageBox.Show("Não existe jogos repetidos.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(" Err: " + ex.ToString());
            //}
        }
        private void buttonteste_Click(object sender, EventArgs e)
        {
            //testeElementos();
            try
            {
                string jogo = "";
                var rand = new Random();
                //List<int> ElementoslistaNumberMegas = new List<int>();
                int numbers = rand.Next(1, 60);
                for( int n = 0; n < 40; n++)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        ElementoslistaNumberMegas.Add(numbers);
                        numbers = rand.Next(1, 60);
                    }
                    OrganizarArrayListaMega();
                    
                    for (int i = 0; i < ElementoslistaNumberMegas.Count; i++)
                    {
                        if( i != 5)
                        {
                            jogo = jogo + ElementoslistaNumberMegas[i].ToString() +",";
                            //Console.WriteLine(jogo);
                            //i.ToString();
                        }
                        else
                        {
                            jogo = jogo + ElementoslistaNumberMegas[i].ToString() + ".";
                            //Console.WriteLine(jogo);
                            //i.ToString();
                        }
                        
                    }
                    Console.WriteLine("Jogo " + (n + 1) + ": " + jogo);
                    ElementoslistaNumberMegas.Clear();
                    jogo = "";
                }

               
                //printPreviewDialogVisualizar.Document = printDocumentImprmir;
                //printPreviewDialogVisualizar.ShowDialog();
            }
            catch (Exception err)
            {
                MessageBox.Show("Error " + err.ToString());
            }
        }
        public void testeElementos()
        {
            try
            {
                Console.WriteLine(arrays.ArrayTamanho());
                int contador = 0;

                for (int testeLinhaInicio = 0; testeLinhaInicio < int.Parse(arrays.ArrayTamanho()); testeLinhaInicio++)
                {
                    for (int testeLinhaInicio2 = testeLinhaInicio + 1; testeLinhaInicio2 < int.Parse(arrays.ArrayTamanho()); testeLinhaInicio2++)
                    {
                        for (int coluna = 0; coluna < 15; coluna++)
                        {
                            if (arrays.ArrayL(testeLinhaInicio, coluna) == arrays.ArrayL(testeLinhaInicio2, coluna))
                            {
                                contador++;
                            }
                            else
                            {
                                coluna = 15;
                            }
                        }
                        if (contador == 15)
                        {
                            string numero = "";
                            for (int coluna = 0; coluna < 15; coluna++)
                            {
                                if (coluna < 14)
                                {
                                    numero = numero + arrays.ArrayL(testeLinhaInicio2, coluna) + ", ";
                                }
                                if (coluna == 14)
                                {
                                    numero = numero + arrays.ArrayL(testeLinhaInicio2, coluna) + ".";
                                }
                            }
                            Console.WriteLine("Linha_1: " + testeLinhaInicio + " e linha existe: " + testeLinhaInicio2 + " Jogo: " + numero + "\n");
                        }
                        contador = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally { Console.WriteLine("Finalizado!"); }

        }

        private void printDocumentImprmir_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Bitmap bmp = Properties.Resources.Loterica___D;
                Image newImagem = bmp;

                int width = newImagem.Width;
                int height = newImagem.Height;

                //Draw image to screen.
                e.Graphics.DrawImage(newImagem, -4, -7, (int)(width / 3), (int)(height / 3));
                // Create pen.
                Pen blackPen = new Pen(Color.Black, 10);

                int[,] Array = new int[5, 5];

                int numero = 1;
                for (int linha = 0; linha < 5; linha++)
                {
                    for (int coluna = 0; coluna < 5; coluna++)
                    {
                        Array[linha, coluna] = numero;
                        numero++;
                    }
                }

                //for (int InicioLinha = 0; InicioLinha < 5; InicioLinha++)
                //{
                //    for (int InicioColuna = 0; InicioColuna < 5; InicioColuna++)
                //    {
                //        Rectangle rectangle = new Rectangle(XColuna + IncrementaXColuna, Xlinha + IncrementaXLinha, 2, 9);

                //        e.Graphics.DrawRectangle(blackPen, rectangle);

                //        if (InicioColuna >= 1)
                //        {
                //            IncrementaXColuna = 18 * (InicioColuna + 1);
                //        }
                //        if (InicioColuna == 0)
                //        {
                //            IncrementaXColuna = 18 * 1;
                //        }
                //    }
                //    if (InicioLinha >= 1)
                //    {
                //        IncrementaXLinha = 50 * (InicioLinha + 1);
                //    }
                //    if (InicioLinha == 0)
                //    {
                //        IncrementaXLinha = 50 * 1;
                //    }
                //    IncrementaXColuna = 0;
                //}

                int XColuna = 176;
                int Xlinha = 56; 
                int IncrementaXColuna = 0;
                int IncrementaXLinha = 0;

                int inicio_linhaJogos = 0, inicio_ColunaJogos = 0, Inicio_linhaArray = 0, Inicio_colunaArray = 0;
                int contador = 0;
                for (int QuantJ = inicio_linhaJogos; QuantJ < int.Parse(VerificarTamanho()); QuantJ++)//x1
                {
                    for (int LinhaArray = Inicio_linhaArray; LinhaArray < 5; LinhaArray++)//y1
                    {
                        for (int colunaQJ = inicio_ColunaJogos; colunaQJ < 15; colunaQJ++)//x2
                        {
                            for (int ColunaAY = Inicio_colunaArray; ColunaAY <= 5; ColunaAY++)//y2
                            {
                                if (ColunaAY == 5)
                                {
                                    inicio_ColunaJogos = colunaQJ;//x2
                                    colunaQJ = 15;
                                    ColunaAY = 6;
                                    Inicio_colunaArray = 0;//y2
                                }
                                else
                                {
                                    if (Armazanados(QuantJ, colunaQJ) == Array[LinhaArray, ColunaAY])
                                    {
                                        LinhaArray.ToString();
                                        ColunaAY.ToString();
                                        if (LinhaArray == 0)
                                        {
                                            //IncrementaXLinha = 50 * 1;
                                        }
                                        if (LinhaArray >= 1)
                                        {
                                            IncrementaXLinha = 50 * LinhaArray;
                                        }

                                        if (ColunaAY >= 1)
                                        {
                                            IncrementaXColuna = 18 * ColunaAY;
                                        }
                                        if (ColunaAY == 0)
                                        {
                                            //IncrementaXColuna = 18 * 1;
                                        }

                                        Rectangle rectangle = new Rectangle(XColuna + IncrementaXColuna, Xlinha + IncrementaXLinha, 2, 9);
                                        e.Graphics.DrawRectangle(blackPen, rectangle);
                                    }



                                    inicio_ColunaJogos = colunaQJ;//x2
                                    Inicio_colunaArray = ColunaAY + 1;//y2
                                    ColunaAY = 15;//y2
                                    contador++;
                                    IncrementaXLinha = 0;
                                    IncrementaXColuna = 0;
                                }
                                if (contador == 15)
                                {
                                    inicio_ColunaJogos = 0;
                                    Inicio_colunaArray = 0;
                                    Inicio_linhaArray = 0;
                                    colunaQJ = 15;
                                    ColunaAY = 6;
                                    LinhaArray = 5;
                                    contador = 0;
                                }
                            }
                        }
                    }
                }          
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
        }

        private void TelaPrincipal_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Application.Exit();
        }

        private void circularButtonN1_Click(object sender, EventArgs e)
        {
            if (circularButtonN1.BackColor == Color.Gainsboro)
            {
                circularButtonN1.BackColor = Color.LightSkyBlue;
            }
            else
            {
                circularButtonN1.BackColor = Color.Gainsboro;

            }
        }

        private void circularButtonN2_Click(object sender, EventArgs e)
        {
            if (circularButtonN2.BackColor == Color.Gainsboro)
            {
                circularButtonN2.BackColor = Color.LightSkyBlue;
            }
            else
            {
                circularButtonN2.BackColor = Color.Gainsboro;

            }
        }

        private void circularButtonN3_Click(object sender, EventArgs e)
        {
            if (circularButtonN3.BackColor == Color.Gainsboro)
            {
                circularButtonN3.BackColor = Color.LightSkyBlue;
            }
            else
            {
                circularButtonN3.BackColor = Color.Gainsboro;

            }
        }

        private void circularButtonN4_Click(object sender, EventArgs e)
        {
            if (circularButtonN4.BackColor == Color.Gainsboro)
            {
                circularButtonN4.BackColor = Color.LightSkyBlue;
            }
            else
            {
                circularButtonN4.BackColor = Color.Gainsboro;

            }
        }

        private void circularButtonN5_Click(object sender, EventArgs e)
        {
            if (circularButtonN5.BackColor == Color.Gainsboro)
            {
                circularButtonN5.BackColor = Color.LightSkyBlue;
            }
            else
            {
                circularButtonN5.BackColor = Color.Gainsboro;

            }
        }

        private void circularButtonN6_Click(object sender, EventArgs e)
        {
            if (circularButtonN6.BackColor == Color.Gainsboro)
            {
                circularButtonN6.BackColor = Color.LightSkyBlue;
            }
            else
            {
                circularButtonN6.BackColor = Color.Gainsboro;

            }
        }

        private void circularButtonN7_Click(object sender, EventArgs e)
        {
            if (circularButtonN7.BackColor == Color.Gainsboro)
            {
                circularButtonN7.BackColor = Color.LightSkyBlue;
            }
            else
            {
                circularButtonN7.BackColor = Color.Gainsboro;

            }
        }

        private void circularButtonN8_Click(object sender, EventArgs e)
        {
            if (circularButtonN8.BackColor == Color.Gainsboro)
            {
                circularButtonN8.BackColor = Color.LightSkyBlue;
            }
            else
            {
                circularButtonN8.BackColor = Color.Gainsboro;

            }
        }

        private void circularButtonN9_Click(object sender, EventArgs e)
        {
            if (circularButtonN9.BackColor == Color.Gainsboro)
            {
                circularButtonN9.BackColor = Color.LightSkyBlue;
            }
            else
            {
                circularButtonN9.BackColor = Color.Gainsboro;

            }
        }

        private void circularButtonN10_Click(object sender, EventArgs e)
        {
            if (circularButtonN10.BackColor == Color.Gainsboro)
            {
                circularButtonN10.BackColor = Color.LightSkyBlue;
            }
            else
            {
                circularButtonN10.BackColor = Color.Gainsboro;

            }
        }

        private void circularButtonN11_Click(object sender, EventArgs e)
        {
            if (circularButtonN11.BackColor == Color.Gainsboro)
            {
                circularButtonN11.BackColor = Color.LightSkyBlue;
            }
            else
            {
                circularButtonN11.BackColor = Color.Gainsboro;

            }
        }

        private void circularButtonN12_Click(object sender, EventArgs e)
        {
            if (circularButtonN12.BackColor == Color.Gainsboro)
            {
                circularButtonN12.BackColor = Color.LightSkyBlue;
            }
            else
            {
                circularButtonN12.BackColor = Color.Gainsboro;

            }
        }

        private void circularButtonN13_Click(object sender, EventArgs e)
        {
            if (circularButtonN13.BackColor == Color.Gainsboro)
            {
                circularButtonN13.BackColor = Color.LightSkyBlue;
            }
            else
            {
                circularButtonN13.BackColor = Color.Gainsboro;

            }
        }

        private void circularButtonN14_Click(object sender, EventArgs e)
        {
            if (circularButtonN14.BackColor == Color.Gainsboro)
            {
                circularButtonN14.BackColor = Color.LightSkyBlue;
            }
            else
            {
                circularButtonN14.BackColor = Color.Gainsboro;

            }
        }

        private void circularButtonN15_Click(object sender, EventArgs e)
        {
            if (circularButtonN15.BackColor == Color.Gainsboro)
            {
                circularButtonN15.BackColor = Color.LightSkyBlue;
            }
            else
            {
                circularButtonN15.BackColor = Color.Gainsboro;

            }
        }

        private void circularButtonN16_Click(object sender, EventArgs e)
        {
            if (circularButtonN16.BackColor == Color.Gainsboro)
            {
                circularButtonN16.BackColor = Color.LightSkyBlue;
            }
            else
            {
                circularButtonN16.BackColor = Color.Gainsboro;

            }
        }

        private void circularButtonN17_Click(object sender, EventArgs e)
        {
            if (circularButtonN17.BackColor == Color.Gainsboro)
            {
                circularButtonN17.BackColor = Color.LightSkyBlue;
            }
            else
            {
                circularButtonN17.BackColor = Color.Gainsboro;

            }
        }

        private void circularButtonN18_Click(object sender, EventArgs e)
        {
            if (circularButtonN18.BackColor == Color.Gainsboro)
            {
                circularButtonN18.BackColor = Color.LightSkyBlue;
            }
            else
            {
                circularButtonN18.BackColor = Color.Gainsboro;

            }
        }

        private void circularButtonN19_Click(object sender, EventArgs e)
        {
            if (circularButtonN19.BackColor == Color.Gainsboro)
            {
                circularButtonN19.BackColor = Color.LightSkyBlue;
            }
            else
            {
                circularButtonN19.BackColor = Color.Gainsboro;

            }
        }

        private void circularButtonN20_Click(object sender, EventArgs e)
        {
            if (circularButtonN20.BackColor == Color.Gainsboro)
            {
                circularButtonN20.BackColor = Color.LightSkyBlue;
            }
            else
            {
                circularButtonN20.BackColor = Color.Gainsboro;

            }
        }

        private void circularButtonN21_Click(object sender, EventArgs e)
        {
            if (circularButtonN21.BackColor == Color.Gainsboro)
            {
                circularButtonN21.BackColor = Color.LightSkyBlue;
            }
            else
            {
                circularButtonN21.BackColor = Color.Gainsboro;

            }
        }

        private void circularButtonN22_Click(object sender, EventArgs e)
        {
            if (circularButtonN22.BackColor == Color.Gainsboro)
            {
                circularButtonN22.BackColor = Color.LightSkyBlue;
            }
            else
            {
                circularButtonN22.BackColor = Color.Gainsboro;

            }
        }

        private void circularButtonN23_Click(object sender, EventArgs e)
        {
            if (circularButtonN23.BackColor == Color.Gainsboro)
            {
                circularButtonN23.BackColor = Color.LightSkyBlue;
            }
            else
            {
                circularButtonN23.BackColor = Color.Gainsboro;

            }
        }

        private void circularButtonN24_Click(object sender, EventArgs e)
        {
            if (circularButtonN24.BackColor == Color.Gainsboro)
            {
                circularButtonN24.BackColor = Color.LightSkyBlue;
            }
            else
            {
                circularButtonN24.BackColor = Color.Gainsboro;

            }
        }

        private void circularButtonN25_Click(object sender, EventArgs e)
        {
            if (circularButtonN25.BackColor == Color.Gainsboro)
            {
                circularButtonN25.BackColor = Color.LightSkyBlue;
            }
            else
            {
                circularButtonN25.BackColor = Color.Gainsboro;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelResultado_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelNumeros_Paint(object sender, PaintEventArgs e)
        {

        }
        //ABRIR FORM SECUNDARIA
        public int ArraySelecionadoRetorno(int linha, int coluna)
        {
            return ArraySelecionado[linha, coluna];
        }
        public string ArraySelecionadoTamanho()
        {
            return ArraySelecionado.GetLength(0).ToString();
        }
        public string ArraySelecionadoTamanhoQuantidade()
        {
            return ArraySelecionado.Length.ToString();
        }

        //ARRAY DE COMBINAÇÃO
        public int ArrayJogosCombinacaoRetorno(int linha, int coluna)
        {
            return ArrayJogosCombinacao[linha, coluna];
        }
        public string ArrayJogosCombinacaoTamanho()
        {
            return ArrayJogosCombinacao.GetLength(0).ToString();
        }
        public string ArrayJogosCombinacaoTamanhoQuantidade()
        {
            return ArrayJogosCombinacao.Length.ToString();
        }
        //ARRAY DE LISTA Todos Selecionados
        public int ListaTodosSelecionadosRetorno(int Indice)
        {
            return ListaTodosSelecionados[Indice];
        }
        public string ListaTodosSelecionadosTamanhoQuantidade()
        {
            return ListaTodosSelecionados.Count.ToString();
        }
        //ARRAY DE LISTA ListaCombinacoes
        public int ListaCombinacoesCombinacaoRetorno(int Indice)
        {
            return ListaCombinacoes[Indice];
        }
        public string ListaCombinacoesCombinacaoTamanhoQuantidade()
        {
            return ListaCombinacoes.Count.ToString();
        }
        //ARRAY DE LISTA ListaCombinacoes Segunda Tela Salvos
        public int ListaCombinacoesCombinacaoRetornoSalvos(int Indice)
        {
            return ListaCombinacoesSalvos[Indice];
        }
        public string ListaCombinacoesCombinacaoTamanhoQuantidadeSalvos()
        {
            return ListaCombinacoesSalvos.Count.ToString();
        }
        public void ListaCombinacoesCombinacaoAddSalvos(int Indice)
        {
            ListaCombinacoesSalvos.Add(Indice);
        }
        public void ListaCombinacoesCombinacaolimpaSalvos()
        {
            ListaCombinacoesSalvos.Clear();
        }
        //REPETIDAS
        public int ArrayRepetidasRetorno(int coluna)
        {
            return ArrayRepetidos[coluna];
        }
        public string ArrayRepetidaTamanho()
        {
            return ArrayRepetidos.GetLength(0).ToString();
        }
        public string ArrayRepetidaTamanhoQuantidade()
        {
            return ArrayRepetidos.Length.ToString();
        }
        //ARRAY DE SOBRA
        public int ArrayResultadoSobraRetorno(int coluna)
        {
            return ArrayResultadoSobra[coluna];
        }
        public string ArrayResultadoSobraTamanho()
        {
            return ArrayResultadoSobra.GetLength(0).ToString();
        }
        public string ArrayResultadoSobraTamanhoQuantidade()
        {
            return ArrayResultadoSobra.Length.ToString();
        }
    }
}



//public void usoExcel()
//{
//    try
//    {
//Abrir Arquivos Excel Existente
//        var wb = new XLWorkbook(@"D:\Matriz.xlsx");
//        var planilha = wb.Worksheet(1);
//        var linha = 1;
//        var total = "{"; var contador = 0;

//        while (true)
//        {
//            var linhaC1 = planilha.Cell("A" + linha.ToString()).Value.ToString();
//            var linhaC2 = planilha.Cell("B" + linha.ToString()).Value.ToString();
//            var linhaC3 = planilha.Cell("C" + linha.ToString()).Value.ToString();
//            var linhaC4 = planilha.Cell("D" + linha.ToString()).Value.ToString();
//            var linhaC5 = planilha.Cell("E" + linha.ToString()).Value.ToString();
//            var linhaC6 = planilha.Cell("F" + linha.ToString()).Value.ToString();
//            var linhaC7 = planilha.Cell("G" + linha.ToString()).Value.ToString();
//            var linhaC8 = planilha.Cell("H" + linha.ToString()).Value.ToString();
//            var linhaC9 = planilha.Cell("I" + linha.ToString()).Value.ToString();
//            var linhaC10 = planilha.Cell("J" + linha.ToString()).Value.ToString();
//            var linhaC11 = planilha.Cell("K" + linha.ToString()).Value.ToString();
//            var linhaC12 = planilha.Cell("L" + linha.ToString()).Value.ToString();
//            var linhaC13 = planilha.Cell("M" + linha.ToString()).Value.ToString();
//            var linhaC14 = planilha.Cell("N" + linha.ToString()).Value.ToString();
//            var linhaC15 = planilha.Cell("O" + linha.ToString()).Value.ToString();
//            var linhaC16 = planilha.Cell("P" + linha.ToString()).Value.ToString();
//            var linhaC17 = planilha.Cell("Q" + linha.ToString()).Value.ToString();
//            var linhaC18 = planilha.Cell("R" + linha.ToString()).Value.ToString();
//            var linhaC19 = planilha.Cell("S" + linha.ToString()).Value.ToString();
//            var linhaC20 = planilha.Cell("T" + linha.ToString()).Value.ToString();
//            var linhaC21 = planilha.Cell("U" + linha.ToString()).Value.ToString();
//            var linhaC22 = planilha.Cell("V" + linha.ToString()).Value.ToString();
//            var linhaC23 = planilha.Cell("W" + linha.ToString()).Value.ToString();
//            var linhaC24 = planilha.Cell("X" + linha.ToString()).Value.ToString();
//            var linhaC25 = planilha.Cell("Y" + linha.ToString()).Value.ToString();

//            if (string.IsNullOrEmpty(linhaC1) && string.IsNullOrEmpty(linhaC2) && string.IsNullOrEmpty(linhaC3) && string.IsNullOrEmpty(linhaC4)
//                && string.IsNullOrEmpty(linhaC5) && string.IsNullOrEmpty(linhaC6) && string.IsNullOrEmpty(linhaC7) && string.IsNullOrEmpty(linhaC8)
//                && string.IsNullOrEmpty(linhaC9) && string.IsNullOrEmpty(linhaC10) && string.IsNullOrEmpty(linhaC11) && string.IsNullOrEmpty(linhaC12)) break;

//            if (!(string.IsNullOrEmpty(linhaC1)))
//            {
//                contador++;
//                var cell = planilha.Cell("A" + linha.ToString()).Value.ToString();
//                //if(contador == 15){ total = total + cell + "},"; }
//                total = total + cell + ",";
//            }
//            if (!(string.IsNullOrEmpty(linhaC2)))
//            {
//                contador++;
//                var cell = planilha.Cell("B" + linha.ToString()).Value.ToString();
//                if (contador == 15) { total = total + cell + "},"; }
//                total = total + cell + ",";
//            }
//            if (!(string.IsNullOrEmpty(linhaC3)))
//            {
//                contador++;
//                var cell = planilha.Cell("C" + linha.ToString()).Value.ToString();
//                //if (contador == 15) { total = total + cell + "},"; }
//                total = total + cell + ",";
//            }
//            if (!(string.IsNullOrEmpty(linhaC4)))
//            {

//                contador++;
//                var cell = planilha.Cell("D" + linha.ToString()).Value.ToString();
//                //if (contador == 15) {  total = total + cell + "},"; }
//                total = total + cell + ",";
//            }
//            if (!(string.IsNullOrEmpty(linhaC5)))
//            {
//                contador++;
//                var cell = planilha.Cell("E" + linha.ToString()).Value.ToString();
//                //if (contador == 15) { total = total + cell + "},"; }
//                total = total + cell + ",";
//            }
//            if (!(string.IsNullOrEmpty(linhaC6)))
//            {
//                contador++;
//                var cell = planilha.Cell("F" + linha.ToString()).Value.ToString();
//                //if (contador == 15) { total = total + cell + "},"; }
//                total = total + cell + ",";
//            }
//            if (!(string.IsNullOrEmpty(linhaC7)))
//            {
//                contador++;
//                var cell = planilha.Cell("G" + linha.ToString()).Value.ToString();
//                //if (contador == 15) { total = total + cell + "},"; }
//                total = total + cell + ",";
//            }
//            if (!(string.IsNullOrEmpty(linhaC8)))
//            {
//                contador++;
//                var cell = planilha.Cell("H" + linha.ToString()).Value.ToString();
//                //if (contador == 15) { total = total + cell + "},"; }
//                total = total + cell + ",";
//            }
//            if (!(string.IsNullOrEmpty(linhaC9)))
//            {
//                contador++;
//                var cell = planilha.Cell("I" + linha.ToString()).Value.ToString();
//                //if (contador == 15) { total = total + cell + "},"; }
//                total = total + cell + ",";
//            }
//            if (!(string.IsNullOrEmpty(linhaC10)))
//            {
//                contador++;
//                var cell = planilha.Cell("J" + linha.ToString()).Value.ToString();
//                //if (contador == 15) { total = total + cell + "},"; }
//                total = total + cell + ",";
//            }
//            if (!(string.IsNullOrEmpty(linhaC11)))
//            {
//                contador++;
//                var cell = planilha.Cell("K" + linha.ToString()).Value.ToString();
//                //if (contador == 15) { total = total + cell + "},"; }
//                total = total + cell + ",";
//            }
//            if (!(string.IsNullOrEmpty(linhaC12)))
//            {
//                contador++;
//                var cell = planilha.Cell("L" + linha.ToString()).Value.ToString();
//                //if (contador == 15) { total = total + cell + "},"; }
//                total = total + cell + ",";
//            }
//            if (!(string.IsNullOrEmpty(linhaC13)))
//            {
//                contador++;
//                var cell = planilha.Cell("M" + linha.ToString()).Value.ToString();
//                //if (contador == 15) { total = total + cell + "},"; }
//                total = total + cell + ",";
//            }
//            if (!(string.IsNullOrEmpty(linhaC14)))
//            {
//                contador++;
//                var cell = planilha.Cell("N" + linha.ToString()).Value.ToString();
//                //if (contador == 15) { total = total + cell + "},"; }
//                total = total + cell + ",";
//            }
//            if (!(string.IsNullOrEmpty(linhaC15)))
//            {
//                contador++;
//                var cell = planilha.Cell("O" + linha.ToString()).Value.ToString();
//                if (contador == 15) { total = total + cell + "},"; }
//                else { total = total + cell + ","; }
//            }
//            if (!(string.IsNullOrEmpty(linhaC16)))
//            {
//                contador++;
//                var cell = planilha.Cell("P" + linha.ToString()).Value.ToString();
//                if (contador == 15) { total = total + cell + "},"; }
//                else { total = total + cell + ","; }
//            }
//            if (!(string.IsNullOrEmpty(linhaC17)))
//            {
//                contador++;
//                var cell = planilha.Cell("Q" + linha.ToString()).Value.ToString();
//                if (contador == 15) { total = total + cell + "},"; }
//                else { total = total + cell + ","; }
//            }
//            if (!(string.IsNullOrEmpty(linhaC18)))
//            {
//                contador++;
//                var cell = planilha.Cell("R" + linha.ToString()).Value.ToString();
//                if (contador == 15) { total = total + cell + "},"; }
//                else { total = total + cell + ","; }
//            }
//            if (!(string.IsNullOrEmpty(linhaC19)))
//            {
//                contador++;
//                var cell = planilha.Cell("S" + linha.ToString()).Value.ToString();
//                if (contador == 15) { total = total + cell + "},"; }
//                else { total = total + cell + ","; }
//            }
//            if (!(string.IsNullOrEmpty(linhaC20)))
//            {
//                contador++;
//                var cell = planilha.Cell("T" + linha.ToString()).Value.ToString();
//                if (contador == 15) { total = total + cell + "},"; }
//                else { total = total + cell + ","; }
//            }
//            if (!(string.IsNullOrEmpty(linhaC21)))
//            {
//                contador++;
//                var cell = planilha.Cell("U" + linha.ToString()).Value.ToString();
//                if (contador == 15) { total = total + cell + "},"; }
//                else { total = total + cell + ","; }
//            }
//            if (!(string.IsNullOrEmpty(linhaC22)))
//            {
//                contador++;
//                var cell = planilha.Cell("V" + linha.ToString()).Value.ToString();
//                if (contador == 15) { total = total + cell + "},"; }
//                else { total = total + cell + ","; }
//            }
//            if (!(string.IsNullOrEmpty(linhaC23)))
//            {
//                contador++;
//                var cell = planilha.Cell("W" + linha.ToString()).Value.ToString();
//                if (contador == 15) { total = total + cell + "},"; }
//                else { total = total + cell + ","; }
//            }
//            if (!(string.IsNullOrEmpty(linhaC24)))
//            {
//                contador++;
//                var cell = planilha.Cell("X" + linha.ToString()).Value.ToString();
//                if (contador == 15) { total = total + cell + "},"; }
//                else { total = total + cell + ","; }
//            }
//            if (!(string.IsNullOrEmpty(linhaC25)))
//            {
//                contador++;
//                var cell = planilha.Cell("Y" + linha.ToString()).Value.ToString();
//                if (contador == 15) { total = total + cell + "},"; }
//                else { total = total + cell + ","; }
//            }

//            Console.WriteLine("     /* " + linha.ToString() + " */ " + total);
//            total = "{";
//            contador = 0;
//            linha++;
//        }
//    }
//    catch (Exception ex) { ex.ToString(); }
//}



















//public void CombinacoesEscolhidas2(int PI, int R, int M, int P, int F, int M3)
//{
//    try
//    {
//        limpaCombinacoesEscolhidas();
//        Boolean ativado = false;
//        int[,] CopiaArrayJogosCombinacao = (int[,])ArrayJogosCombinacao.Clone();
//        int inicio = int.Parse(CopiaArrayJogosCombinacao.GetLength(0).ToString());
//        int[,] ArrayTemp = new int[inicio, 15];
//        int[,] ArrayTempAmazena = new int[20, 15];

//        if (checkBoxPI.Checked == true)
//        {
//            int par = 0, impar = 0;
//            int cont = 0, cont2 = 0;
//            int adiciona = 0;
//            if (PI == 1) { par = 7; impar = 8; }
//            if (PI == 2) { par = 8; impar = 7; }
//            if (PI == 3) { par = 6; impar = 9; }
//            if (PI == 4) { par = 9; impar = 6; }
//            if (PI == 5) { par = 5; impar = 10; }
//            if (PI == 6) { par = 10; impar = 5; }
//            if (PI == 7) { par = 4; impar = 11; }
//            if (PI == 8) { par = 11; impar = 4; }
//            if (PI == 9) { par = 3; impar = 12; }
//            if (PI == 10) { par = 12; impar = 3; }
//            if (PI == 11) { par = 2; impar = 13; }

//            for (int i = 0; i < int.Parse(CopiaArrayJogosCombinacao.GetLength(0).ToString()); i++)
//            {
//                if (CopiaArrayJogosCombinacao[i, 0] == 0)
//                {
//                    i = int.Parse(CopiaArrayJogosCombinacao.GetLength(0).ToString());
//                }
//                else
//                {
//                    for (int coluna = 0; coluna < 15; coluna++)
//                    {
//                        if (CopiaArrayJogosCombinacao[i, coluna] % 2 == 0)
//                        {//par
//                            cont++;
//                        }
//                        else
//                        {//impar
//                            cont2++;
//                        }
//                    }
//                    if ((par == cont) && (impar == cont2))
//                    {
//                        for (int coluna = 0; coluna < 15; coluna++)
//                        {
//                            if (coluna < 15)
//                            {
//                                ArrayTemp[adiciona, coluna] = CopiaArrayJogosCombinacao[i, coluna];
//                            }
//                        }
//                        adiciona++;
//                    }
//                    cont = 0; cont2 = 0;
//                }
//            }
//            ativado = true;
//            for (int linha = 0; linha < int.Parse(ArrayTemp.GetLength(0).ToString()); linha++)
//            {
//                if (ArrayTemp[linha, 0] == 0)
//                {
//                    int tamanhho = linha;
//                    ArrayTempAmazena = new int[tamanhho, 15];
//                    linha = int.Parse(ArrayTemp.GetLength(0).ToString());
//                }
//            }
//            for (int linha = 0; linha < int.Parse(ArrayTemp.GetLength(0).ToString()); linha++)
//            {
//                if (ArrayTemp[linha, 0] == 0)
//                {
//                    linha = int.Parse(ArrayTemp.GetLength(0).ToString());
//                }
//                else
//                {
//                    for (int coluna = 0; coluna < 15; coluna++)
//                    {
//                        ArrayTempAmazena[linha, coluna] = ArrayTemp[linha, coluna];
//                    }
//                }
//            }
//        }
//        if (checkBoxNumeroRepetidos.Checked == true)
//        {
//            int cont = 0;
//            int repeticao = 0;
//            int Adiciona = 0;

//            if (R == 1) { repeticao = 9; }
//            if (R == 2) { repeticao = 8; }
//            if (R == 3) { repeticao = 10; }
//            if (R == 4) { repeticao = 7; }
//            if (R == 5) { repeticao = 11; }
//            if (R == 6) { repeticao = 12; }
//            if (R == 7) { repeticao = 6; }
//            if (R == 8) { repeticao = 13; }
//            if (R == 9) { repeticao = 14; }
//            if (R == 10) { repeticao = 15; }

//            if (ativado == true)
//            {
//                ArrayTemp = new int[int.Parse(ArrayTempAmazena.GetLength(0).ToString()), 15];
//                for (int linha = 0; linha < int.Parse(ArrayTempAmazena.GetLength(0).ToString()); linha++)
//                {
//                    if (ArrayTempAmazena[linha, 0] == 0)
//                    {
//                        linha = int.Parse(ArrayTempAmazena.GetLength(0).ToString());
//                    }
//                    else
//                    {
//                        if (checkBoxAtivado.Checked == true)
//                        {
//                            for (int coluna = 0; coluna < 15; coluna++)
//                            {
//                                for (int arrayM = 0; arrayM < ArrayRepetidos.Length; arrayM++)
//                                {
//                                    if (ArrayTempAmazena[linha, coluna] == ArrayRepetidos[arrayM]) { cont++; }
//                                }
//                            }
//                            for (int coluna = 0; coluna < 15; coluna++)
//                            {
//                                for (int e = 0; e < ArrayResultadoSobra.Length; e++)
//                                {
//                                    if (ArrayJogosCombinacao[linha, coluna] == ArrayResultadoSobra[e])
//                                    {
//                                        e = ArrayResultadoSobra.Length;
//                                        quantidade++;
//                                    }
//                                    else
//                                    {
//                                        if (ArrayResultadoSobra[e] > ArrayJogosCombinacao[linha, coluna])
//                                        {
//                                            e = ArrayResultadoSobra.Length;
//                                        }
//                                    }
//                                }
//                            }
//                            if ((cont == repeticao) && (MinimoElemento <= quantidade) && (quantidade <= maximoElemento))
//                            {
//                                for (int coluna = 0; coluna < 15; coluna++)
//                                {
//                                    if (coluna < 15)
//                                    {
//                                        ArrayTemp[Adiciona, coluna] = ArrayTempAmazena[linha, coluna];
//                                    }
//                                }
//                                Adiciona++;
//                            }
//                            quantidade = 0;
//                            cont = 0;
//                        }
//                        else
//                        {
//                            for (int coluna = 0; coluna < 15; coluna++)
//                            {
//                                for (int arrayM = 0; arrayM < ArrayRepetidos.Length; arrayM++)
//                                {
//                                    if (ArrayTempAmazena[linha, coluna] == ArrayRepetidos[arrayM]) { cont++; }
//                                }
//                            }
//                            if (cont == repeticao)
//                            {
//                                for (int coluna = 0; coluna < 15; coluna++)
//                                {
//                                    if (coluna < 15)
//                                    {
//                                        ArrayTemp[Adiciona, coluna] = ArrayTempAmazena[linha, coluna];
//                                    }
//                                }
//                                Adiciona++;
//                            }
//                            cont = 0;
//                        }

//                    }
//                }
//                for (int linha = 0; linha < int.Parse(ArrayTemp.GetLength(0).ToString()); linha++)
//                {
//                    if (ArrayTemp[linha, 0] == 0)
//                    {
//                        int tamanhho = linha;
//                        ArrayTempAmazena = new int[tamanhho, 15];
//                        linha = int.Parse(ArrayTemp.GetLength(0).ToString());
//                    }
//                }
//                for (int linha = 0; linha < int.Parse(ArrayTemp.GetLength(0).ToString()); linha++)
//                {
//                    if (ArrayTemp[linha, 0] == 0)
//                    {
//                        linha = int.Parse(ArrayTemp.GetLength(0).ToString());
//                    }
//                    else
//                    {
//                        for (int coluna = 0; coluna < 15; coluna++)
//                        {
//                            ArrayTempAmazena[linha, coluna] = ArrayTemp[linha, coluna];
//                        }
//                    }
//                }
//            }
//            else
//            {
//                for (int i = 0; i < int.Parse(CopiaArrayJogosCombinacao.GetLength(0).ToString()); i++)
//                {
//                    if (CopiaArrayJogosCombinacao[i, 0] == 0)
//                    {
//                        i = int.Parse(CopiaArrayJogosCombinacao.GetLength(0).ToString());
//                    }
//                    else
//                    {
//                        if (checkBoxAtivado.Checked == true)
//                        {
//                            for (int coluna = 0; coluna < 15; coluna++)
//                            {
//                                for (int arrayM = 0; arrayM < ArrayRepetidos.Length; arrayM++)
//                                {
//                                    if (ArrayJogosCombinacao[i, coluna] == ArrayRepetidos[arrayM]) { cont++; }
//                                }
//                            }
//                            for (int coluna = 0; coluna < 15; coluna++)
//                            {
//                                for (int e = 0; e < ArrayResultadoSobra.Length; e++)
//                                {
//                                    if (ArrayJogosCombinacao[i, coluna] == ArrayResultadoSobra[e])
//                                    {
//                                        e = ArrayResultadoSobra.Length;
//                                        quantidade++;
//                                    }
//                                    else
//                                    {
//                                        if (ArrayResultadoSobra[e] > ArrayJogosCombinacao[i, coluna])
//                                        {
//                                            e = ArrayResultadoSobra.Length;
//                                        }
//                                    }
//                                }
//                            }
//                            if ((cont == repeticao) && (MinimoElemento <= quantidade) && (quantidade <= maximoElemento))
//                            {
//                                for (int coluna = 0; coluna < 15; coluna++)
//                                {
//                                    if (coluna < 15)
//                                    {
//                                        ArrayTemp[Adiciona, coluna] = CopiaArrayJogosCombinacao[i, coluna];
//                                    }
//                                }
//                                Adiciona++;
//                            }
//                            cont = 0;
//                            quantidade = 0;
//                        }
//                        else
//                        {
//                            for (int coluna = 0; coluna < 15; coluna++)
//                            {
//                                for (int arrayM = 0; arrayM < ArrayRepetidos.Length; arrayM++)
//                                {
//                                    if (ArrayJogosCombinacao[i, coluna] == ArrayRepetidos[arrayM]) { cont++; }
//                                }
//                            }
//                            if (cont == repeticao)
//                            {
//                                for (int coluna = 0; coluna < 15; coluna++)
//                                {
//                                    if (coluna < 15)
//                                    {
//                                        ArrayTemp[Adiciona, coluna] = CopiaArrayJogosCombinacao[i, coluna];
//                                    }
//                                }
//                                Adiciona++;
//                            }
//                            cont = 0;
//                        }
//                    }
//                }
//                ativado = true;
//                for (int linha = 0; linha < int.Parse(ArrayTemp.GetLength(0).ToString()); linha++)
//                {
//                    if (ArrayTemp[linha, 0] == 0)
//                    {
//                        int tamanhho = linha;
//                        ArrayTempAmazena = new int[tamanhho, 15];
//                        linha = int.Parse(ArrayTemp.GetLength(0).ToString());
//                    }
//                }
//                for (int linha = 0; linha < int.Parse(ArrayTemp.GetLength(0).ToString()); linha++)
//                {
//                    if (ArrayTemp[linha, 0] == 0)
//                    {
//                        linha = int.Parse(ArrayTemp.GetLength(0).ToString());
//                    }
//                    else
//                    {
//                        for (int coluna = 0; coluna < 15; coluna++)
//                        {
//                            ArrayTempAmazena[linha, coluna] = ArrayTemp[linha, coluna];
//                        }
//                    }
//                }
//            }
//        }
//        if (checkBoxMoldura.Checked == true)
//        {
//            int cont = 0;
//            int modula = 0;
//            int Adiciona = 0;
//            int[] ArrayMoldura = new int[] { 1, 2, 3, 4, 5, 6, 10, 11, 15, 16, 20, 21, 22, 23, 24, 25 };

//            if (M == 1) { modula = 10; }
//            if (M == 2) { modula = 9; }
//            if (M == 3) { modula = 11; }
//            if (M == 4) { modula = 8; }
//            if (M == 5) { modula = 12; }
//            if (M == 6) { modula = 7; }
//            if (M == 7) { modula = 13; }
//            if (M == 8) { modula = 6; }
//            if (M == 9) { modula = 14; }
//            if (M == 10) { modula = 15; }

//            if (ativado == true)
//            {
//                ArrayTemp = new int[int.Parse(ArrayTempAmazena.GetLength(0).ToString()), 15];
//                for (int linha = 0; linha < int.Parse(ArrayTempAmazena.GetLength(0).ToString()); linha++)
//                {
//                    if (ArrayTempAmazena[linha, 0] == 0)
//                    {
//                        linha = int.Parse(ArrayTempAmazena.GetLength(0).ToString());
//                    }
//                    else
//                    {
//                        for (int coluna = 0; coluna < 15; coluna++)
//                        {
//                            for (int arrayM = 0; arrayM < ArrayMoldura.Length; arrayM++)
//                            {
//                                if (ArrayTempAmazena[linha, coluna] == ArrayMoldura[arrayM]) { cont++; }
//                            }
//                        }
//                        if (cont == modula)
//                        {
//                            for (int coluna = 0; coluna < 15; coluna++)
//                            {
//                                if (coluna < 15)
//                                {
//                                    ArrayTemp[Adiciona, coluna] = ArrayTempAmazena[linha, coluna];
//                                }
//                            }
//                            Adiciona++;
//                        }
//                        cont = 0;
//                    }
//                }
//                for (int linha = 0; linha < int.Parse(ArrayTemp.GetLength(0).ToString()); linha++)
//                {
//                    if (ArrayTemp[linha, 0] == 0)
//                    {
//                        int tamanhho = linha;
//                        ArrayTempAmazena = new int[tamanhho, 15];
//                        linha = int.Parse(ArrayTemp.GetLength(0).ToString());
//                    }
//                }
//                for (int linha = 0; linha < int.Parse(ArrayTemp.GetLength(0).ToString()); linha++)
//                {
//                    if (ArrayTemp[linha, 0] == 0)
//                    {
//                        linha = int.Parse(ArrayTemp.GetLength(0).ToString());
//                    }
//                    else
//                    {
//                        for (int coluna = 0; coluna < 15; coluna++)
//                        {
//                            ArrayTempAmazena[linha, coluna] = ArrayTemp[linha, coluna];
//                        }
//                    }
//                }
//            }
//            else
//            {
//                for (int i = 0; i < int.Parse(CopiaArrayJogosCombinacao.GetLength(0).ToString()); i++)
//                {
//                    if (CopiaArrayJogosCombinacao[i, 0] == 0)
//                    {
//                        i = int.Parse(CopiaArrayJogosCombinacao.GetLength(0).ToString());
//                    }
//                    else
//                    {
//                        for (int coluna = 0; coluna < 15; coluna++)
//                        {
//                            for (int arrayM = 0; arrayM < ArrayMoldura.Length; arrayM++)
//                            {
//                                if (ArrayJogosCombinacao[i, coluna] == ArrayMoldura[arrayM]) { cont++; }
//                            }
//                        }
//                        if (cont == modula)
//                        {
//                            for (int coluna = 0; coluna < 15; coluna++)
//                            {
//                                if (coluna < 15)
//                                {
//                                    ArrayTemp[Adiciona, coluna] = CopiaArrayJogosCombinacao[i, coluna];
//                                }
//                            }
//                            Adiciona++;
//                        }
//                        cont = 0;
//                    }
//                }
//                ativado = true;
//                for (int linha = 0; linha < int.Parse(ArrayTemp.GetLength(0).ToString()); linha++)
//                {
//                    if (ArrayTemp[linha, 0] == 0)
//                    {
//                        int tamanhho = linha;
//                        ArrayTempAmazena = new int[tamanhho, 15];
//                        linha = int.Parse(ArrayTemp.GetLength(0).ToString());
//                    }
//                }
//                for (int linha = 0; linha < int.Parse(ArrayTemp.GetLength(0).ToString()); linha++)
//                {
//                    if (ArrayTemp[linha, 0] == 0)
//                    {
//                        linha = int.Parse(ArrayTemp.GetLength(0).ToString());
//                    }
//                    else
//                    {
//                        for (int coluna = 0; coluna < 15; coluna++)
//                        {
//                            ArrayTempAmazena[linha, coluna] = ArrayTemp[linha, coluna];
//                        }
//                    }
//                }
//            }
//        }
//        if (checkBoxPrimos.Checked == true)
//        {
//            int cont = 0;
//            int primos = 0;
//            int Adiciona = 0;
//            int[] ArrayPrimos = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23 };

//            if (P == 1) { primos = 5; }
//            if (P == 2) { primos = 6; }
//            if (P == 3) { primos = 4; }
//            if (P == 4) { primos = 7; }
//            if (P == 5) { primos = 3; }
//            if (P == 6) { primos = 8; }
//            if (P == 7) { primos = 2; }
//            if (P == 8) { primos = 9; }
//            if (P == 9) { primos = 1; }
//            if (P == 10) { primos = 0; }

//            if (ativado == true)
//            {
//                ArrayTemp = new int[int.Parse(ArrayTempAmazena.GetLength(0).ToString()), 15];
//                for (int linha = 0; linha < int.Parse(ArrayTempAmazena.GetLength(0).ToString()); linha++)
//                {
//                    if (ArrayTempAmazena[linha, 0] == 0)
//                    {
//                        linha = int.Parse(ArrayTempAmazena.GetLength(0).ToString());
//                    }
//                    else
//                    {
//                        for (int coluna = 0; coluna < 15; coluna++)
//                        {
//                            for (int arrayM = 0; arrayM < ArrayPrimos.Length; arrayM++)
//                            {
//                                if (ArrayTempAmazena[linha, coluna] == ArrayPrimos[arrayM]) { cont++; }
//                            }
//                        }
//                        if (cont == primos)
//                        {
//                            for (int coluna = 0; coluna < 15; coluna++)
//                            {
//                                if (coluna < 15)
//                                {
//                                    ArrayTemp[Adiciona, coluna] = ArrayTempAmazena[linha, coluna];
//                                }
//                            }
//                            Adiciona++;
//                        }
//                        cont = 0;
//                    }
//                }
//                for (int linha = 0; linha < int.Parse(ArrayTemp.GetLength(0).ToString()); linha++)
//                {
//                    if (ArrayTemp[linha, 0] == 0)
//                    {
//                        int tamanhho = linha;
//                        ArrayTempAmazena = new int[tamanhho, 15];
//                        linha = int.Parse(ArrayTemp.GetLength(0).ToString());
//                    }
//                }
//                for (int linha = 0; linha < int.Parse(ArrayTemp.GetLength(0).ToString()); linha++)
//                {
//                    if (ArrayTemp[linha, 0] == 0)
//                    {
//                        linha = int.Parse(ArrayTemp.GetLength(0).ToString());
//                    }
//                    else
//                    {
//                        for (int coluna = 0; coluna < 15; coluna++)
//                        {
//                            ArrayTempAmazena[linha, coluna] = ArrayTemp[linha, coluna];
//                        }
//                    }
//                }
//            }
//            else
//            {
//                for (int i = 0; i < int.Parse(CopiaArrayJogosCombinacao.GetLength(0).ToString()); i++)
//                {
//                    if (CopiaArrayJogosCombinacao[i, 0] == 0)
//                    {
//                        i = int.Parse(CopiaArrayJogosCombinacao.GetLength(0).ToString());
//                    }
//                    else
//                    {
//                        for (int coluna = 0; coluna < 15; coluna++)
//                        {
//                            for (int arrayM = 0; arrayM < ArrayPrimos.Length; arrayM++)
//                            {
//                                if (ArrayJogosCombinacao[i, coluna] == ArrayPrimos[arrayM]) { cont++; }
//                            }
//                        }
//                        if (cont == primos)
//                        {
//                            for (int coluna = 0; coluna < 15; coluna++)
//                            {
//                                if (coluna < 15)
//                                {
//                                    ArrayTemp[Adiciona, coluna] = CopiaArrayJogosCombinacao[i, coluna];
//                                }
//                            }
//                            Adiciona++;
//                        }
//                        cont = 0;
//                    }
//                }
//                ativado = true;
//                for (int linha = 0; linha < int.Parse(ArrayTemp.GetLength(0).ToString()); linha++)
//                {
//                    if (ArrayTemp[linha, 0] == 0)
//                    {
//                        int tamanhho = linha;
//                        ArrayTempAmazena = new int[tamanhho, 15];
//                        linha = int.Parse(ArrayTemp.GetLength(0).ToString());
//                    }
//                }
//                for (int linha = 0; linha < int.Parse(ArrayTemp.GetLength(0).ToString()); linha++)
//                {
//                    if (ArrayTemp[linha, 0] == 0)
//                    {
//                        linha = int.Parse(ArrayTemp.GetLength(0).ToString());
//                    }
//                    else
//                    {
//                        for (int coluna = 0; coluna < 15; coluna++)
//                        {
//                            ArrayTempAmazena[linha, coluna] = ArrayTemp[linha, coluna];
//                        }
//                    }
//                }
//            }
//        }
//        if (checkBoxNumerosFibonacci.Checked == true)
//        {
//            int cont = 0;
//            int Fibonnacci = 0;
//            int Adiciona = 0;
//            int[] Fibonacci = new int[] { 1, 2, 3, 5, 8, 13, 21 };

//            if (F == 1) { Fibonnacci = 4; }
//            if (F == 2) { Fibonnacci = 5; }
//            if (F == 3) { Fibonnacci = 3; }
//            if (F == 4) { Fibonnacci = 6; }
//            if (F == 5) { Fibonnacci = 2; }
//            if (F == 6) { Fibonnacci = 7; }
//            if (F == 7) { Fibonnacci = 1; }
//            if (F == 8) { Fibonnacci = 0; }

//            if (ativado == true)
//            {
//                ArrayTemp = new int[int.Parse(ArrayTempAmazena.GetLength(0).ToString()), 15];
//                for (int linha = 0; linha < int.Parse(ArrayTempAmazena.GetLength(0).ToString()); linha++)
//                {
//                    if (ArrayTempAmazena[linha, 0] == 0)
//                    {
//                        linha = int.Parse(ArrayTempAmazena.GetLength(0).ToString());
//                    }
//                    else
//                    {
//                        for (int coluna = 0; coluna < 15; coluna++)
//                        {
//                            for (int arrayM = 0; arrayM < Fibonacci.Length; arrayM++)
//                            {
//                                if (ArrayTempAmazena[linha, coluna] == Fibonacci[arrayM]) { cont++; }
//                            }
//                        }
//                        if (cont == Fibonnacci)
//                        {
//                            for (int coluna = 0; coluna < 15; coluna++)
//                            {
//                                if (coluna < 15)
//                                {
//                                    ArrayTemp[Adiciona, coluna] = ArrayTempAmazena[linha, coluna];
//                                }
//                            }
//                            Adiciona++;
//                        }
//                        cont = 0;
//                    }
//                }
//                for (int linha = 0; linha < int.Parse(ArrayTemp.GetLength(0).ToString()); linha++)
//                {
//                    if (ArrayTemp[linha, 0] == 0)
//                    {
//                        int tamanhho = linha;
//                        ArrayTempAmazena = new int[tamanhho, 15];
//                        linha = int.Parse(ArrayTemp.GetLength(0).ToString());
//                    }
//                }
//                for (int linha = 0; linha < int.Parse(ArrayTemp.GetLength(0).ToString()); linha++)
//                {
//                    if (ArrayTemp[linha, 0] == 0)
//                    {
//                        linha = int.Parse(ArrayTemp.GetLength(0).ToString());
//                    }
//                    else
//                    {
//                        for (int coluna = 0; coluna < 15; coluna++)
//                        {
//                            ArrayTempAmazena[linha, coluna] = ArrayTemp[linha, coluna];
//                        }
//                    }
//                }
//            }
//            else
//            {
//                for (int i = 0; i < int.Parse(CopiaArrayJogosCombinacao.GetLength(0).ToString()); i++)
//                {
//                    if (CopiaArrayJogosCombinacao[i, 0] == 0)
//                    {
//                        i = int.Parse(CopiaArrayJogosCombinacao.GetLength(0).ToString());
//                    }
//                    else
//                    {
//                        for (int coluna = 0; coluna < 15; coluna++)
//                        {
//                            for (int arrayM = 0; arrayM < Fibonacci.Length; arrayM++)
//                            {
//                                if (ArrayJogosCombinacao[i, coluna] == Fibonacci[arrayM]) { cont++; }
//                            }
//                        }
//                        if (cont == Fibonnacci)
//                        {
//                            for (int coluna = 0; coluna < 15; coluna++)
//                            {
//                                if (coluna < 15)
//                                {
//                                    ArrayTemp[Adiciona, coluna] = CopiaArrayJogosCombinacao[i, coluna];
//                                }
//                            }
//                            Adiciona++;
//                        }
//                        cont = 0;
//                    }
//                }
//                ativado = true;
//                for (int linha = 0; linha < int.Parse(ArrayTemp.GetLength(0).ToString()); linha++)
//                {
//                    if (ArrayTemp[linha, 0] == 0)
//                    {
//                        int tamanhho = linha;
//                        ArrayTempAmazena = new int[tamanhho, 15];
//                        linha = int.Parse(ArrayTemp.GetLength(0).ToString());
//                    }
//                }
//                for (int linha = 0; linha < int.Parse(ArrayTemp.GetLength(0).ToString()); linha++)
//                {
//                    if (ArrayTemp[linha, 0] == 0)
//                    {
//                        linha = int.Parse(ArrayTemp.GetLength(0).ToString());
//                    }
//                    else
//                    {
//                        for (int coluna = 0; coluna < 15; coluna++)
//                        {
//                            ArrayTempAmazena[linha, coluna] = ArrayTemp[linha, coluna];
//                        }
//                    }
//                }
//            }
//        }
//        if (checkBoxMultiploDe3.Checked == true)
//        {
//            int cont = 0;
//            int Mult = 0;
//            int Adiciona = 0;
//            int[] ArrayMult = new int[] { 3, 6, 9, 12, 15, 18, 21, 24 };

//            if (M == 1) { Mult = 5; }
//            if (M == 2) { Mult = 4; }
//            if (M == 3) { Mult = 6; }
//            if (M == 4) { Mult = 3; }
//            if (M == 5) { Mult = 7; }
//            if (M == 6) { Mult = 2; }
//            if (M == 7) { Mult = 8; }
//            if (M == 8) { Mult = 1; }

//            if (ativado == true)
//            {
//                ArrayTemp = new int[int.Parse(ArrayTempAmazena.GetLength(0).ToString()), 15];
//                for (int linha = 0; linha < int.Parse(ArrayTempAmazena.GetLength(0).ToString()); linha++)
//                {
//                    if (ArrayTempAmazena[linha, 0] == 0)
//                    {
//                        linha = int.Parse(ArrayTempAmazena.GetLength(0).ToString());
//                    }
//                    else
//                    {
//                        for (int coluna = 0; coluna < 15; coluna++)
//                        {
//                            for (int arrayM = 0; arrayM < ArrayMult.Length; arrayM++)
//                            {
//                                if (ArrayTempAmazena[linha, coluna] == ArrayMult[arrayM]) { cont++; }
//                            }
//                        }
//                        if (cont == Mult)
//                        {
//                            for (int coluna = 0; coluna < 15; coluna++)
//                            {
//                                if (coluna < 15)
//                                {
//                                    ArrayTemp[Adiciona, coluna] = ArrayTempAmazena[linha, coluna];
//                                }
//                            }
//                            Adiciona++;
//                        }
//                        cont = 0;
//                    }
//                }
//                for (int linha = 0; linha < int.Parse(ArrayTemp.GetLength(0).ToString()); linha++)
//                {
//                    if (ArrayTemp[linha, 0] == 0)
//                    {
//                        int tamanhho = linha;
//                        ArrayTempAmazena = new int[tamanhho, 15];
//                        linha = int.Parse(ArrayTemp.GetLength(0).ToString());
//                    }
//                }
//                for (int linha = 0; linha < int.Parse(ArrayTemp.GetLength(0).ToString()); linha++)
//                {
//                    if (ArrayTemp[linha, 0] == 0)
//                    {
//                        linha = int.Parse(ArrayTemp.GetLength(0).ToString());
//                    }
//                    else
//                    {
//                        for (int coluna = 0; coluna < 15; coluna++)
//                        {
//                            ArrayTempAmazena[linha, coluna] = ArrayTemp[linha, coluna];
//                        }
//                    }
//                }
//            }
//            else
//            {
//                for (int i = 0; i < int.Parse(CopiaArrayJogosCombinacao.GetLength(0).ToString()); i++)
//                {
//                    if (CopiaArrayJogosCombinacao[i, 0] == 0)
//                    {
//                        i = int.Parse(CopiaArrayJogosCombinacao.GetLength(0).ToString());
//                    }
//                    else
//                    {
//                        for (int coluna = 0; coluna < 15; coluna++)
//                        {
//                            for (int arrayM = 0; arrayM < ArrayMult.Length; arrayM++)
//                            {
//                                if (ArrayJogosCombinacao[i, coluna] == ArrayMult[arrayM]) { cont++; }
//                            }
//                        }
//                        if (cont == Mult)
//                        {
//                            for (int coluna = 0; coluna < 15; coluna++)
//                            {
//                                if (coluna < 15)
//                                {
//                                    ArrayTemp[Adiciona, coluna] = CopiaArrayJogosCombinacao[i, coluna];
//                                }
//                            }
//                            Adiciona++;
//                        }
//                        cont = 0;
//                    }
//                }
//                ativado = true;
//                for (int linha = 0; linha < int.Parse(ArrayTemp.GetLength(0).ToString()); linha++)
//                {
//                    if (ArrayTemp[linha, 0] == 0)
//                    {
//                        int tamanhho = linha;
//                        ArrayTempAmazena = new int[tamanhho, 15];
//                        linha = int.Parse(ArrayTemp.GetLength(0).ToString());
//                    }
//                }
//                for (int linha = 0; linha < int.Parse(ArrayTemp.GetLength(0).ToString()); linha++)
//                {
//                    if (ArrayTemp[linha, 0] == 0)
//                    {
//                        linha = int.Parse(ArrayTemp.GetLength(0).ToString());
//                    }
//                    else
//                    {
//                        for (int coluna = 0; coluna < 15; coluna++)
//                        {
//                            ArrayTempAmazena[linha, coluna] = ArrayTemp[linha, coluna];
//                        }
//                    }
//                }
//            }
//        }
//        for (int linha = 0; linha < int.Parse(ArrayTempAmazena.GetLength(0).ToString()); linha++)
//        {   //linha data + 1
//            dataGridViewCombinacoesEscolhidas.Rows[dataGridViewCombinacoesEscolhidas.Rows.Count - 1].Cells[0].Value = dataGridViewCombinacoesEscolhidas.Rows.Count - 1;

//            for (int coluna = 0; coluna < 15; coluna++)
//            {
//                dataGridViewCombinacoesEscolhidas.Rows[dataGridViewCombinacoesEscolhidas.Rows.Count - 1].Cells[coluna + 1].Value = ArrayTempAmazena[linha, coluna];
//            }
//            dataGridViewCombinacoesEscolhidas.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");

//        }
//    }
//    catch (Exception ex)
//    {
//        ex.ToString();
//    }
//}