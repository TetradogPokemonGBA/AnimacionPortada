/*
 * Creado por SharpDevelop.
 * Usuario: Pikachu240
 * Fecha: 13/09/2017
 * Hora: 8:03
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

namespace AnimacionPortadaKanto
{
	/// <summary>
	/// Interaction logic for Frame.xaml
	/// </summary>
	public partial class Frame : UserControl
	{
		IList<int> offsetsImgData;
		PokemonGBAFrameWork.AnimaciónPortada.FrameAnimacion frame;
		public event EventHandler Eliminado;

		public Frame(IList<int> offsetsImgData):this(offsetsImgData,new PokemonGBAFrameWork.AnimaciónPortada.FrameAnimacion())
		{
		}

		public Frame(IList<int> offsetsImgData,PokemonGBAFrameWork.AnimaciónPortada.FrameAnimacion frame)
		{
			InitializeComponent();
			//pongo los campos
			OffsetsImgData=offsetsImgData;
			FrameAnimacion=frame;
		}

		public IList<int> OffsetsImgData {
			get {
				return offsetsImgData;
			}
			set {
				offsetsImgData = value;
		        //pongo el combobox con los datos nuevos
		        //miro de buscar el offsetActual en la lista, si no lo encuentro pongo el primer frame
			}
		}

		public PokemonGBAFrameWork.AnimaciónPortada.FrameAnimacion FrameAnimacion {
			get {
				return frame;
			}
			set {
				frame = value;
			}
		}
	}
}