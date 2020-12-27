using Android.Webkit;
using FilePickerDemo.Droid;
using FilePickerDemo.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(FilePickerHelper))]
namespace FilePickerDemo.Droid
{
	public class FilePickerHelper : IFilePickerHelper
	{
		public string GetFileType(string extension)
			=> MimeTypeMap.Singleton.GetMimeTypeFromExtension(extension);
	}
}
