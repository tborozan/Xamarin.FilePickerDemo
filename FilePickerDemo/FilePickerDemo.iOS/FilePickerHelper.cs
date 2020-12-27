using FilePickerDemo.Interfaces;
using FilePickerDemo.iOS;
using MobileCoreServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(FilePickerHelper))]
namespace FilePickerDemo.iOS
{
	public class FilePickerHelper : IFilePickerHelper
	{
		public string GetFileType(string extension)
			=> UTType.CreatePreferredIdentifier(UTType.TagClassFilenameExtension, extension, null);
	}
}
