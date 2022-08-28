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
using System.Net.Http;
using DocumentFormat.OpenXml.Vml.Office;
using System.Xml;
using System.IO;
using System.Drawing.Imaging;
using DocumentFormat.OpenXml.Office.Excel;
using ClosedXML.Excel;
using System.IO.Packaging;
using OfficeOpenXml;
using Spire.Xls;


namespace GeradorLotericaHexen
{
    public partial class FormSecundaria : Form
    {
        public int MODO = 0;
        public int modo
        {
            get
            {
                return this.MODO;

            }
            set
            {
                this.MODO = value;
            }
        }
        public int MINIMO_LINHA = 0;
        public int MinimoLinha
        {
            get
            {
                return this.MINIMO_LINHA;

            }
            set
            {
                this.MINIMO_LINHA = value;
            }
        }
        private int MAXIMO_LINHA = 0;
        public int MaximoLinha
        {
            get
            {
                return this.MAXIMO_LINHA;

            }
            set
            {
                this.MAXIMO_LINHA = value;
            }
        }
        private string JOGO_REPETIDO = "";
        public string Jogos_Repetido
        {
            get
            {
                return this.JOGO_REPETIDO;

            }
            set
            {
                this.JOGO_REPETIDO = value;
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
        private Boolean NUMEROS_PESQUISAS = false;
        public Boolean NumerosPesquisas
        {
            get
            {
                return this.NUMEROS_PESQUISAS;

            }
            set
            {
                this.NUMEROS_PESQUISAS = value;
            }
        }

        //Lista de elementos
        List<int> ListaCombinacoes = new List<int>();

        //Lista Todos os Selecionado
        List<int> ListaTodosSelecionados = new List<int>();

        List<int> ElementosListaConsta = new List<int>();

        ResultadosLotofacil arraysJogos = new ResultadosLotofacil();

        public TelaPrincipal FormPrincipal;
        public FormSecundaria(TelaPrincipal Form,int Modo1)
        {
            try
            {
                InitializeComponent();
                this.FormPrincipal = Form;
                this.modo = Modo1;
                this.MinimoLinha = 173;
                this.MaximoLinha = 220;
                dataGridViewCombinacoes.Rows.Add("","", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                dataGridViewJogos.Rows.Add("","", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                linhasColunasSelecionado();
                demostracaoLimpo();
                demostracaoLimpo2();

                if (modo == 1) { ListadataGridViewSelecionadoTodos(); }
                if (modo == 2) { ListadataGridViewCombinacoesEscolhidasTodos(); }
                label42.Text = "QUANT: " + Convert.ToString(dataGridViewCombinacoes.Rows.Count - 1);
                ListadataGridViewEscolhasJogos();
                ArmazenarResultadoLista();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("2 " + ex.ToString());
            }
        }
        public FormSecundaria(TelaPrincipal Form, int Modo, int minimo, int maximo)
        {
            try
            {
                InitializeComponent();

                this.FormPrincipal = Form;
                this.modo = Modo;
                this.MinimoLinha = minimo;
                this.MaximoLinha = maximo;
                dataGridViewCombinacoes.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                dataGridViewJogos.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                linhasColunasSelecionado();
                demostracaoLimpo();
                demostracaoLimpo2();
                if (Modo == 1) { ListadataGridViewSelecionadoTodos(); }
                if (Modo == 2) { ListadataGridViewCombinacoesEscolhidasTodos(); }
                label42.Text = "QUANT: " + Convert.ToString(dataGridViewCombinacoes.Rows.Count - 1);
                ListadataGridViewEscolhasJogos();
                ArmazenarResultadoLista();
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
        public void linhasColunasSelecionado()
        {
            dataGridViewLinhaColuna.Rows.Add(" 1", " 2", " 3", " 4", " 5");
            dataGridViewLinhaColuna.Rows.Add(" 6", " 7", " 8", " 9", "10");
            dataGridViewLinhaColuna.Rows.Add("11", "12", "13", "14", "15");
            dataGridViewLinhaColuna.Rows.Add("16", "17", "18", "19", "20");
            dataGridViewLinhaColuna.Rows.Add("21", "22", "23", "24", "25");
            dataGridViewLinhaColuna.Rows.Add("", "", "", "", "");

            dataGridViewLinhaColuna2.Rows.Add(" 1", " 2", " 3", " 4", " 5");
            dataGridViewLinhaColuna2.Rows.Add(" 6", " 7", " 8", " 9", "10");
            dataGridViewLinhaColuna2.Rows.Add("11", "12", "13", "14", "15");
            dataGridViewLinhaColuna2.Rows.Add("16", "17", "18", "19", "20");
            dataGridViewLinhaColuna2.Rows.Add("21", "22", "23", "24", "25");
            dataGridViewLinhaColuna2.Rows.Add("", "", "", "", "");
        }
        public void NumerosSelecionados()
        {
            try
            {
                for (int i = 1; i <= 25; i++)
                {
                    //Painel Resultado Jogo
                    string textBoxEntrada = "circularButton";
                    StringBuilder sb = new StringBuilder(textBoxEntrada);
                    sb.Append(+i);
                    Panel panel = Application.OpenForms["FormSecundaria"].Controls["panelNumeros3"] as Panel;
                    Button Button = panel.Controls[sb.ToString()] as Button;
                    if (Button.BackColor == Color.LightSkyBlue)
                    {
                        NumerosPesquisas = true;
                        i = 26;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
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
                    Panel panel = Application.OpenForms["FormSecundaria"].Controls["panelNumeros3"] as Panel;
                    Button Button = panel.Controls[sb.ToString()] as Button;
                    if (Button.BackColor == Color.LightSkyBlue)
                    {
                        ElementosListaConsta.Add(i);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public void ArmazenarResultadoLista()
        {
            try
            {
                if (dataGridViewCombinacoes.RowCount > 2)
                {
                    ListaTodosSelecionados.Clear();

                    for (int linha = 0; linha < dataGridViewCombinacoes.Rows.Count - 1; linha++)
                    {
                        ListaTodosSelecionados.Add(int.Parse(dataGridViewCombinacoes.Rows[linha].Cells[1].Value.ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        //LISTA DA ESCOLHIDAS Tela PRINCIPAL SELECIONADOS
        public void ListadataGridViewSelecionadoTodos()
        {
            try
            {
                int par = 0, impar = 0, repetidas = 0, modula = 0, primos = 0, fibonacci = 0, mult = 0, sobra = 0, magicos = 0, total = 0, soma = 0, temp = 0;
                int SomaMinima = 0, SomaMaxima = 0;
                //bool Repeticao = false;
                if ((MinimoLinha != 173) || (MaximoLinha != 220)) { SomaMinima = MinimoLinha; SomaMaxima = MaximoLinha; }
                else { SomaMinima = 173; SomaMaxima = 220; }
                for (int i = 0; i < int.Parse(FormPrincipal.ListaTodosSelecionadosTamanhoQuantidade()); i++)
                {
                    for (int coluna = 0; coluna < 15; coluna++)
                    {
                        //SOMA DA LINHA
                        soma = FormPrincipal.ArrayJogosCombinacaoRetorno(FormPrincipal.ListaTodosSelecionadosRetorno(i), coluna);
                        total = soma + total;

                        //PAR E IMPAR + SOMA DA LINHA
                        if (FormPrincipal.ArrayJogosCombinacaoRetorno(FormPrincipal.ListaTodosSelecionadosRetorno(i), coluna) % 2 == 0)
                        {
                            par++;
                        }
                        else
                        {
                            impar++;
                        }//REPETIDAS
                        for (int rep = 0; rep < int.Parse(FormPrincipal.ArrayRepetidaTamanhoQuantidade()); rep++)
                        {
                            if (FormPrincipal.ArrayRepetidasRetorno(rep) == FormPrincipal.ArrayJogosCombinacaoRetorno(FormPrincipal.ListaTodosSelecionadosRetorno(i), coluna))
                            {
                                repetidas++;
                                rep = int.Parse(FormPrincipal.ArrayRepetidaTamanhoQuantidade());
                            }
                        }//MODULA
                        int[] ArrayMoldura = new int[] { 1, 2, 3, 4, 5, 6, 10, 11, 15, 16, 20, 21, 22, 23, 24, 25 };
                        for (int colunaM = 0; colunaM < ArrayMoldura.Length; colunaM++)
                        {
                            if (FormPrincipal.ArrayJogosCombinacaoRetorno(FormPrincipal.ListaTodosSelecionadosRetorno(i), coluna) == ArrayMoldura[colunaM])
                            {
                                modula++;
                                colunaM = ArrayMoldura.Length;
                            }
                        }//PRIMOS
                        int[] ArrayPrimos = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23 };
                        for (int colunaP = 0; colunaP < ArrayPrimos.Length; colunaP++)
                        {
                            if (FormPrincipal.ArrayJogosCombinacaoRetorno(FormPrincipal.ListaTodosSelecionadosRetorno(i), coluna) == ArrayPrimos[colunaP])
                            {
                                primos++; ;
                                colunaP = ArrayPrimos.Length;
                            }
                        }//FIBONACCI
                        int[] Fibonacci = new int[] { 1, 2, 3, 5, 8, 13, 21 };
                        for (int colunaF = 0; colunaF < Fibonacci.Length; colunaF++)
                        {
                            if (FormPrincipal.ArrayJogosCombinacaoRetorno(FormPrincipal.ListaTodosSelecionadosRetorno(i), coluna) == Fibonacci[colunaF])
                            {
                                fibonacci++; ;
                                colunaF = Fibonacci.Length;
                            }
                        }//MUTL 3
                        int[] ArrayMult = new int[] { 3, 6, 9, 12, 15, 18, 21, 24 };
                        for (int colunaML = 0; colunaML < ArrayMult.Length; colunaML++)
                        {
                            if (FormPrincipal.ArrayJogosCombinacaoRetorno(FormPrincipal.ListaTodosSelecionadosRetorno(i), coluna) == ArrayMult[colunaML])
                            {
                                mult++; ;
                                colunaML = ArrayMult.Length;
                            }
                        }//TENHA SOBRA
                        for (int colunaSobra = 0; colunaSobra < int.Parse(FormPrincipal.ArrayResultadoSobraTamanho()); colunaSobra++)
                        {
                            if (FormPrincipal.ArrayJogosCombinacaoRetorno(FormPrincipal.ListaTodosSelecionadosRetorno(i), coluna) == FormPrincipal.ArrayResultadoSobraRetorno(colunaSobra))
                            {
                                sobra++; ;
                                colunaSobra = int.Parse(FormPrincipal.ArrayResultadoSobraTamanho());
                            }
                        }
                        int[] ArrayMagicos = new int[] { 5, 6, 7, 12, 13, 14, 19, 20, 21 };
                        for (int colunaMS = 0; colunaMS < ArrayMagicos.Length; colunaMS++)
                        {
                            if (FormPrincipal.ArrayJogosCombinacaoRetorno(FormPrincipal.ListaTodosSelecionadosRetorno(i), coluna) == ArrayMagicos[colunaMS])
                            {
                                magicos++;
                                colunaMS = ArrayMagicos.Length;
                            }
                        }
                    }
                    if ((total >= SomaMinima) && (total <= SomaMaxima))//173 e 220
                    {
                        dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[0].Value = dataGridViewCombinacoes.Rows.Count;
                        dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[1].Value = Convert.ToString(FormPrincipal.ListaTodosSelecionadosRetorno(i));
                        for (int coluna = 0; coluna < 15; coluna++)
                        {
                            for (int arrayM = temp; arrayM < int.Parse(FormPrincipal.ArrayRepetidaTamanho()); arrayM++)
                            {
                                if (FormPrincipal.ArrayJogosCombinacaoRetorno(FormPrincipal.ListaTodosSelecionadosRetorno(i), coluna) < FormPrincipal.ArrayRepetidasRetorno(arrayM))
                                {
                                    temp = arrayM;
                                    arrayM = int.Parse(FormPrincipal.ArrayRepetidaTamanho()) - 1;
                                }
                                if (FormPrincipal.ArrayJogosCombinacaoRetorno(FormPrincipal.ListaTodosSelecionadosRetorno(i), coluna) == FormPrincipal.ArrayRepetidasRetorno(arrayM))
                                {
                                    dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[coluna + 2].Style.BackColor = Color.Pink;
                                    temp = arrayM;
                                    arrayM = int.Parse(FormPrincipal.ArrayRepetidaTamanho()) - 1;
                                }
                            }
                            dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[coluna + 2].Value = FormPrincipal.ArrayJogosCombinacaoRetorno(FormPrincipal.ListaTodosSelecionadosRetorno(i), coluna);
                        }
                        dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[17].Value = par + " :e: " + impar;
                        dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[18].Value = repetidas.ToString();
                        dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[19].Value = modula.ToString();
                        dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[20].Value = primos.ToString();
                        dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[21].Value = fibonacci.ToString();
                        dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[22].Value = mult.ToString();
                        dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[23].Value = sobra.ToString();
                        dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[24].Value = magicos.ToString();
                        dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[25].Value = total.ToString();

                        dataGridViewCombinacoes.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                    }
                    par = 0; impar = 0; repetidas = 0; modula = 0; primos = 0; fibonacci = 0; mult = 0; sobra = 0; magicos = 0; total = 0; soma = 0; temp = 0; //Repeticao = false;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        //LISTA DA ESCOLHIDAS TELA PRINCIPAL COMBINAÇÕES
        public void ListadataGridViewCombinacoesEscolhidasTodos()
        {
            try
            {
                int SomaMinima = 0, SomaMaxima = 0;
                int par = 0, impar = 0, repetidas = 0, modula = 0, primos = 0, fibonacci = 0, mult = 0, sobra = 0, magicos = 0, total = 0, soma = 0, temp = 0;
                //bool Repeticao = false;
                if ((MinimoLinha != 173) || (MaximoLinha != 220)) { SomaMinima = MinimoLinha; SomaMaxima = MaximoLinha; }
                else { SomaMinima = 173; SomaMaxima = 220; }

                for (int linha = 0; linha < int.Parse(FormPrincipal.ListaCombinacoesCombinacaoTamanhoQuantidade()); linha++)
                { 
                    for (int coluna = 0; coluna < 15; coluna++)
                    {
                        //SOMA DA LINHA
                        soma = FormPrincipal.ArrayJogosCombinacaoRetorno(FormPrincipal.ListaCombinacoesCombinacaoRetorno(linha), coluna);
                        total = soma + total;

                        if (FormPrincipal.ArrayJogosCombinacaoRetorno(FormPrincipal.ListaCombinacoesCombinacaoRetorno(linha), coluna) % 2 == 0)
                        {
                            par++;
                        }
                        else
                        {
                            impar++;
                        }//REPETIDAS
                        for (int rep = 0; rep < int.Parse(FormPrincipal.ArrayRepetidaTamanhoQuantidade()); rep++)
                        {
                            if (FormPrincipal.ArrayRepetidasRetorno(rep) == (FormPrincipal.ArrayJogosCombinacaoRetorno(FormPrincipal.ListaCombinacoesCombinacaoRetorno(linha), coluna)))
                            {
                                repetidas++;
                                rep = int.Parse(FormPrincipal.ArrayRepetidaTamanhoQuantidade());
                            }
                        }//MODULA
                        int[] ArrayMoldura = new int[] { 1, 2, 3, 4, 5, 6, 10, 11, 15, 16, 20, 21, 22, 23, 24, 25 };
                        for (int colunaM = 0; colunaM < ArrayMoldura.Length; colunaM++)
                        {
                            if (FormPrincipal.ArrayJogosCombinacaoRetorno(FormPrincipal.ListaCombinacoesCombinacaoRetorno(linha), coluna) == ArrayMoldura[colunaM])
                            {
                                modula++;
                                colunaM = ArrayMoldura.Length;
                            }
                        }//PRIMOS
                        int[] ArrayPrimos = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23 };
                        for (int colunaP = 0; colunaP < ArrayPrimos.Length; colunaP++)
                        {
                            if (FormPrincipal.ArrayJogosCombinacaoRetorno(FormPrincipal.ListaCombinacoesCombinacaoRetorno(linha), coluna) == ArrayPrimos[colunaP])
                            {
                                primos++; ;
                                colunaP = ArrayPrimos.Length;
                            }
                        }//FIBONACCI
                        int[] Fibonacci = new int[] { 1, 2, 3, 5, 8, 13, 21 };
                        for (int colunaF = 0; colunaF < Fibonacci.Length; colunaF++)
                        {
                            if (FormPrincipal.ArrayJogosCombinacaoRetorno(FormPrincipal.ListaCombinacoesCombinacaoRetorno(linha), coluna) == Fibonacci[colunaF])
                            {
                                fibonacci++; ;
                                colunaF = Fibonacci.Length;
                            }
                        }//MUTL 3
                        int[] ArrayMult = new int[] { 3, 6, 9, 12, 15, 18, 21, 24 };
                        for (int colunaML = 0; colunaML < ArrayMult.Length; colunaML++)
                        {
                            if (FormPrincipal.ArrayJogosCombinacaoRetorno(FormPrincipal.ListaCombinacoesCombinacaoRetorno(linha), coluna) == ArrayMult[colunaML])
                            {
                                mult++; ;
                                colunaML = ArrayMult.Length;
                            }
                        }//TENHA SOBRA
                        for (int colunaSobra = 0; colunaSobra < int.Parse(FormPrincipal.ArrayResultadoSobraTamanho()); colunaSobra++)
                        {
                            if (FormPrincipal.ArrayJogosCombinacaoRetorno(FormPrincipal.ListaCombinacoesCombinacaoRetorno(linha), coluna) == FormPrincipal.ArrayResultadoSobraRetorno(colunaSobra))
                            {
                                sobra++; ;
                                colunaSobra = int.Parse(FormPrincipal.ArrayResultadoSobraTamanho());
                            }
                        }//MÁGICOS
                        int[] ArrayMagicos = new int[] { 5, 6, 7, 12, 13, 14, 19, 20, 21 };
                        for (int colunaMs = 0; colunaMs < ArrayMagicos.Length; colunaMs++)
                        {
                            if (FormPrincipal.ArrayJogosCombinacaoRetorno(FormPrincipal.ListaCombinacoesCombinacaoRetorno(linha), coluna) == ArrayMagicos[colunaMs])
                            {
                                magicos++; ;
                                colunaMs = ArrayMagicos.Length;
                            }
                        }
                    }
                    if ((total >= SomaMinima) && (total <= SomaMaxima))//173 e 220
                    {
                        dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[0].Value = dataGridViewCombinacoes.Rows.Count;
                        dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[1].Value = Convert.ToString(FormPrincipal.ListaCombinacoesCombinacaoRetorno(linha));

                        for (int coluna = 0; coluna < 15; coluna++)
                        {
                            for (int arrayM = temp; arrayM < int.Parse(FormPrincipal.ArrayRepetidaTamanho()); arrayM++)
                            {
                                if (FormPrincipal.ArrayJogosCombinacaoRetorno(FormPrincipal.ListaCombinacoesCombinacaoRetorno(linha), coluna) < FormPrincipal.ArrayRepetidasRetorno(arrayM))
                                {
                                    temp = arrayM;
                                    arrayM = int.Parse(FormPrincipal.ArrayRepetidaTamanho()) - 1;
                                }
                                if (FormPrincipal.ArrayJogosCombinacaoRetorno(FormPrincipal.ListaCombinacoesCombinacaoRetorno(linha), coluna) == FormPrincipal.ArrayRepetidasRetorno(arrayM))
                                {
                                    dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[coluna + 2].Style.BackColor = Color.Pink;
                                    temp = arrayM;
                                    arrayM = int.Parse(FormPrincipal.ArrayRepetidaTamanho()) - 1;
                                }
                            }
                            dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[coluna + 2].Value = FormPrincipal.ArrayJogosCombinacaoRetorno(FormPrincipal.ListaCombinacoesCombinacaoRetorno(linha), coluna);
                        }
                        dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[17].Value = par + " :e: " + impar;
                        dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[18].Value = repetidas.ToString();
                        dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[19].Value = modula.ToString();
                        dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[20].Value = primos.ToString();
                        dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[21].Value = fibonacci.ToString();
                        dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[22].Value = mult.ToString();
                        dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[23].Value = sobra.ToString();
                        dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[24].Value = magicos.ToString();
                        dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[25].Value = total.ToString();

                        dataGridViewCombinacoes.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                    }
                    par = 0; impar = 0; repetidas = 0; modula = 0; primos = 0; fibonacci = 0; mult = 0; sobra = 0; magicos = 0; total = 0; soma = 0; temp = 0; //Repeticao = false;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        //LISTA DO SELECIONADO PRIMEIRA TELA PESQUISA
        public void ListadataGridViewSelecionadoPesquisa()
        {
            try
            {
                int consta = 0, par = 0, impar = 0, repetidas = 0, modula = 0, primos = 0, fibonacci = 0, mult = 0, sobra = 0, magicos = 0, total = 0, PosicaoC = 0, soma = 0, temp = 0;
                //bool Repeticao = false;

                for (int posicao = 0; posicao < ListaTodosSelecionados.Count ; posicao++)
                {
                    for (int lista = 0; lista < ElementosListaConsta.Count; lista++)
                    {
                        for (int coluna = PosicaoC; coluna < 15; coluna++)
                        {
                            if (FormPrincipal.ArrayJogosCombinacaoRetorno(ListaTodosSelecionados[posicao], coluna) > ElementosListaConsta[lista])
                            {
                                PosicaoC = coluna + 1;
                                coluna = 15;
                            }
                            else if (FormPrincipal.ArrayJogosCombinacaoRetorno(ListaTodosSelecionados[posicao], coluna) == ElementosListaConsta[lista] )
                            {
                                consta++;
                                PosicaoC = coluna + 1;
                                coluna = 15;
                            }
                        }
                    }
                    if (consta == ElementosListaConsta.Count)
                    {
                        for (int coluna = 0; coluna < 15; coluna++)
                        {
                            //SOMA DA LINHA
                            soma = FormPrincipal.ArrayJogosCombinacaoRetorno(ListaTodosSelecionados[posicao], coluna);
                            total = soma + total;

                            if (FormPrincipal.ArrayJogosCombinacaoRetorno(ListaTodosSelecionados[posicao], coluna) % 2 == 0)
                            {
                                par++;
                            }
                            else
                            {
                                impar++;
                            }//REPETIDAS
                            for (int rep = 0; rep < int.Parse(FormPrincipal.ArrayRepetidaTamanhoQuantidade()); rep++)
                            {
                                if (FormPrincipal.ArrayRepetidasRetorno(rep) == FormPrincipal.ArrayJogosCombinacaoRetorno(ListaTodosSelecionados[posicao], coluna))
                                {
                                    repetidas++;
                                    rep = int.Parse(FormPrincipal.ArrayRepetidaTamanhoQuantidade());
                                }
                            }//MODULA
                            int[] ArrayMoldura = new int[] { 1, 2, 3, 4, 5, 6, 10, 11, 15, 16, 20, 21, 22, 23, 24, 25 };
                            for (int colunaM = 0; colunaM < ArrayMoldura.Length; colunaM++)
                            {
                                if (FormPrincipal.ArrayJogosCombinacaoRetorno(ListaTodosSelecionados[posicao], coluna) == ArrayMoldura[colunaM])
                                {
                                    modula++;
                                    colunaM = ArrayMoldura.Length;
                                }
                            }//PRIMOS
                            int[] ArrayPrimos = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23 };
                            for (int colunaP = 0; colunaP < ArrayPrimos.Length; colunaP++)
                            {
                                if (FormPrincipal.ArrayJogosCombinacaoRetorno(ListaTodosSelecionados[posicao], coluna) == ArrayPrimos[colunaP])
                                {
                                    primos++; ;
                                    colunaP = ArrayPrimos.Length;
                                }
                            }//FIBONACCI
                            int[] Fibonacci = new int[] { 1, 2, 3, 5, 8, 13, 21 };
                            for (int colunaF = 0; colunaF < Fibonacci.Length; colunaF++)
                            {
                                if (FormPrincipal.ArrayJogosCombinacaoRetorno(ListaTodosSelecionados[posicao], coluna) == Fibonacci[colunaF])
                                {
                                    fibonacci++; ;
                                    colunaF = Fibonacci.Length;
                                }
                            }//MUTL 3
                            int[] ArrayMult = new int[] { 3, 6, 9, 12, 15, 18, 21, 24 };
                            for (int colunaML = 0; colunaML < ArrayMult.Length; colunaML++)
                            {
                                if (FormPrincipal.ArrayJogosCombinacaoRetorno(ListaTodosSelecionados[posicao], coluna) == ArrayMult[colunaML])
                                {
                                    mult++; ;
                                    colunaML = ArrayMult.Length;
                                }
                            }//TENHA SOBRA
                            for (int colunaSobra = 0; colunaSobra < int.Parse(FormPrincipal.ArrayResultadoSobraTamanho()); colunaSobra++)
                            {
                                if (FormPrincipal.ArrayJogosCombinacaoRetorno(ListaTodosSelecionados[posicao], coluna) == FormPrincipal.ArrayResultadoSobraRetorno(colunaSobra))
                                {
                                    sobra++; ;
                                    colunaSobra = int.Parse(FormPrincipal.ArrayResultadoSobraTamanho());
                                }
                            }//MÁGICOS
                            int[] ArrayMagicos = new int[] { 5, 6, 7, 12, 13, 14, 19, 20, 21 };
                            for (int colunaMs = 0; colunaMs < ArrayMagicos.Length; colunaMs++)
                            {
                                if (FormPrincipal.ArrayJogosCombinacaoRetorno(ListaTodosSelecionados[posicao], coluna) == ArrayMagicos[colunaMs])
                                {
                                    magicos++; ;
                                    colunaMs = ArrayMagicos.Length;
                                }
                            }
                        }
                        dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[0].Value = posicao + 1;
                        dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[1].Value = Convert.ToString(ListaTodosSelecionados[posicao]);
                        for (int coluna = 0; coluna < 15; coluna++)
                        {
                            for (int arrayM = temp; arrayM < int.Parse(FormPrincipal.ArrayRepetidaTamanho()); arrayM++)
                            {
                                if (FormPrincipal.ArrayJogosCombinacaoRetorno(ListaTodosSelecionados[posicao], coluna) < FormPrincipal.ArrayRepetidasRetorno(arrayM))
                                {
                                    temp = arrayM;
                                    arrayM = int.Parse(FormPrincipal.ArrayRepetidaTamanho()) - 1;
                                }
                                if (FormPrincipal.ArrayJogosCombinacaoRetorno(ListaTodosSelecionados[posicao], coluna) == FormPrincipal.ArrayRepetidasRetorno(arrayM))
                                {
                                    dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[coluna + 2].Style.BackColor = Color.Pink;
                                    temp = arrayM;
                                    arrayM = int.Parse(FormPrincipal.ArrayRepetidaTamanho()) - 1;
                                }
                            }
                            dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[coluna + 2].Value = FormPrincipal.ArrayJogosCombinacaoRetorno(ListaTodosSelecionados[posicao], coluna);
                        }
                        dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[17].Value = par + " :e: " + impar;
                        dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[18].Value = repetidas.ToString();
                        dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[19].Value = modula.ToString();
                        dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[20].Value = primos.ToString();
                        dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[21].Value = fibonacci.ToString();
                        dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[22].Value = mult.ToString();
                        dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[23].Value = sobra.ToString();
                        dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[24].Value = magicos.ToString();
                        dataGridViewCombinacoes.Rows[dataGridViewCombinacoes.Rows.Count - 1].Cells[25].Value = total.ToString();

                        dataGridViewCombinacoes.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");

                        par = 0; impar = 0; repetidas = 0; modula = 0; primos = 0; fibonacci = 0; mult = 0; sobra = 0; magicos = 0; total = 0; PosicaoC = 0; soma = 0; temp = 0; //Repeticao = false;
                        consta = 0; PosicaoC = 0;
                    }
                    consta = 0; PosicaoC = 0;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public void LimpadataGridViewCombinacoes()
        {
            dataGridViewCombinacoes.Rows.Clear();
            dataGridViewCombinacoes.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
        }

        private void FormSecundaria_Load(object sender, EventArgs e)
        {

        }
        private void buttonPesquisa_Click(object sender, EventArgs e)
        {
            NumerosSelecionados();

            if (this.NumerosPesquisas == true)
            {
                ElementosListaConsta.Clear();
                LimpadataGridViewCombinacoes();
                EntradaValoresCriarJogo();

                if (modo == 1)
                {
                    demostracaoLimpo();
                }
                if (modo == 2)
                {
                    demostracaoLimpo2();
                }
                ListadataGridViewSelecionadoPesquisa();
                label42.Text = "QUANT: " + Convert.ToString(dataGridViewCombinacoes.Rows.Count - 1);
                NumerosPesquisas = false;
            }
            else
            {
                ElementosListaConsta.Clear();
                LimpadataGridViewCombinacoes();

                if (modo == 1)
                {
                    demostracaoLimpo();
                }
                if (modo == 2)
                {
                    demostracaoLimpo2();
                }
                ListadataGridViewSelecionadoPesquisa();
                label42.Text = "QUANT: " + Convert.ToString(dataGridViewCombinacoes.Rows.Count - 1);
                NumerosPesquisas = false;
            }

        }

        private void buttonFecha_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public Boolean JogoRepetido()
        {
            try
            {
                Boolean Repetido = false;
                int Linha_Selecionada = int.Parse(dataGridViewCombinacoes.CurrentRow.Index.ToString());
                int contador = 0;

                for (int testeLinhaInicio = 0; testeLinhaInicio < (dataGridViewJogos.Rows.Count - 1); testeLinhaInicio++)
                {
                    for (int coluna = 2; coluna < 17; coluna++)
                    {
                        if (dataGridViewCombinacoes.Rows[Linha_Selecionada].Cells[coluna].Value.ToString() == dataGridViewJogos.Rows[testeLinhaInicio].Cells[coluna].Value.ToString())
                        {
                            contador++;
                        }
                        else
                        {
                            coluna = 17;
                        }
                    }
                    if (contador == 15)
                    {
                        string numero = "";
                        for (int coluna = 2; coluna < 17; coluna++)
                        {
                            if (coluna < 16)
                            {
                                numero = numero + dataGridViewCombinacoes.Rows[Linha_Selecionada].Cells[coluna].Value.ToString() + ", ";
                            }
                            if (coluna == 16)
                            {
                                numero = numero + dataGridViewCombinacoes.Rows[Linha_Selecionada].Cells[coluna].Value.ToString() + ".";
                            }
                            testeLinhaInicio = dataGridViewJogos.Rows.Count;
                            Repetido = true;
                        }
                        this.Jogos_Repetido = " É um jogo que já saiu no Array de número: " + Linha_Selecionada + " os números são: " + numero;
                        MessageBox.Show("JOGO JÁ ADICIONADO NA LISTA!");
                    }
                    contador = 0;
                }
                return Repetido;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return true;
            }
        }
        bool VerificarObjeto(string obj)
        {
            try
            {
                string objeto = obj;
                if (objeto == "")
                {
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return true;
            }
        }
        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            SalvarEscolhas();
        }
        public void SalvarEscolhas()
        {
            try
            {
                if (dataGridViewJogos.RowCount > 1)
                {
                    FormPrincipal.ListaCombinacoesCombinacaolimpaSalvos();
                    for (int lista = 0; lista < dataGridViewJogos.RowCount - 1; lista++)
                    {
                        FormPrincipal.ListaCombinacoesCombinacaoAddSalvos(int.Parse(dataGridViewJogos.Rows[lista].Cells[1].Value.ToString()));
                        Console.WriteLine(FormPrincipal.ListaCombinacoesCombinacaoRetornoSalvos(lista));
                    }

                }
                else
                {
                    FormPrincipal.ListaCombinacoesCombinacaolimpaSalvos();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally { Console.WriteLine(" Salvo o jogo! "); }
        }
        public void jogosSalvos()
        {
            try
            {
                int tamanho = int.Parse(FormPrincipal.VerificarTamanho());
                if (tamanho == 0)
                {
                    Console.WriteLine("Sem Jogos salvos!");
                }
                else
                {
                    for (int linhaArray = 0; linhaArray < tamanho; linhaArray++)
                    {
                        dataGridViewJogos.Rows[linhaArray].Cells[0].Value = linhaArray + 1;
                        for (int coluna = 0; coluna < 15; coluna++)
                        {
                            dataGridViewJogos.Rows[linhaArray].Cells[coluna + 1].Value = FormPrincipal.Armazanados(linhaArray, coluna);
                        }
                        dataGridViewJogos.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");

                    }
                    label1.Text = Convert.ToString(dataGridViewJogos.RowCount - 1);
                }
            }
            catch (Exception ex) { ex.ToString(); }
        }
        //LISTA DO SELECIONADO SALVOS
        public void ListadataGridViewEscolhasJogos()
        {
            try
            {
                int par = 0, impar = 0, repetidas = 0, modula = 0, primos = 0, fibonacci = 0, mult = 0, sobra = 0, magicos = 0, total = 0, soma = 0;
                int cont = 0, temp = 0;

                if (int.Parse(FormPrincipal.ListaCombinacoesCombinacaoTamanhoQuantidadeSalvos()) > 0)
                {
                    for (int posicao = 0; posicao < int.Parse(FormPrincipal.ListaCombinacoesCombinacaoTamanhoQuantidadeSalvos()); posicao++)
                    {
                        for (int coluna = 0; coluna < 15; coluna++)
                        {
                            //SOMA DA LINHA
                            soma = FormPrincipal.ArrayJogosCombinacaoRetorno(FormPrincipal.ListaCombinacoesCombinacaoRetornoSalvos(posicao), coluna);
                            total = soma + total;
                            //PAR E IMPAR
                            if (FormPrincipal.ArrayJogosCombinacaoRetorno(FormPrincipal.ListaCombinacoesCombinacaoRetornoSalvos(posicao), coluna) % 2 == 0)
                            {
                                par++;
                            }
                            else
                            {
                                impar++;
                            }//REPETIDAS
                            for (int rep = 0; rep < int.Parse(FormPrincipal.ArrayRepetidaTamanhoQuantidade()); rep++)
                            {
                                if (FormPrincipal.ArrayRepetidasRetorno(rep) == FormPrincipal.ArrayJogosCombinacaoRetorno(FormPrincipal.ListaCombinacoesCombinacaoRetornoSalvos(posicao), coluna))
                                {
                                    repetidas++;
                                    rep = int.Parse(FormPrincipal.ArrayRepetidaTamanhoQuantidade());
                                }
                            }//MODULA
                            int[] ArrayMoldura = new int[] { 1, 2, 3, 4, 5, 6, 10, 11, 15, 16, 20, 21, 22, 23, 24, 25 };
                            for (int colunaM = 0; colunaM < ArrayMoldura.Length; colunaM++)
                            {
                                if (FormPrincipal.ArrayJogosCombinacaoRetorno(FormPrincipal.ListaCombinacoesCombinacaoRetornoSalvos(posicao), coluna) == ArrayMoldura[colunaM])
                                {
                                    modula++;
                                    colunaM = ArrayMoldura.Length;
                                }
                            }//PRIMOS
                            int[] ArrayPrimos = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23 };
                            for (int colunaP = 0; colunaP < ArrayPrimos.Length; colunaP++)
                            {
                                if (FormPrincipal.ArrayJogosCombinacaoRetorno(FormPrincipal.ListaCombinacoesCombinacaoRetornoSalvos(posicao), coluna) == ArrayPrimos[colunaP])
                                {
                                    primos++; ;
                                    colunaP = ArrayPrimos.Length;
                                }
                            }//FIBONACCI
                            int[] Fibonacci = new int[] { 1, 2, 3, 5, 8, 13, 21 };
                            for (int colunaF = 0; colunaF < Fibonacci.Length; colunaF++)
                            {
                                if (FormPrincipal.ArrayJogosCombinacaoRetorno(FormPrincipal.ListaCombinacoesCombinacaoRetornoSalvos(posicao), coluna) == Fibonacci[colunaF])
                                {
                                    fibonacci++; ;
                                    colunaF = Fibonacci.Length;
                                }
                            }//MUTL 3
                            int[] ArrayMult = new int[] { 3, 6, 9, 12, 15, 18, 21, 24 };
                            for (int colunaML = 0; colunaML < ArrayMult.Length; colunaML++)
                            {
                                if (FormPrincipal.ArrayJogosCombinacaoRetorno(FormPrincipal.ListaCombinacoesCombinacaoRetornoSalvos(posicao), coluna) == ArrayMult[colunaML])
                                {
                                    mult++; ;
                                    colunaML = ArrayMult.Length;
                                }
                            }//TENHA SOBRA
                            for (int colunaSobra = 0; colunaSobra < int.Parse(FormPrincipal.ArrayResultadoSobraTamanho()); colunaSobra++)
                            {
                                if (FormPrincipal.ArrayJogosCombinacaoRetorno(FormPrincipal.ListaCombinacoesCombinacaoRetornoSalvos(posicao), coluna) == FormPrincipal.ArrayResultadoSobraRetorno(colunaSobra))
                                {
                                    sobra++; ;
                                    colunaSobra = int.Parse(FormPrincipal.ArrayResultadoSobraTamanho());
                                }
                            }//MÁGICOS
                            int[] ArrayMagicos = new int[] { 5, 6, 7, 12, 13, 14, 19, 20, 21 };
                            for (int colunaMS = 0; colunaMS < ArrayMagicos.Length; colunaMS++)
                            {
                                if (FormPrincipal.ArrayJogosCombinacaoRetorno(FormPrincipal.ListaCombinacoesCombinacaoRetornoSalvos(posicao), coluna) == ArrayMagicos[colunaMS])
                                {
                                    magicos++;
                                    colunaMS = ArrayMagicos.Length;
                                }
                            }
                        }
                        dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[0].Value = dataGridViewJogos.Rows.Count;
                        dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[1].Value = Convert.ToString(FormPrincipal.ListaCombinacoesCombinacaoRetornoSalvos(posicao));
                        for (int colunaN = 2; colunaN < dataGridViewJogos.Columns.Count; colunaN++)
                        {
                            if (colunaN <= 16)
                            {
                                for (int arrayM = temp; arrayM < int.Parse(FormPrincipal.ArrayRepetidaTamanho()); arrayM++)
                                {
                                    if (FormPrincipal.ArrayRepetidasRetorno(arrayM) > FormPrincipal.ArrayJogosCombinacaoRetorno(FormPrincipal.ListaCombinacoesCombinacaoRetornoSalvos(posicao), colunaN - 2))
                                    {
                                        temp = arrayM;
                                        arrayM = int.Parse(FormPrincipal.ArrayRepetidaTamanho()) - 1;
                                    }
                                    if (FormPrincipal.ArrayRepetidasRetorno(arrayM) == FormPrincipal.ArrayJogosCombinacaoRetorno(FormPrincipal.ListaCombinacoesCombinacaoRetornoSalvos(posicao), colunaN - 2))
                                    {
                                        temp = arrayM;
                                        dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[colunaN].Style.BackColor = Color.Pink;
                                        arrayM = int.Parse(FormPrincipal.ArrayRepetidaTamanho()) - 1;
                                        cont++;
                                    }
                                }
                                dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[colunaN].Value = Convert.ToString(FormPrincipal.ArrayJogosCombinacaoRetorno(FormPrincipal.ListaCombinacoesCombinacaoRetornoSalvos(posicao), colunaN - 2));
                            }                           
                        }                      
                        dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[17].Value = par + " :e: " + impar;
                        dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[18].Value = Convert.ToString(repetidas);
                        dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[19].Value = Convert.ToString(modula);
                        dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[20].Value = Convert.ToString(primos);
                        dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[21].Value = Convert.ToString(fibonacci);
                        dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[22].Value = Convert.ToString(mult);
                        dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[23].Value = Convert.ToString(sobra);
                        dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[24].Value = Convert.ToString(magicos);
                        dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[25].Value = Convert.ToString(total);
                        par = 0; impar = 0; repetidas = 0; modula = 0; primos = 0; fibonacci = 0; mult = 0; sobra = 0; magicos = 0; total = 0; soma = 0; temp = 0;
                        dataGridViewJogos.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void dataGridViewCombinacoes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            demostracaoJogos();
        }
        public void demostracaoJogos()
        {
            try
            {
                int Linha_Selecionada = int.Parse(dataGridViewCombinacoes.CurrentRow.Index.ToString());
                if (VerificarObjeto(dataGridViewCombinacoes.Rows[Linha_Selecionada].Cells[2].Value.ToString()) == false)
                {
                    demostracaoLimpo();
                    int inicio = 0, inicio2 = 0;
                    for (int linha = inicio; linha < 5; linha++)
                    {
                        for (int coluna = inicio2; coluna < 5; coluna++)
                        {
                            for (int colunaE = 1; colunaE <= 15; colunaE++)
                            {
                                int numero = int.Parse(dataGridViewCombinacoes.Rows[Linha_Selecionada].Cells[colunaE + 1].Value.ToString());
                                int numero2 = int.Parse(dataGridViewLinhaColuna.Rows[linha].Cells[coluna].Value.ToString());

                                if (numero == numero2)
                                {
                                    dataGridViewLinhaColuna.Rows[linha].Cells[coluna].Style.BackColor = Color.LightSteelBlue;
                                    colunaE = 16;
                                }
                                if (numero > numero2)
                                {
                                    colunaE = 16;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { ex.ToString(); }
        }
        private void dataGridViewCombinacoes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int Linha_Selecionada = int.Parse(dataGridViewCombinacoes.CurrentRow.Index.ToString());
                if (VerificarObjeto(dataGridViewCombinacoes.Rows[Linha_Selecionada].Cells[2].Value.ToString()) == false)
                {
                    if (JogoJaSaiu() == true)
                    {

                    }
                    else
                    {
                        if (UltimoJogo() == true)
                        {

                        }
                        else
                        {
                            AdicionarJogo();
                        }
                    }
                }
            }
            catch (Exception ex) { ex.ToString(); }
        }
        public void AdicionarJogo()
        {
            try
            {
                int Linha_Selecionada = int.Parse(dataGridViewCombinacoes.CurrentRow.Index.ToString());
                int contador = 0;
                Boolean valor = false;
                if (dataGridViewJogos.RowCount > 1)
                {
                    for (int linha = 0; linha < dataGridViewJogos.RowCount - 1; linha++)
                    {
                        for (int coluna = 2; coluna < 17; coluna++)
                        {
                            if (dataGridViewJogos.Rows[linha].Cells[coluna].Value.ToString() == dataGridViewCombinacoes.Rows[Linha_Selecionada].Cells[coluna].Value.ToString())
                            {
                                contador++;
                            }
                        }
                        if (contador == 15)
                        {
                            linha = dataGridViewJogos.RowCount;
                            valor = true;
                            MessageBox.Show("Já tem na escolha de jogos! ");
                        }
                        contador = 0;
                    }
                    if (valor == false)
                    {
                        dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[0].Value = dataGridViewJogos.Rows.Count;
                        dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[1].Value = dataGridViewCombinacoes.Rows[Linha_Selecionada].Cells[1].Value.ToString();
                        for (int coluna = 1; coluna < 25; coluna++)
                        {
                            dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[coluna + 1].Value = dataGridViewCombinacoes.Rows[Linha_Selecionada].Cells[coluna + 1].Value.ToString();
                            if ((coluna > 0) && (coluna < 16))
                            {
                                string cor = dataGridViewCombinacoes.Rows[Linha_Selecionada].Cells[coluna + 1].Style.BackColor.ToString();
                                if (cor == "Color [Pink]")
                                {
                                    dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[coluna + 1].Style.BackColor = Color.Pink;
                                }
                            }
                        }
                        dataGridViewJogos.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                        label1.Text = Convert.ToString(dataGridViewJogos.RowCount - 1);
                        valor = false;
                    }
                }
                else
                {
                    dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[0].Value = dataGridViewJogos.Rows.Count;
                    dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[1].Value = dataGridViewCombinacoes.Rows[Linha_Selecionada].Cells[1].Value.ToString();
                    for (int coluna = 1; coluna < 25; coluna++)
                    {
                        dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[coluna + 1].Value = dataGridViewCombinacoes.Rows[Linha_Selecionada].Cells[coluna + 1].Value.ToString();
                        if ((coluna > 0) && (coluna < 16))
                        {
                            string cor = dataGridViewCombinacoes.Rows[Linha_Selecionada].Cells[coluna + 1].Style.BackColor.ToString();
                            if (cor == "Color [Pink]")
                            {
                                dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[coluna + 1].Style.BackColor = Color.Pink;
                            }
                        }
                    }
                    dataGridViewJogos.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");

                    label1.Text = Convert.ToString(dataGridViewJogos.RowCount - 1);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        private void dataGridViewJogos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            demostracaoJogos2();
        }
        public void demostracaoJogos2()
        {
            try
            {
                int Linha_Selecionada = int.Parse(dataGridViewJogos.CurrentRow.Index.ToString());
                if (VerificarObjeto(dataGridViewJogos.Rows[Linha_Selecionada].Cells[2].Value.ToString()) == false)
                {
                    demostracaoLimpo2();
                    int inicio = 0, inicio2 = 0;
                    for (int linha = inicio; linha < 5; linha++)
                    {
                        for (int coluna = inicio2; coluna < 5; coluna++)
                        {
                            for (int colunaE = 1; colunaE <= 15; colunaE++)
                            {
                                int numero = int.Parse(dataGridViewJogos.Rows[Linha_Selecionada].Cells[colunaE + 1].Value.ToString());
                                int numero2 = int.Parse(dataGridViewLinhaColuna2.Rows[linha].Cells[coluna].Value.ToString());

                                if (numero == numero2)
                                {
                                    dataGridViewLinhaColuna2.Rows[linha].Cells[coluna].Style.BackColor = Color.LightSteelBlue;
                                    colunaE = 16;
                                }
                                if (numero > numero2)
                                {
                                    colunaE = 16;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { ex.ToString(); }
        }
        private void dataGridViewJogos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            RemoverJogo();
        }
        public void RemoverJogo()
        {
            try
            {
                Boolean remover = false;
                int Linha_Selecionada = dataGridViewJogos.CurrentRow.Index;

                if ((VerificarObjeto(dataGridViewJogos.Rows[Linha_Selecionada].Cells[0].Value.ToString()) == false))
                {
                    dataGridViewJogos.Rows.RemoveAt(Linha_Selecionada);
                    remover = true;
                }
                if (remover == true)
                {
                    int linha = 1;
                    for (int i = 0; i < dataGridViewJogos.Rows.Count - 1; i++)
                    {
                        dataGridViewJogos.Rows[i].Cells[0].Value = linha + i;
                    }
                    label1.Text = Convert.ToString(dataGridViewJogos.RowCount - 1);
                }
            }

            catch (Exception ex) { ex.ToString(); }
        }
        public Boolean JogoJaSaiu()
        {
            try
            {
                Boolean ConstaLista = false;
                int Linha_Selecionada = dataGridViewCombinacoes.CurrentRow.Index;
                int contador = 0;
                int JogosSaiu = 0;

                for (int Jogos = 0; Jogos < (int.Parse(arraysJogos.ArrayTamanho()) - 1); Jogos++)
                {
                    for (int coluna = 0; coluna < 15; coluna++)
                    {
                        if (arraysJogos.ArrayL(Jogos, coluna) == int.Parse(dataGridViewCombinacoes.Rows[Linha_Selecionada].Cells[coluna + 2].Value.ToString()))
                        {
                            contador++;
                        }
                        else { coluna = 15; }

                    }
                    if (contador == 15)
                    {

                        ConstaLista = true;
                        JogosSaiu = Jogos;
                        Jogos = int.Parse(arraysJogos.ArrayTamanho());
                        MessageBox.Show("JOGO SORTEADO NO CONCURSO: " + (JogosSaiu + 1) + ".");
                    }
                    contador = 0;
                }
                return ConstaLista;

            }

            catch (Exception ex) { ex.ToString(); return true; }
        }
        public Boolean UltimoJogo()
        {
            try
            {
                Boolean ConstaLista = false;
                int Linha_Selecionada = dataGridViewCombinacoes.CurrentRow.Index;
                int contador = 0;

                for (int coluna = 0; coluna < 15; coluna++)
                {
                    if (arraysJogos.ArrayL(int.Parse(arraysJogos.ArrayTamanho()) - 1, coluna) == int.Parse(dataGridViewCombinacoes.Rows[Linha_Selecionada].Cells[coluna + 2].Value.ToString()))
                    {
                        contador++;
                    }
                    else { coluna = 15; }

                }
                if (contador == 15)
                {
                    ConstaLista = true;
                    MessageBox.Show("ÚLTIMO CONCURSO SORTEADO: " + (int.Parse(arraysJogos.ArrayTamanho()) + 1) + ".");
                }
                contador = 0;

                return ConstaLista;

            }

            catch (Exception ex) { ex.ToString(); return true; }
        }
        private void buttonVisualizar_Click(object sender, EventArgs e)
        {
            try
            {
                printPreviewDialogVisualizar.Document = printDocumentImprmir;
                printPreviewDialogVisualizar.ShowDialog();
            }
            catch (Exception err)
            {
                MessageBox.Show("Error " + err.ToString());
            }
        }
        private void dataGridViewCombinacoes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Put each of the columns into programmatic sort mode.
            foreach (DataGridViewColumn column in dataGridViewCombinacoes.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }
        public void demostracaoLimpo()
        {
            try
            {
                for (int linha = 0; linha < 5; linha++)
                {
                    for (int colunaD = 0; colunaD < 5; colunaD++)
                    {
                        dataGridViewLinhaColuna.Rows[linha].Cells[colunaD].Style.BackColor = Color.White;
                    }
                }

            }
            catch (Exception ex) { ex.ToString(); }
        }
        public void demostracaoLimpo2()
        {
            try
            {
                for (int linha = 0; linha < 5; linha++)
                {
                    for (int colunaD = 0; colunaD < 5; colunaD++)
                    {
                        dataGridViewLinhaColuna2.Rows[linha].Cells[colunaD].Style.BackColor = Color.White;
                    }
                }

            }
            catch (Exception ex) { ex.ToString(); }
        }
        private void buttonSalvarXlsx_Click(object sender, EventArgs e)
        {
            Gerar();
        }
        public void Gerar()
        {
            try
            {
                //ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                //using (ExcelPackage LicenseContext = new ExcelPackage())
                //{

                //    LicenseContext.Workbook.Worksheets.Add("LOTERICA");
                //    LicenseContext.Workbook.Worksheets.Add("Worksheet2");
                //    LicenseContext.Workbook.Worksheets.Add("Worksheet3");

                //    var headerRow = new List<string[]>()
                //    {
                //         new string[] { "ID" }
                //    };

                //    // Determine the header range (e.g. A1:D1)
                //    string headerRange = "A1:" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "1";

                //    // Target a worksheet
                //    var worksheet = LicenseContext.Workbook.Worksheets["LOTERICA"];

                //    // Popular header row data
                //    worksheet.Cells[headerRange].LoadFromArrays(headerRow);

                //    FileInfo excelFile = new FileInfo(@"F:\LOTOFACIL.xlsx");
                //    LicenseContext.SaveAs(excelFile);
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void circularButton1_Click(object sender, EventArgs e)
        {
            if (circularButton1.BackColor == Color.Gainsboro)
            {
                circularButton1.BackColor = Color.LightSkyBlue;

            }
            else
            {
                circularButton1.BackColor = Color.Gainsboro;
            }
        }
        private void circularButton2_Click(object sender, EventArgs e)
        {
            if (circularButton2.BackColor == Color.Gainsboro)
            {
                circularButton2.BackColor = Color.LightSkyBlue;

            }
            else
            {
                circularButton2.BackColor = Color.Gainsboro;
            }
        }
        private void circularButton3_Click(object sender, EventArgs e)
        {
            if (circularButton3.BackColor == Color.Gainsboro)
            {
                circularButton3.BackColor = Color.LightSkyBlue;

            }
            else
            {
                circularButton3.BackColor = Color.Gainsboro;
            }
        }
        private void circularButton4_Click(object sender, EventArgs e)
        {
            if (circularButton4.BackColor == Color.Gainsboro)
            {
                circularButton4.BackColor = Color.LightSkyBlue;

            }
            else
            {
                circularButton4.BackColor = Color.Gainsboro;
            }
        }
        private void circularButton5_Click(object sender, EventArgs e)
        {
            if (circularButton5.BackColor == Color.Gainsboro)
            {
                circularButton5.BackColor = Color.LightSkyBlue;

            }
            else
            {
                circularButton5.BackColor = Color.Gainsboro;
            }
        }
        private void circularButton6_Click(object sender, EventArgs e)
        {
            if (circularButton6.BackColor == Color.Gainsboro)
            {
                circularButton6.BackColor = Color.LightSkyBlue;

            }
            else
            {
                circularButton6.BackColor = Color.Gainsboro;
            }
        }

        private void circularButton7_Click(object sender, EventArgs e)
        {
            if (circularButton7.BackColor == Color.Gainsboro)
            {
                circularButton7.BackColor = Color.LightSkyBlue;

            }
            else
            {
                circularButton7.BackColor = Color.Gainsboro;
            }
        }

        private void circularButton8_Click(object sender, EventArgs e)
        {
            if (circularButton8.BackColor == Color.Gainsboro)
            {
                circularButton8.BackColor = Color.LightSkyBlue;

            }
            else
            {
                circularButton8.BackColor = Color.Gainsboro;
            }
        }

        private void circularButton9_Click(object sender, EventArgs e)
        {
            if (circularButton9.BackColor == Color.Gainsboro)
            {
                circularButton9.BackColor = Color.LightSkyBlue;

            }
            else
            {
                circularButton9.BackColor = Color.Gainsboro;
            }
        }

        private void circularButton10_Click(object sender, EventArgs e)
        {
            if (circularButton10.BackColor == Color.Gainsboro)
            {
                circularButton10.BackColor = Color.LightSkyBlue;

            }
            else
            {
                circularButton10.BackColor = Color.Gainsboro;
            }
        }
        private void circularButton11_Click(object sender, EventArgs e)
        {
            if (circularButton11.BackColor == Color.Gainsboro)
            {
                circularButton11.BackColor = Color.LightSkyBlue;

            }
            else
            {
                circularButton11.BackColor = Color.Gainsboro;
            }
        }
        private void circularButton12_Click(object sender, EventArgs e)
        {
            if (circularButton12.BackColor == Color.Gainsboro)
            {
                circularButton12.BackColor = Color.LightSkyBlue;

            }
            else
            {
                circularButton12.BackColor = Color.Gainsboro;
            }
        }

        private void circularButton13_Click(object sender, EventArgs e)
        {
            if (circularButton13.BackColor == Color.Gainsboro)
            {
                circularButton13.BackColor = Color.LightSkyBlue;

            }
            else
            {
                circularButton13.BackColor = Color.Gainsboro;
            }
        }

        private void circularButton14_Click(object sender, EventArgs e)
        {
            if (circularButton14.BackColor == Color.Gainsboro)
            {
                circularButton14.BackColor = Color.LightSkyBlue;

            }
            else
            {
                circularButton14.BackColor = Color.Gainsboro;
            }
        }

        private void circularButton15_Click(object sender, EventArgs e)
        {
            if (circularButton15.BackColor == Color.Gainsboro)
            {
                circularButton15.BackColor = Color.LightSkyBlue;

            }
            else
            {
                circularButton15.BackColor = Color.Gainsboro;
            }
        }

        private void circularButton16_Click(object sender, EventArgs e)
        {
            if (circularButton16.BackColor == Color.Gainsboro)
            {
                circularButton16.BackColor = Color.LightSkyBlue;
            }
            else
            {
                circularButton16.BackColor = Color.Gainsboro;
            }
        }
        private void circularButton17_Click(object sender, EventArgs e)
        {
            if (circularButton17.BackColor == Color.Gainsboro)
            {
                circularButton17.BackColor = Color.LightSkyBlue;

            }
            else
            {
                circularButton17.BackColor = Color.Gainsboro;
            }
        }

        private void circularButton18_Click(object sender, EventArgs e)
        {
            if (circularButton18.BackColor == Color.Gainsboro)
            {
                circularButton18.BackColor = Color.LightSkyBlue;

            }
            else
            {
                circularButton18.BackColor = Color.Gainsboro;
            }
        }

        private void circularButton19_Click(object sender, EventArgs e)
        {
            if (circularButton19.BackColor == Color.Gainsboro)
            {
                circularButton19.BackColor = Color.LightSkyBlue;

            }
            else
            {
                circularButton19.BackColor = Color.Gainsboro;
            }
        }

        private void circularButton20_Click(object sender, EventArgs e)
        {
            if (circularButton20.BackColor == Color.Gainsboro)
            {
                circularButton20.BackColor = Color.LightSkyBlue;

            }
            else
            {
                circularButton20.BackColor = Color.Gainsboro;
            }
        }

        private void circularButton21_Click(object sender, EventArgs e)
        {
            if (circularButton21.BackColor == Color.Gainsboro)
            {
                circularButton21.BackColor = Color.LightSkyBlue;

            }
            else
            {
                circularButton21.BackColor = Color.Gainsboro;
            }
        }

        private void circularButton22_Click(object sender, EventArgs e)
        {
            if (circularButton22.BackColor == Color.Gainsboro)
            {
                circularButton22.BackColor = Color.LightSkyBlue;

            }
            else
            {
                circularButton22.BackColor = Color.Gainsboro;
            }
        }

        private void circularButton23_Click(object sender, EventArgs e)
        {
            if (circularButton23.BackColor == Color.Gainsboro)
            {
                circularButton23.BackColor = Color.LightSkyBlue;

            }
            else
            {
                circularButton23.BackColor = Color.Gainsboro;
            }
        }

        private void circularButton24_Click(object sender, EventArgs e)
        {
            if (circularButton24.BackColor == Color.Gainsboro)
            {
                circularButton24.BackColor = Color.LightSkyBlue;

            }
            else
            {
                circularButton24.BackColor = Color.Gainsboro;
            }
        }

        private void circularButton25_Click(object sender, EventArgs e)
        {
            if (circularButton25.BackColor == Color.Gainsboro)
            {
                circularButton25.BackColor = Color.LightSkyBlue;

            }
            else
            {
                circularButton25.BackColor = Color.Gainsboro;
            }
        }
        private void buttonLinhaCima_Click(object sender, EventArgs e)
        {
            if (buttonLinhaCima.ForeColor == Color.Black)
            {
                buttonLinhaCima.ForeColor = Color.Blue;
                dataGridViewCombinacoes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            else
            {
                buttonLinhaCima.ForeColor = Color.Black;
                dataGridViewCombinacoes.SelectionMode = DataGridViewSelectionMode.CellSelect;
            }
        }

        private void buttonLinhaBaixo_Click(object sender, EventArgs e)
        {
            if (buttonLinhaBaixo.ForeColor == Color.Black)
            {
                buttonLinhaBaixo.ForeColor = Color.Blue;
                dataGridViewJogos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            else
            {
                buttonLinhaBaixo.ForeColor = Color.Black;
                dataGridViewJogos.SelectionMode = DataGridViewSelectionMode.CellSelect;
            }
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

        private void printDocumentImprmir_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                int Quantidade_Imagens = 0;
                Quantidade_Imagens = 2;
                Bitmap bmp = Properties.Resources.Loterica___D;
                Image newImagem = bmp;

                int width = newImagem.Width;
                int height = newImagem.Height;

                //Draw image to screen.

                int ImagemA = -7;
                int ImagemB = 320;
                int ImagemC = 320 * Quantidade_Imagens + 8;
                int Entrada = 0;
                int TempPag = 0;
                int contador = 0;
                bool usar = false;

                for (int Pagina = 0; Pagina < 2; Pagina++ )
                {
                    for (int linha = 0; linha < 3; linha++)
                    {
                        if ((Pagina > 1) && (linha == 0))
                        {
                            if (contador == 2)
                            {
                                e.HasMorePages = true;
                                e.HasMorePages.ToString();
                                TempPag = Pagina;
                                Pagina = 0;
                                usar = true;
                                contador = 0;
                            }
                            else
                            {
                                e.HasMorePages = false;

                            }
                            e.Graphics.DrawImage(newImagem, -4, ImagemA, (int)(width / 3), (int)(height / 3)); 
                        }             
                        if ((linha == 0) && (Pagina == 0) ) { Entrada = ImagemA; e.Graphics.DrawImage(newImagem, -4, Entrada, (int)(width / 3), (int)(height / 3)); }
                        if (linha == 1) { Entrada = ImagemB; e.Graphics.DrawImage(newImagem, -4, Entrada, (int)(width / 3), (int)(height / 3)); contador++; }
                        if (linha == 2) { Entrada = ImagemC; e.Graphics.DrawImage(newImagem, -4, Entrada, (int)(width / 3), (int)(height / 3)); contador++; }

                        if (usar == true) { Pagina = TempPag; usar = false; }

                    }
                    
                }
                //e.HasMorePages = false;


                //e.Graphics.DrawImage(newImagem, -4, Entrada, (int)(width / 3), (int)(height / 3));
                //e.Graphics.DrawImage(newImagem, -4, Entrada * Quantidade_Imagens + 8, (int)(width / 3), (int)(height / 3));
                //e.Graphics.DrawImage(newImagem, -4, -Entrada, (int)(width / 3), (int)(height / 3));


                //e.Graphics.DrawImage(newImagem, -4, -7, (int)(width / 3), (int)(height / 3));
                //e.Graphics.DrawImage(newImagem, -4, 320, (int)(width / 3), (int)(height / 3));
                //e.Graphics.DrawImage(newImagem, -4, 320 * Quantidade_Imagens + 8, (int)(width / 3), (int)(height / 3));



                //e.Graphics.DrawImage(newImagem, -4, 650, (int)(width / 3), (int)(height / 3));
                // Create pen.
                Pen blackPen = new Pen(Color.Black, 10);

                //Rectangle rectangle = new Rectangle(176 , 206, 2, 9);
                //e.Graphics.DrawRectangle(blackPen, rectangle);
                //Rectangle rectangle2 = new Rectangle(176, 256, 2, 9);
                //e.Graphics.DrawRectangle(blackPen, rectangle2);




                //int Xlinha = 56;
                //int XColuna = 176;
                //int IncrementaXColuna = 0;
                //int IncrementaXLinha = 0;
                //int JogosXL = 0;
                //int JogosXC = 0;              
                //int[,] Array = new int[5, 5];

                //int numero = 1;
                //for (int linha = 0; linha < 5; linha++)
                //{
                //    for (int coluna = 0; coluna < 5; coluna++)
                //    {
                //        Array[linha, coluna] = numero;
                //        numero++;
                //    }
                //}
                //int Contador_linhas = 0, Contador_Coluna = 0;
                //int inicio_linhaJogos = 0, inicio_ColunaJogos = 0, Inicio_linhaArray = 0, Inicio_colunaArray = 0, contador = 0;
 
                //for (int QuantJ = inicio_linhaJogos; QuantJ < int.Parse(FormPrincipal.VerificarTamanho()); QuantJ++)//x1
                //{
                //    for (int LinhaArray = Inicio_linhaArray; LinhaArray < 5; LinhaArray++)//y1
                //    {
                //        for (int colunaQJ = inicio_ColunaJogos; colunaQJ < 15; colunaQJ++)//x2
                //        {
                //            for (int ColunaArray = Inicio_colunaArray; ColunaArray <= 5; ColunaArray++)//y2
                //            {
                //                if (ColunaArray == 5)
                //                {
                //                    inicio_ColunaJogos = colunaQJ;//x2
                //                    colunaQJ = 15;
                //                    ColunaArray = 6;
                //                    Inicio_colunaArray = 0;//y2
                //                }
                //                else
                //                {
                //                    {
                //                        if (FormPrincipal.Armazanados(QuantJ, colunaQJ) == Array[LinhaArray, ColunaArray])
                //                        {
                //                            if (LinhaArray >= 1)
                //                            {
                //                                IncrementaXLinha = 50 * LinhaArray;
                //                            }
                //                            if (LinhaArray == 0)
                //                            {
                //                                IncrementaXLinha = LinhaArray;
                //                            }
                //                            if (ColunaArray >= 1)
                //                            {
                //                                IncrementaXColuna = 18 * ColunaArray;
                //                            }
                //                            if (ColunaArray == 0)
                //                            {
                //                                IncrementaXColuna = ColunaArray;
                //                            }


                //                            Rectangle rectangle = new Rectangle(JogosXC + XColuna + IncrementaXColuna, JogosXL + Xlinha + IncrementaXLinha, 2, 9);
                //                            e.Graphics.DrawRectangle(blackPen, rectangle);

                //                            inicio_ColunaJogos = colunaQJ;//x2
                //                            Inicio_colunaArray = ColunaArray + 1;//y2
                //                            ColunaArray = 15;//y2
                //                            contador++;
                //                        }
                //                        if (contador == 15)
                //                        {
                //                            inicio_ColunaJogos = 0;
                //                            Inicio_colunaArray = 0;
                //                            Inicio_linhaArray = 0;
                //                            colunaQJ = 15;
                //                            ColunaArray = 6;
                //                            LinhaArray = 5;
                //                            contador = 0;
                //                        }
                //                    }
                //                }
                //            }
                //        }
                //    }
                //    Contador_Coluna++;
                //    JogosXC = 99 * Contador_Coluna;
                //    if(Contador_Coluna == 3)
                //    {
                //        Contador_linhas++;
                //        Contador_Coluna = 0;
                //        JogosXL = 328 * Contador_linhas;
                //        JogosXC = 0;
                //        IncrementaXLinha = 0;
                //        IncrementaXLinha = 0;
                //    }
                //    QuantJ.ToString();
                //}
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public void ImprimirJogos()
        {
        

        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
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






//if (ElementosListaConsta.Count > 0)
//{
//    //Quantidade
//    for (int lista = 0; lista < ElementosListaConsta.Count; lista++)
//    {
//        for (int coluna = 0; coluna < 15; coluna++)
//        {
//            if (ElementosListaConsta[lista] == FormPrincipal.Armazanados(i, coluna))
//            {
//                consta++;
//                coluna = 15;
//            }
//        }
//    }
//    if (consta == ElementosListaConsta.Count)
//    {
//        for (int coluna = 0; coluna < 15; coluna++)
//        {
//            //SOMA DA LINHA
//            soma = FormPrincipal.Armazanados(i, coluna);
//            total = soma + total;
//            //PAR E IMPAR
//            if (FormPrincipal.Armazanados(i, coluna) % 2 == 0)
//            {
//                par++;
//            }
//            else
//            {
//                impar++;
//            }//REPETIDAS
//            for (int rep = 0; rep < int.Parse(FormPrincipal.ArrayRepetidaTamanhoQuantidade()); rep++)
//            {
//                if (FormPrincipal.ArrayRepetidasRetorno(rep) == FormPrincipal.Armazanados(i, coluna))
//                {
//                    repetidas++;
//                    rep = int.Parse(FormPrincipal.ArrayRepetidaTamanhoQuantidade());
//                }
//            }//MODULA
//            int[] ArrayMoldura = new int[] { 1, 2, 3, 4, 5, 6, 10, 11, 15, 16, 20, 21, 22, 23, 24, 25 };
//            for (int colunaM = 0; colunaM < ArrayMoldura.Length; colunaM++)
//            {
//                if (FormPrincipal.Armazanados(i, coluna) == ArrayMoldura[colunaM])
//                {
//                    modula++;
//                    colunaM = ArrayMoldura.Length;
//                }
//            }//PRIMOS
//            int[] ArrayPrimos = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23 };
//            for (int colunaP = 0; colunaP < ArrayPrimos.Length; colunaP++)
//            {
//                if (FormPrincipal.Armazanados(i, coluna) == ArrayPrimos[colunaP])
//                {
//                    primos++; ;
//                    colunaP = ArrayPrimos.Length;
//                }
//            }//FIBONACCI
//            int[] Fibonacci = new int[] { 1, 2, 3, 5, 8, 13, 21 };
//            for (int colunaF = 0; colunaF < Fibonacci.Length; colunaF++)
//            {
//                if (FormPrincipal.Armazanados(i, coluna) == Fibonacci[colunaF])
//                {
//                    fibonacci++; ;
//                    colunaF = Fibonacci.Length;
//                }
//            }//MUTL 3
//            int[] ArrayMult = new int[] { 3, 6, 9, 12, 15, 18, 21, 24 };
//            for (int colunaML = 0; colunaML < ArrayMult.Length; colunaML++)
//            {
//                if (FormPrincipal.Armazanados(i, coluna) == ArrayMult[colunaML])
//                {
//                    mult++; ;
//                    colunaML = ArrayMult.Length;
//                }
//            }//TENHA SOBRA
//            for (int colunaSobra = 0; colunaSobra < int.Parse(FormPrincipal.ArrayResultadoSobraTamanho()); colunaSobra++)
//            {
//                if (FormPrincipal.Armazanados(i, coluna) == FormPrincipal.ArrayResultadoSobraRetorno(colunaSobra))
//                {
//                    sobra++; ;
//                    colunaSobra = int.Parse(FormPrincipal.ArrayResultadoSobraTamanho());
//                }
//            }//MÁGICOS
//            int[] ArrayMagicos = new int[] { 5, 6, 7, 12, 13, 14, 19, 20, 21 };
//            for (int colunaMS = 0; colunaMS < ArrayMagicos.Length; colunaMS++)
//            {
//                if (FormPrincipal.Armazanados(i, coluna) == ArrayMagicos[colunaMS])
//                {
//                    magicos++;
//                    colunaMS = ArrayMagicos.Length;
//                }
//            }
//        }
//        dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[0].Value = dataGridViewJogos.Rows.Count;
//        for (int coluna = 0; coluna < dataGridViewJogos.Columns.Count; coluna++)
//        {
//            if (coluna < 15)
//            {
//                for (int arrayM = 0; arrayM < int.Parse(FormPrincipal.ArrayRepetidaTamanho()); arrayM++)
//                {
//                    if (FormPrincipal.ArrayRepetidasRetorno(arrayM) > FormPrincipal.Armazanados(i, coluna))
//                    {
//                        dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[coluna + 1].Value = FormPrincipal.Armazanados(i, coluna);
//                        arrayM = int.Parse(FormPrincipal.ArrayRepetidaTamanho());
//                    }
//                    else
//                    {
//                        if (FormPrincipal.Armazanados(i, coluna) == FormPrincipal.ArrayRepetidasRetorno(arrayM))
//                        {
//                            dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[coluna + 1].Value = FormPrincipal.Armazanados(i, coluna);
//                            dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[coluna + 1].Style.BackColor = Color.Pink;
//                            arrayM = int.Parse(FormPrincipal.ArrayRepetidaTamanho());
//                        }
//                    }
//                }
//            }
//        }
//        dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[16].Value = par + " :e: " + impar;
//        dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[17].Value = Convert.ToString(repetidas);
//        dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[18].Value = Convert.ToString(modula);
//        dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[19].Value = Convert.ToString(primos);
//        dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[20].Value = Convert.ToString(fibonacci);
//        dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[21].Value = Convert.ToString(mult);
//        dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[22].Value = Convert.ToString(sobra);
//        dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[23].Value = Convert.ToString(magicos);
//        dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[24].Value = Convert.ToString(total);
//        par = 0; impar = 0; repetidas = 0; modula = 0; primos = 0; fibonacci = 0; mult = 0; sobra = 0; magicos = 0; total = 0; soma = 0;

//        dataGridViewJogos.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
//    }
//    consta = 0;
//}
//else
//{
//    for (int coluna = 0; coluna < 15; coluna++)
//    {
//        //SOMA DA LINHA
//        soma = FormPrincipal.Armazanados(i, coluna);
//        total = soma + total;

//        //PAR E IMPAR + SOMA DA LINHA
//        if (FormPrincipal.Armazanados(i, coluna) % 2 == 0)
//        {
//            par++;
//        }
//        else
//        {
//            impar++;
//        }//REPETIDAS
//        for (int rep = 0; rep < int.Parse(FormPrincipal.ArrayRepetidaTamanhoQuantidade()); rep++)
//        {
//            if (FormPrincipal.ArrayRepetidasRetorno(rep) == FormPrincipal.Armazanados(i, coluna))
//            {
//                repetidas++;
//                rep = int.Parse(FormPrincipal.ArrayRepetidaTamanhoQuantidade());
//            }
//        }//MODULA
//        int[] ArrayMoldura = new int[] { 1, 2, 3, 4, 5, 6, 10, 11, 15, 16, 20, 21, 22, 23, 24, 25 };
//        for (int colunaM = 0; colunaM < ArrayMoldura.Length; colunaM++)
//        {
//            if (FormPrincipal.Armazanados(i, coluna) == ArrayMoldura[colunaM])
//            {
//                modula++;
//                colunaM = ArrayMoldura.Length;
//            }
//        }//PRIMOS
//        int[] ArrayPrimos = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23 };
//        for (int colunaP = 0; colunaP < ArrayPrimos.Length; colunaP++)
//        {
//            if (FormPrincipal.Armazanados(i, coluna) == ArrayPrimos[colunaP])
//            {
//                primos++; ;
//                colunaP = ArrayPrimos.Length;
//            }
//        }//FIBONACCI
//        int[] Fibonacci = new int[] { 1, 2, 3, 5, 8, 13, 21 };
//        for (int colunaF = 0; colunaF < Fibonacci.Length; colunaF++)
//        {
//            if (FormPrincipal.Armazanados(i, coluna) == Fibonacci[colunaF])
//            {
//                fibonacci++; ;
//                colunaF = Fibonacci.Length;
//            }
//        }//MUTL 3
//        int[] ArrayMult = new int[] { 3, 6, 9, 12, 15, 18, 21, 24 };
//        for (int colunaML = 0; colunaML < ArrayMult.Length; colunaML++)
//        {
//            if (FormPrincipal.Armazanados(i, coluna) == ArrayMult[colunaML])
//            {
//                mult++; ;
//                colunaML = ArrayMult.Length;
//            }
//        }//TENHA SOBRA
//        for (int colunaSobra = 0; colunaSobra < int.Parse(FormPrincipal.ArrayResultadoSobraTamanho()); colunaSobra++)
//        {
//            if (FormPrincipal.Armazanados(i, coluna) == FormPrincipal.ArrayResultadoSobraRetorno(colunaSobra))
//            {
//                sobra++; ;
//                colunaSobra = int.Parse(FormPrincipal.ArrayResultadoSobraTamanho());
//            }
//        }
//        int[] ArrayMagicos = new int[] { 5, 6, 7, 12, 13, 14, 19, 20, 21 };
//        for (int colunaMS = 0; colunaMS < ArrayMagicos.Length; colunaMS++)
//        {
//            if (FormPrincipal.Armazanados(i, coluna) == ArrayMagicos[colunaMS])
//            {
//                magicos++;
//                colunaMS = ArrayMagicos.Length;
//            }
//        }
//    }
//    dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[0].Value = dataGridViewJogos.Rows.Count;
//    for (int coluna = 0; coluna < dataGridViewJogos.Columns.Count; coluna++)
//    {
//        if (coluna < 15)
//        {
//            for (int arrayM = 0; arrayM < int.Parse(FormPrincipal.ArrayRepetidaTamanho()); arrayM++)
//            {
//                if (FormPrincipal.ArrayRepetidasRetorno(arrayM) > FormPrincipal.Armazanados(i, coluna))
//                {
//                    dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[coluna + 1].Value = FormPrincipal.Armazanados(i, coluna);
//                    arrayM = int.Parse(FormPrincipal.ArrayRepetidaTamanho());
//                }
//                else
//                {
//                    if (FormPrincipal.Armazanados(i, coluna) == FormPrincipal.ArrayRepetidasRetorno(arrayM))
//                    {
//                        dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[coluna + 1].Value = FormPrincipal.Armazanados(i, coluna);
//                        dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[coluna + 1].Style.BackColor = Color.Pink;
//                        arrayM = int.Parse(FormPrincipal.ArrayRepetidaTamanho());
//                    }
//                }
//            }
//        }
//    }
//    dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[16].Value = par + " :e: " + impar;
//    dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[17].Value = Convert.ToString(repetidas);
//    dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[18].Value = Convert.ToString(modula);
//    dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[19].Value = Convert.ToString(primos);
//    dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[20].Value = Convert.ToString(fibonacci);
//    dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[21].Value = Convert.ToString(mult);
//    dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[22].Value = Convert.ToString(sobra);
//    dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[23].Value = Convert.ToString(magicos);
//    dataGridViewJogos.Rows[dataGridViewJogos.Rows.Count - 1].Cells[24].Value = Convert.ToString(total);
//    par = 0; impar = 0; repetidas = 0; modula = 0; primos = 0; fibonacci = 0; mult = 0; sobra = 0; magicos = 0; total = 0; soma = 0;

//    dataGridViewJogos.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
//}