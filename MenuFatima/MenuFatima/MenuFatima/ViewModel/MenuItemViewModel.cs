using MenuFatima.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;

namespace MenuFatima.ViewModel
{
    public class MenuItemViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private List<catoriaModel> listCategoria;

        public List<catoriaModel> ListCategoria
        {
            get { return listCategoria; }
            set { listCategoria = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<MenuItemModel> listMenu;

        public ObservableCollection<MenuItemModel> ListMenu
        {
            get { return listMenu; }
            set { listMenu = value; RaisePropertyChanged(); }
        }

        private catoriaModel selectedCategory;

        public catoriaModel SelectedCategory
        {
            get { return selectedCategory; }
            set { selectedCategory = value;
                var name=selectedCategory.nomcategoria;
                var id = selectedCategory.id;
                App.Current.MainPage.DisplayAlert("Nombre de la categoria", name+" el id es: "+id,"oki");
            }
        }


        public MenuItemViewModel()
        {
            ListMenu = new ObservableCollection<MenuItemModel>();
            ListMenu.Add(new MenuItemModel {
                id_combo = 1,
                Nombre_Combo="Combo 1",
                precio ="2.50",
                descripcion = "Frijoles, Platano, Café, Pan frances"
            });
            ListMenu.Add(new MenuItemModel
            {
                id_combo = 2,
                Nombre_Combo = "Combo 2",
                precio = "2.50",
                descripcion = "Frijoles, Platano, Café, Pan frances, pan dulce"
            });
            getCategoria();
            
        }

        public async void getCategoria()
        {
            var cliente = new HttpClient();
            string URL = string.Format("http://paraisoreal19.somee.com/api/categoriass/Getcategorias");
           // var resp = await cliente.GetAsync(URL);
            var miArreglo = await cliente.GetStringAsync(URL);
            //var result = resp.Content.ReadAsStringAsync().Result;
            //JObject values = JObject.Parse(result);
            ListCategoria = JsonConvert.DeserializeObject<List<catoriaModel>>(miArreglo);
            //int lon = values.Count;
            //Debug.WriteLine(lon);
            Debug.WriteLine(ListCategoria);

        }
        private void RaisePropertyChanged([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                if (!string.IsNullOrEmpty(propertyname))
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
                }
            }
        }
    }
}
