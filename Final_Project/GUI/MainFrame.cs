﻿using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class mainFrame : Form
    {
        /// <summary>
        /// Count the click number of the button
        /// </summary>
        private int count_click;
        private List<Element> elements;
        private string[] columnsValues;
        private ComboBox cbFilterBy;
        /*
         * source data to be consulted
         */
        private static String uRL = "https://www.datos.gov.co/resource/ysq6-ri4e.json?$limit=50&";

        public static string URL { get => uRL; set => uRL = value; }

        public mainFrame()
        {
            URL = uRL;
            count_click = 0;
            InitializeComponent();
            columnsValues = new string[15];
            elements = new List<Element>();
            //todos_los_municipios();
        }

        private void MainFrame_Load(object sender, EventArgs e)
        {

            ViewGrid();
            AddNameColumnToList();
        }

        /// <summary>
        /// Permite añadir los nombres de las columnas a una lista para luego ser utilizada.
        /// </summary>
        private void AddNameColumnToList()
        {

            columnsValues[0] = "fecha";
            columnsValues[1] = "autoridad_ambiental";
            columnsValues[2] = "nombre_de_la_estaci_n";
            columnsValues[3] = "tecnolog_a";
            columnsValues[4] = "latitud";
            columnsValues[5] = "longitud";
            columnsValues[6] = "c_digo_del_departamento";
            columnsValues[7] = "departamento";
            columnsValues[8] = "c_digo_del_municipio";
            columnsValues[9] = "nombre_del_municipio";
            columnsValues[10] = "tipo_de_estaci_n";
            columnsValues[11] = "tiempo_de_exposici_n";
            columnsValues[12] = "variable";
            columnsValues[13] = "unidades";
            columnsValues[14] = "concentraci_n";

        }


        private async void ViewGrid()
        {
            string respuesta = await GetHttp(URL);
            List<ViewModel> lst = JsonConvert.DeserializeObject<List<ViewModel>>(respuesta);
            dtGrid.DataSource = lst;
            pollutionColor(lst);
        }


        public async Task<string> GetHttp(String url)
        {
            WebRequest webRequest = WebRequest.Create(url);
            WebResponse webResponse = webRequest.GetResponse();
            StreamReader sr = new StreamReader(webResponse.GetResponseStream());

            return await sr.ReadToEndAsync();
        }




        private void dtGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btFilter_Click(object sender, EventArgs e)
        {
            if (elements != null)
            {

                foreach (var values in elements)
                {
                    if (values.ComboBox.Enabled == true)
                    {


                        values.ComboBox.Enabled = false;

                        string columnName = values.ComboBox.Text;
                        string valueToFilter = values.TextBox.Text;


                        if (columnName.Equals(columnsValues[0]))
                        {
                            URL += "" + columnName + "=" + valueToFilter + "&";
                        }
                        else if (columnName.Equals(columnsValues[1]))
                        {
                            URL += "" + columnName + "=" + valueToFilter + "&";

                        }
                        else if (columnName.Equals(columnsValues[2]))
                        {
                            URL += "" + columnName + "=" + valueToFilter + "&";

                        }
                        else if (columnName.Equals(columnsValues[3]))
                        {
                            URL += "" + columnName + "=" + valueToFilter + "&";

                        }
                        else if (columnName.Equals(columnsValues[4]))
                        {
                            URL += "" + columnName + "=" + valueToFilter + "&";

                        }
                        else if (columnName.Equals(columnsValues[5]))
                        {
                            URL += "" + columnName + "=" + valueToFilter + "&";

                        }
                        else if (columnName.Equals(columnsValues[6]))
                        {
                            URL += "" + columnName + "=" + valueToFilter + "&";

                        }
                        else if (columnName.Equals(columnsValues[7]))
                        {
                            URL += "" + columnName + "=" + valueToFilter + "&";

                        }
                        else if (columnName.Equals(columnsValues[8]))
                        {
                            URL += "" + columnName + "=" + valueToFilter + "&";

                        }
                        else if (columnName.Equals(columnsValues[9]))
                        {
                            URL += "" + columnName + "=" + valueToFilter + "&";

                        }
                        else if (columnName.Equals(columnsValues[10]))
                        {
                            URL += "" + columnName + "=" + valueToFilter + "&";

                        }
                        else if (columnName.Equals(columnsValues[11]))
                        {
                            URL += "" + columnName + "=" + valueToFilter + "&";

                        }
                        else if (columnName.Equals(columnsValues[12]))
                        {
                            URL += "" + columnName + "=" + valueToFilter + "&";

                        }
                        else if (columnName.Equals(columnsValues[13]))
                        {
                            URL += "" + columnName + "=" + valueToFilter + "&";

                        }
                        else if (columnName.Equals(columnsValues[14]))
                        {
                            URL += "" + columnName + "=" + valueToFilter + "&";

                        }
                        else if (columnName.Equals(columnsValues[15]))
                        {
                            URL += "" + columnName + "=" + valueToFilter + "&";

                        }

                    }




                }





                ViewGrid();

                // dtGrid.Refresh();
                //dtGrid.Update();
            }
        }




        /// <summary>
        /// This method allows creating a new filter according to the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCreateNewFilter_Click(object sender, EventArgs e)
        {


            Label lbFilterBy = new Label();
            cbFilterBy = new ComboBox();


            Label lbValueToFilter = new Label();

            TextBox txValueToFilter = new TextBox();

            Button btAdd = new Button();
            Button btClear = new Button();


            createControlsyToFilter(lbFilterBy, cbFilterBy, lbValueToFilter, txValueToFilter, btAdd, btClear);
            elements.Add(new Element(lbFilterBy, cbFilterBy, lbValueToFilter, txValueToFilter, btAdd, btClear));


            this.fLP.Controls.Add(elements[count_click].Label1);
            this.fLP.Controls.Add(elements[count_click].ComboBox);
            this.fLP.Controls.Add(elements[count_click].Label2);
            this.fLP.Controls.Add(elements[count_click].TextBox);
            this.fLP.Controls.Add(elements[count_click].ButtonAdd);
            this.fLP.Controls.Add(elements[count_click].ButtonClear);

            count_click++;


        }






        /// <summary>
        /// This method allows you to create the controllers responsible for filtering.
        /// </summary>
        private void createControlsyToFilter(Label lbFilterBy, ComboBox cbFilterBy, Label lbValueToFilter, TextBox txValueToFilter, Button btAdd, Button btClear)
        {

            // 
            // lbFilterBy
            // 
            lbFilterBy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            lbFilterBy.AutoSize = true;
            lbFilterBy.Location = new System.Drawing.Point(3, 0);
            lbFilterBy.Size = new System.Drawing.Size(53, 29);
            lbFilterBy.TabIndex = 6;
            lbFilterBy.Text = "Filtrar por:";
            lbFilterBy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lbFilterBy.Name = "lbFilterBy" + count_click.ToString();


            // 
            // cbFilterBy
            // 
            cbFilterBy.FormattingEnabled = true;
            cbFilterBy.Location = new System.Drawing.Point(62, 3);
            cbFilterBy.Size = new System.Drawing.Size(100, 21);
            cbFilterBy.TabIndex = 5;
            cbFilterBy.Name = "cbFilter" + count_click.ToString();
            //------------------------------------------------------------
            cbFilterBy.Items.AddRange(columnsValues);
            // 
            // lbvalueToFilter
            // 
            lbValueToFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            lbValueToFilter.AutoSize = true;
            lbValueToFilter.Location = new System.Drawing.Point(168, 0);
            lbValueToFilter.RightToLeft = System.Windows.Forms.RightToLeft.No;
            lbValueToFilter.Size = new System.Drawing.Size(71, 29);
            lbValueToFilter.TabIndex = 7;
            lbValueToFilter.Text = "Valor a filtrar :";
            lbValueToFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            txValueToFilter.Name = "tbValueToFilter" + count_click.ToString();


            // 
            // valueToFilter
            // 
            txValueToFilter.Location = new System.Drawing.Point(245, 3);
            txValueToFilter.Size = new System.Drawing.Size(100, 20);
            txValueToFilter.TabIndex = 1;
            txValueToFilter.Name = "txValueToFilter" + count_click.ToString();


            // 
            // btAdd
            // 
            btAdd.Location = new System.Drawing.Point(351, 3);
            btAdd.Size = new System.Drawing.Size(75, 23);
            btAdd.TabIndex = 8;
            btAdd.Text = "Agregar" + count_click.ToString();
            btAdd.UseVisualStyleBackColor = true;
            btAdd.UseVisualStyleBackColor = true;
            btAdd.Name = "btAdd" + count_click.ToString();
            btAdd.Click += new EventHandler(HandlerButtonAddAndClear);

            // 
            // btClear
            // 
            btClear.Location = new System.Drawing.Point(432, 3);
            btClear.Size = new System.Drawing.Size(21, 23);
            btClear.TabIndex = 9;
            btClear.Text = "X";
            btClear.UseVisualStyleBackColor = true;
            btClear.Name = "btClear" + count_click.ToString();
            btClear.Click += new EventHandler(HandlerButtonAddAndClear);






        }





        public void HandlerButtonAddAndClear(object sender, EventArgs e)
        {
            int i = 0;
            bool found = false;
            if (elements != null)
            {
                while (i < count_click && !found)
                {
                    for (int j = 0; j < elements.Count(); j++)
                    {
                        if (((Button)sender).Name == "btClear" + i.ToString())
                        {
                            if (elements[j].ButtonAdd.Name == "btAdd" + i.ToString())
                            {
                                ClearValuesToURL(elements[j].ComboBox.Text, elements[j].TextBox.Text);
                                fLP.Controls.Remove(elements[j].Label1);
                                fLP.Controls.Remove(elements[j].ComboBox);
                                fLP.Controls.Remove(elements[j].Label2);
                                fLP.Controls.Remove(elements[j].TextBox);
                                fLP.Controls.Remove(elements[j].ButtonAdd);
                                fLP.Controls.Remove(elements[j].ButtonClear);
                                elements.Remove(elements[j]);
                                MessageBox.Show("Lo borre");
                                found = true;
                                count_click--;
                                MessageBox.Show("Se presiono el boton" + i.ToString());
                            }
                        }


                        if (((Button)sender).Name == "btAdd" + i.ToString())
                        {
                            elements[j].ComboBox.Enabled = false;
                            found = true;
                        }

                        fLP.Update();
                    }






                    i++;
                }
            }


        }


        /// <summary>
        /// Este metodo permite añadirle colores a los marcadores y poligonos de acuerdo al nivel de contaminación que presentan.
        /// </summary>
        /// <param name="lst"></param> Lista con los elementos que se encuentran en la base de datos.
        private void pollutionColor(List<ViewModel> lst)
        {

        }





        /// <summary>
        /// Permite eliminar la consulta que el usuario realizo.
        /// </summary>
        /// <param name="columnName"></param> Nombre de la columna para eliminar la consulta.
        /// <param name="valueToFilter"></param> Atributo de la columna columnName el cual se va a eliminar
        private void ClearValuesToURL(string columnName, String valueToFilter)
        {

            String valueToClean = "&" + columnName + "=" + valueToFilter;
            //Borra un caracter o una cadena de caracter en el URL.
            string cadena = URL.Replace(valueToClean, "");
            URL = cadena;
            ViewGrid();

        }

        /// <summary>
        /// Permite cargar el mapa de google en pantalla y posicionarlo en el país de Colombia,Bogota. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gMapC_Load(object sender, EventArgs e)
        {
            //Elementos de inicio Gmap
            gMapC.DragButton = MouseButtons.Left;
            gMapC.CanDragMap = true;
            gMapC.MapProvider = GMap.NET.MapProviders.OpenCycleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMapC.Position = new GMap.NET.PointLatLng(4.570868, -74.2973328);
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMapC.MinZoom = 0;
            gMapC.MaxZoom = 20;
            gMapC.Zoom = 6;
            //Fin
        }


        /// <summary>
        /// Permite agregar un marcador en coordenadas especificas en el mapa de google que se muestra en pantalla. Del mismo modo,
        /// permite agregar un cuadrado en las mismas coordenadas que representa el nivel de contaminación de la zona.
        /// </summary>
        /// <param name="lst"></param> Representa la información que esta almacenada en la base de datos.
        /// <param name="polygonColor"></param> Representa el color que rellena el poligono, de esta forma representar el nivel de contaminación de la zona.
        /// <param name="markerColor"></param> Representa el color del marcador, el cual representa el nivel de contaminación de la zona.
        private void AddMarker(List<ViewModel> lst, Color polygonColor, GMarkerGoogleType markerColor)
        {
            foreach (var value in lst)
            {

                var markerOverlay = new GMapOverlay("markers");
                var marker = new GMarkerGoogle(new PointLatLng(value.Latitud, value.Longitud), markerColor); ;
                markerOverlay.Markers.Add(marker);
                

                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                marker.ToolTipText = String.Format("Fecha: " + value.Fecha + "\n"
                   + "Autoridad Ambiental: " + value.Autoridad_ambiental + "\n"
                   + "Nombre de la estación: " + value.Nombre_de_la_estaci_n + "\n"
                   + "Tecnologia: " + value.Tecnolog_a + "\n"
                   + "Latitud: " + value.Latitud + "\n"
                   + "Longitud: " + value.Longitud + "\n"
                   + "Codigo del departamento: " + value.C_digo_del_departamento + "\n"
                   + "Departamento: " + value.Departamento + "\n"
                   + "Codigo de municipio: " + value.C_digo_del_municipio + "\n"
                   + "Municipio: " + value.Nombre_del_municipio + "\n"
                   + "Tipo de estación: " + value.Tipo_de_estaci_n + "\n"
                   + "Tiempo de exposición: " + value.Tiempo_de_exposici_n + "\n"
                   + "Variable: " + value.Variable + "\n"
                   + "Unidades: " + value.Unidades + "\n"
                   + "Concentración: " + value.Concentraci_n
                    );

                // Añade una poligono como representación al nivel de contaminación.
                AddPolygon(value, polygonColor);

                gMapC.Overlays.Add(markerOverlay);




            }

        }

        /// <summary>
        /// Este metodo permite crear un poligono alrededor de las coordenadas donde se realizo la prueba y de 
        /// esta manera generar un cuadrado como representación de el nivel de contaminación en esta zona.
        /// </summary>
        /// <param name="value"></param> Representa a un elemnento de la base de datos
        /// <param name="polygonColor"></param> Representa el color que rellena el poligono, de esta forma representar el nivel de contaminación de la zona.
        private void AddPolygon(ViewModel value, Color polygonColor)
        {
            GMapOverlay polygons = new GMapOverlay("Polygons");
            List<PointLatLng> points = new List<PointLatLng>();
            // Crea un cuadrado a partir de coordenas especificas.
            PointAdd(value.Latitud, value.Longitud, points);
            GMapPolygon polygon = new GMapPolygon(points, value.Nombre_del_municipio);
            polygon.Stroke = new Pen(Color.Transparent, 10);
            polygon.Fill = new SolidBrush(Color.FromArgb(50, polygonColor));
            polygons.Polygons.Add(polygon);
            gMapC.Overlays.Add(polygons);
            points.Clear();
        }





        /// <summary>
        /// Metodo auxiliar del metodo AddPolygon,este metodo permite crear un cuadrado, a partir de coordenadas alrededor de un punto en especifico.
        /// </summary>
        /// <param name="x"></param> Coordenada de latitud del punto medio.
        /// <param name="y"></param> Coordenada de Longitud del punto medio.
        /// <param name="points"></param> Lista de coordenadas que posteriormente se llenaran para realizar el poligono.
        private void PointAdd(double x, double y, List<PointLatLng> points)
        {
            double d = 0.009;
            points.Add(new PointLatLng(x + d, y));
            points.Add(new PointLatLng(x, y + d));
            points.Add(new PointLatLng(x - d, y));
            points.Add(new PointLatLng(x, y - d));

        }




        private void DistanceTwoPoint(double x, double y, List<PointLatLng> points)
        {

            double d = 0.5;
            double x1 = x;
            double y1 = y;
            double x2 = x;
            double y2 = y;

            // Verificar parte superior.
            while (Distance(x1, y1, x2, y2) != d)
            {
                y2 += d;


            }

            points.Add(new PointLatLng(x2, y2));
            y2 = y;

            // Verificar parte  derecha.
            while (Distance(x1, y1, x2, y2) != d)
            {
                x2 += d;
            }

            points.Add(new PointLatLng(x2, y2));

            x2 = x;


            // Verificar parte inferior.
            while (Distance(x1, y1, x2, y2) != d)
            {
                y2 -= d;
            }
            points.Add(new PointLatLng(x2, y2));
            y2 = y;

            // Verificar parte  izquierda.
            while (Distance(x1, y1, x2, y2) != d)
            {
                x2 -= d;
            }

            points.Add(new PointLatLng(x2, y2));

        }


        private double Distance(double x1, double y1, double x2, double y2)
        {

            double first = Math.Pow((x2 - x1), 2);
            double second = Math.Pow((y2 - y1), 2);
            double result = first + second;
            double distance = Math.Sqrt(result);

            return distance;
        }


        class Dpto
        {
            private String departamento;
            public string Departamento { get => departamento; set => departamento = value; }
        }

        class Municipio
        {
            private String municipio;
            public string nombre_del_municipio { get => municipio; set => municipio = value; }
        }

        /*
         * lista de todos los municipios de todos los dptos
         */
        private List<ViewModel> municipios_list = new List<ViewModel>();

        public async void todos_los_municipios()
        {
            //consulto cuales son todos los dptos
            String url = "https://www.datos.gov.co/resource/ysq6-ri4e.json?$select=departamento&$group=departamento";

            string respuesta = await GetHttp(url);
            List<Dpto> dptos = JsonConvert.DeserializeObject<List<Dpto>>(respuesta);

            //para cada dpto encontrado voy a buscar sus municipios
            foreach (Dpto element in dptos)
            {
                //Console.WriteLine(element.Departamento);

                url = "https://www.datos.gov.co/resource/ysq6-ri4e.json?departamento=" + element.Departamento + "&$select=Nombre_del_municipio&$group=Nombre_del_municipio";

                respuesta = await GetHttp(url);
                List<Municipio> muns = JsonConvert.DeserializeObject<List<Municipio>>(respuesta);

                //saco la informacion completa de cada municipio y lo agrego a la lista de todos los municipios
                foreach (Municipio municipio in muns)
                {
                    url = "https://www.datos.gov.co/resource/ysq6-ri4e.json?nombre_del_municipio=" + municipio.nombre_del_municipio + "&$limit=1";

                    respuesta = await GetHttp(url);
                    List<ViewModel> mun_complete = JsonConvert.DeserializeObject<List<ViewModel>>(respuesta);
                    municipios_list.Add(mun_complete.First());
                }
            }
            /*
             foreach (ViewModel element in municipios_list)
             {
                 Console.WriteLine(element.Nombre_del_municipio + ", " + element.Departamento);
             }
             */
        }

        private void btSatelite_Click(object sender, EventArgs e)
        {
            gMapC.MapProvider = GMapProviders.GoogleChinaSatelliteMap;
        }

        private void btOriginal_Click(object sender, EventArgs e)
        {
            gMapC.MapProvider = GMapProviders.GoogleMap;

        }

        private void btRelief_Click(object sender, EventArgs e)
        {
            gMapC.MapProvider = GMapProviders.GoogleTerrainMap;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            trackBarZoom.Value = Convert.ToInt32(gMapC.Zoom);
        }

        private void trackBarZoom_Scroll(object sender, EventArgs e)
        {
            gMapC.Zoom = trackBarZoom.Value;
        }
    }

}

