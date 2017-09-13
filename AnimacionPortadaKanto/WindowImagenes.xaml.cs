/*
 * Creado por SharpDevelop.
 * Usuario: Pikachu240
 * Fecha: 13/09/2017
 * Hora: 8:23
 * Licencia GNU GPL V3
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Gabriel.Cat.Extension;
using PokemonGBAFrameWork;

namespace AnimacionPortadaKanto
{
	/// <summary>
	/// Interaction logic for WindowImagenes.xaml
	/// </summary>
	public partial class WindowImagenes : Window
	{

		RomGba rom;
		public WindowImagenes(RomGba rom,IList<int> offsetsImg)
		{
			ImgAnimacion img;
			this.rom=rom;
			InitializeComponent();
			for(int i=0;i<offsetsImg.Count;i++)
			{
				img=new ImgAnimacion(rom,offsetsImg[i]);
				img.Eliminado+=ImgEliminada;
				stkImgs.Children.Add(img);
			}
			

		}

		public IList<int> OffsetsImgs {
			get {
				return stkImgs.Children.Casting<int>(); 
			}
		}
		void BtnAñadir_Click(object sender, RoutedEventArgs e)
		{
			stkImgs.Children.Add(new ImgAnimacion(rom));
		}

		void ImgEliminada(object sender, EventArgs e)
		{
			//doy la opcion de borrar los datos de la imagen (cuando sepa como claro...)
			stkImgs.Children.Remove(sender as UIElement);
			
		}
	}
}