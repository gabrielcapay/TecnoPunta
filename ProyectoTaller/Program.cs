using ProyectoTaller.CNegocio;
using ProyectoTaller.Questpdf;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Windows.Forms;

namespace ProyectoTaller
{
    internal static class Program
    {
   
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
         
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormularioInicio());
 
        }
    }
 }

