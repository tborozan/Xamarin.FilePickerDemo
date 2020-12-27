using FilePickerDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FilePickerDemo
{
	public partial class MainPage : ContentPage
	{
		private readonly IFilePickerHelper _filePickerHelper = DependencyService.Get<IFilePickerHelper>();
		private ObservableCollection<FileResult> _files = new ObservableCollection<FileResult>();

		public MainPage()
		{
			InitializeComponent();
			FileList.ItemsSource = Files;
		}

		public ObservableCollection<FileResult> Files { get => _files; }

		private async void FilePickerButton_OnClicked(object sender, EventArgs e)
		{
			var file = await Device.InvokeOnMainThreadAsync(async () => await FilePicker.PickAsync());
			if (file != null)
			{
				Files.Add(file);
			}
		}

		private async void ImageFilePickerButton_OnClicked(object sender, EventArgs e)
		{
			var pickerOptions = new PickOptions
			{
				PickerTitle = "Image Picker",
				FileTypes = FilePickerFileType.Images
			};

			var file = await Device.InvokeOnMainThreadAsync(async () => await FilePicker.PickAsync(pickerOptions));
			if (file != null)
			{
				Files.Add(file);
			}
		}

		private async void ZipFilePickerButton_OnClicked(object sender, EventArgs e)
		{
			var zipFileType = _filePickerHelper.GetFileType("zip");

			var pickerOptions = new PickOptions
			{
				PickerTitle = "ZIP Picker",
				FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
				{
					{ DevicePlatform.Create(Device.RuntimePlatform), new string[] { zipFileType } }
				})
			};

			var file = await Device.InvokeOnMainThreadAsync(async () => await FilePicker.PickAsync(pickerOptions));
			if (file != null)
			{
				Files.Add(file);
			}
		}
	}
}
