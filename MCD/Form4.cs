﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCD
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 regresar = new Form1();
            regresar.Visible = true;
            Visible = false;
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            label2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Int32 mcd = 1;
            Int32 residuo;
            Int32 complemento;
            Int32 numero1;
            Int32 numero2;
            Int32 numero3;
            Int32 numero4;
            string texto1;
            string texto2;
            string texto3;
            string texto4;
            string salida = "";
            bool errores = false;
            // Eliminamos espacios de la cadena para evitar errores

            texto1 = textBox1.Text.Replace(" ", "");
            texto2 = textBox2.Text.Replace(" ", "");
            texto3 = textBox3.Text.Replace(" ", "");
            texto4 = textBox4.Text.Replace(" ", "");

            if (texto1 == "" || texto2 == "" || texto3 == "" || texto4 == "")
            {
                errores = true;
                MessageBox.Show("Los campos no pueden estar vacios", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                numero1 = Convert.ToInt32(texto1);
                numero2 = Convert.ToInt32(texto2);
                numero3 = Convert.ToInt32(texto3);
                numero4 = Convert.ToInt32(texto4);

                salida = "Primer Procedimiento: " + Environment.NewLine;

                if (numero1 == 0 || numero2 == 0 || numero3 == 0 || numero4 == 0)
                {
                    MessageBox.Show("Ningun numero puede ser 0", "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errores = true;
                }
                else
                {
                    do
                    {
                        residuo = numero1 % numero2;
                        complemento = numero1 / numero2;
                        salida = salida + string.Empty;
                        salida = salida + string.Format(numero1 + "=" + numero2 + "*" + complemento + "+" + residuo + "\n") + Environment.NewLine;

                        if (residuo != 0)
                        {
                            numero1 = numero2;
                            numero2 = residuo;
                        }
                        else
                        {
                            mcd = numero2;
                        }
                    } while (residuo != 0);
                    residuo = 0;
                    complemento = 0;
                    salida = salida + Environment.NewLine + "Segundo Procedimiento: " + Environment.NewLine;
                    do
                    {
                        residuo = numero2 % numero3;
                        complemento = numero2 / numero3;
                        salida = salida + string.Empty;
                        salida = salida + string.Format(numero2 + "=" + numero3 + "*" + complemento + "+" + residuo + "\n") + Environment.NewLine;

                        if (residuo != 0)
                        {
                            numero2 = numero3;
                            numero3 = residuo;
                        }
                        else
                        {
                            mcd = numero3;
                        }
                    } while (residuo != 0);
                    residuo = 0;
                    complemento = 0;
                    salida = salida + Environment.NewLine + "Tercer Procedimiento: " + Environment.NewLine;
                    do
                    {
                        residuo = numero3 % numero4;
                        complemento = numero3 / numero4;
                        salida = salida + string.Empty;
                        salida = salida + string.Format(numero3 + "=" + numero4 + "*" + complemento + "+" + residuo + "\n") + Environment.NewLine;

                        if (residuo != 0)
                        {
                            numero3 = numero4;
                            numero4 = residuo;
                        }
                        else
                        {
                            mcd = numero4;
                        }
                    } while (residuo != 0);
                }
            }
            if (errores == true)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                label2.Text = "";
            }
            else
            {
                label2.Text = mcd.ToString();
                textBox5.Text = salida;
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            label2.Text = "";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
        }
    }
}
