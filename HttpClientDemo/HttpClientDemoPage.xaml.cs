using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace HttpClientDemo
{
	public partial class HttpClientDemoPage : ContentPage
	{
		public HttpClientDemoPage()
		{
			InitializeComponent();
			LoadData();
		}

		async void LoadData()
		{
			var _client = new HttpClient();
			var jsonvalue = await _client.GetAsync("http://ins-info.ib.gov.tw/opendata/json-05010111.aspx");
			if (jsonvalue.IsSuccessStatusCode)
			{
				listView.ItemsSource =
					JsonConvert.DeserializeObject<List<InsuranceCompany>>(
								jsonvalue.Content.ReadAsStringAsync().Result);
			}
		}
	}
}
