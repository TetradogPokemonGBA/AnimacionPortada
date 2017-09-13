/*
 * Creado por SharpDevelop.
 * Usuario: Pikachu240
 * Fecha: 13/09/2017
 * Hora: 7:45
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
using Gabriel.Cat;
using Microsoft.Win32;
using PokemonGBAFrameWork;

namespace AnimacionPortadaKanto
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		AnimaciónPortada animacion;
		RomGba rom;
		EdicionPokemon edicion;
		Compilacion compilacion;
		int[] offsetsDataImg;
		public Window1()
		{
			
			InitializeComponent();
		}
		void MiCargar_Click(object sender, RoutedEventArgs e)
		{
			Frame frame;
			
			OpenFileDialog opnFile = new OpenFileDialog();
			opnFile.Filter = "Pokemon GBA Region Kanto|*.gba";
			if (opnFile.ShowDialog().GetValueOrDefault()) {
				rom = new RomGba(opnFile.FileName);
				edicion = EdicionPokemon.GetEdicionPokemon(rom);
				if (edicion.AbreviacionRom != AbreviacionCanon.BPG && edicion.AbreviacionRom != AbreviacionCanon.BPR) {
					MessageBox.Show("La rom no es de la región de Kanto...");
					rom = null;
					edicion = null;
					compilacion = null;
					animacion = null;
					
				} else {
					compilacion = Compilacion.GetCompilacion(rom, edicion);
					if (AnimaciónPortada.EstaActivado(rom)) {
						animacion = AnimaciónPortada.GetAnimacionPortada(rom, edicion, compilacion);
						offsetsDataImg = animacion.OffsetsImgData();
						for (int i = 0; i < animacion.Frames.Count; i++) {
							frame = new Frame(offsetsDataImg, animacion[i]);
							frame.Eliminado +=EliminarFrame;
							stkFrames.Children.Add(frame);
						}
						txtTablaFrames.Text = ((Hex)AnimaciónPortada.GetOffsetTabla(rom, edicion, compilacion)).ByteString;
					}
				}
				btnAñadir.IsEnabled=rom!=null;
				btnGuardar.IsEnabled=rom!=null;
				miImgs.IsEnabled=rom!=null;
			}
		}

		void EliminarFrame(object sender, EventArgs e)
		{
			stkFrames.Children.Remove((UIElement)sender);
		}

		void MiSobre_Click(object sender, RoutedEventArgs e)
		{
			if(MessageBox.Show("Este programa sirve para gestionar la animación de la portada, compatible solo con las roms región Kanto.\n\nCréditos\nDarthatron por la investigación (PokemonComunity) \nkaratekid552 por la rutina acortada (PokemonComunity) \nΩmega por el tutorial(Wahackforo)\n\nEl programa esta bajo licencia GNU ¿Quieres ver el código fuente?","Sobre la aplicación",MessageBoxButton.YesNo,MessageBoxImage.Information)==MessageBoxResult.Yes)
				System.Diagnostics.Process.Start("https://github.com/TetradogPokemonGBA/AnimacionPortada");
		}
		void BtnAñadir_Click(object sender, RoutedEventArgs e)
		{
			Frame frame=new Frame(offsetsDataImg);
			frame.Eliminado+=EliminarFrame;
			stkFrames.Children.Add(frame);
		}
		void BtnGuardar_Click(object sender, RoutedEventArgs e)
		{
			Frame frameAct;
			animacion.Frames.Clear();
			
			for (int i = 0; i < stkFrames.Children.Count; i++) {
				frameAct = stkFrames.Children[i] as Frame;
				animacion.Frames.Add(frameAct.FrameAnimacion);
			}
			AnimaciónPortada.SetAnimacionPortada(rom, edicion, compilacion, animacion);
			try {
				rom.Save();
			} catch {
				if (MessageBox.Show("No se ha podido guardar los datos porque otro programa  usa la rom actualmente, cierralo y continua", "Atención no se ha podido guardar los datos", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
					try {
					rom.Save();
				} catch {
					MessageBox.Show("No se ha podido guardar...");
				}
				
			}
		}
		void MiImgs_Click(object sender, RoutedEventArgs e)
		{
			Frame frame;
			WindowImagenes winImgs=new WindowImagenes(rom,offsetsDataImg);
			winImgs.ShowDialog();
			for(int i=0;i<stkFrames.Children.Count;i++)
			{
				frame=stkFrames.Children[i] as Frame;
				frame.OffsetsImgData=winImgs.OffsetsImgs; 
			}
		}
	}
}