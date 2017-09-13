/*
 * Creado por SharpDevelop.
 * Usuario: Pikachu240
 * Fecha: 13/09/2017
 * Hora: 8:31
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
using PokemonGBAFrameWork;

namespace AnimacionPortadaKanto
{
	/// <summary>
	/// Interaction logic for ImgAnimacion.xaml
	/// </summary>
	public partial class ImgAnimacion : UserControl
	{
		RomGba rom;
		public event EventHandler Eliminado;
		public ImgAnimacion(RomGba rom,int offsetData=0)
		{
			
			InitializeComponent();
			OffsetData=offsetData;
		}
		public int OffsetData
		{
			get;
			set;
		}
		public static implicit operator int(ImgAnimacion imgAnimacion)
		{
			return imgAnimacion.OffsetData;
		}
	}
}