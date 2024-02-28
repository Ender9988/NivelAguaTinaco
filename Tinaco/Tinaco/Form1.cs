using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
namespace Tinaco
{
    public partial class Bomba : Form
    {
        // Declara un objeto SerialPort para el COMX
        private SerialPort serialPort2; 

        public Bomba()
        {
            InitializeComponent();

            // Inicializa el objeto SerialPort para el COMX
            serialPort2 = new SerialPort(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //En el caso de que funcione correctamente
            try
            {
                // Configura el COMX para la comunicación
                serialPort2.PortName = "COM7"; //<!!!Cambiar por el COM del USB!!!------------------------------>
                serialPort2.Open(); // Abre el puerto COMX
                serialPort2.DataReceived += SerialPort2_DataReceived; // Suscribe el evento DataReceived
            }
            //En el caso que se genere un error, aparece en la pantalla
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Cuando se cierra la aplicacion se cierra el puerto serial en caso de estar abierto
            if (serialPort2.IsOpen)
            {
                serialPort2.Close();
            }
        }

        //Metodo que recibira la informacion 
        private void SerialPort2_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                //La variable RXCOM recibira el caracter por el puerto serial de COMX
                char RXCOM = (char)serialPort2.ReadByte();

                // Actualiza el texto del label 'EstadoSistema' basado en el carácter recibido
                if (RXCOM == 'E')
                {
                    //Cambia el mensaje del cuadro en pantalla por Encendido
                    SetEstadoSistemaText("Encendido");
            //        ColorBomba.BackColor = Color.Green; //Establece el color dela bomba a verde
                }

                //En el caso de que el caracter sea 0, sera nivel 0 
                if (RXCOM == '0')
                {
                    nivel0.BackColor = Color.Red; //Cambia el color del cuadro del nivel 0
                    nivel1.BackColor = Color.Black; //Establece el color del cuadro a negro
                    nivel2.BackColor = Color.Black; //Establece el color del cuadro a negro
                    nivel3.BackColor = Color.Black; //Establece el color del cuadro a negro
                    SetEstadoSistemaText2("Encendido"); //Enciende la bomba del agua

                }
                //En el caso de que el caracter sea 1, sera nivel 1
                if (RXCOM == '1')
                {
                    nivel0.BackColor = Color.Red; //Cambia el color del cuadro del nivel 0
                    nivel1.BackColor = Color.Yellow; //Cambia el color del cuadro del nivel 1
                    nivel2.BackColor = Color.Black;  //Establece el color del cuadro a negro
                    nivel3.BackColor = Color.Black;  //Establece el color del cuadro a negro
                   
                }
                //En el caso de que el caracter sea 2, sera nivel 2
                if (RXCOM == '2')
                {
                    nivel0.BackColor = Color.Red; //Cambia el color del cuadro del nivel 0
                    nivel1.BackColor = Color.Yellow; //Cambia el color del cuadro del nivel 1
                    nivel2.BackColor = Color.Yellow; //Cambia el color del cuadro del nivel 2
                    nivel3.BackColor = Color.Black;  //Establece el color del cuadro a negro
                  
                }
                //En el caso de que el caracter sea 3, sera nivel 3
                if (RXCOM == '3')
                {
                    nivel0.BackColor = Color.Red; //Cambia el color del cuadro del nivel 0
                    nivel1.BackColor = Color.Yellow; //Cambia el color del cuadro del nivel 1
                    nivel2.BackColor = Color.Yellow; //Cambia el color del cuadro del nivel 2
                    nivel3.BackColor = Color.Green; //Cambia el color del cuadro del nivel 3
                    SetEstadoSistemaText2("Apagado"); //Muestra que la bomba esta desactivada
                }

                //En el caso de que el caracter sea A se apaga el sistema
                if (RXCOM == 'A')
                {
                    SetEstadoSistemaText("Apagado");
                    nivel0.BackColor = Color.Black; //Establece el color del cuadro a negro
                    nivel1.BackColor = Color.Black; //Establece el color del cuadro a negro
                    nivel2.BackColor = Color.Black; //Establece el color del cuadro a negro
                    nivel3.BackColor = Color.Black; //Establece el color del cuadro a negro
                   
                }

               
            }
            catch (Exception ex)
            {
                //Muestra el error en caso de haber
                MessageBox.Show(ex.Message);
            }
        }

        //Metodo que cambia el mensaje en la pantalla
        private void SetEstadoSistemaText(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(SetEstadoSistemaText), text);
            }
            else
            {
                //Cambia el mensaje de los campos a Encendido o Apagado
                EstadoSistema.Text = text;
            }
        }

        //Metodo que cambia el mensaje en la pantalla
        private void SetEstadoSistemaText2(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(SetEstadoSistemaText2), text);
            }
            else
            {
                //Cambia el mensaje de la bomba a Encendido o Apagado
                EstadoBomba.Text = text;
            }
        }


    }
}

