using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Net;
using System.IO;

using GMap.NET;

using GMap.NET.MapProviders;

using GMap.NET.WindowsForms;

using GMap.NET.WindowsForms.Markers;

using GMap.NET.WindowsForms.ToolTips;


namespace openstreet_laba
{
    public partial class Form1 : Form
    {
        CityClass city1;
        CityClass city2;
        CityClass cityDistrict;
        List<string> buildingTypes = new List<string>()
        {
            "школа",
            "пожарная часть",
            "социальный объект",
            "объект здравоохранения",
            "общепит",
            "административный объект",
            "дом культуры",
            "центр творчества",
            "почта",
            "детский сад",
            "банк",
            "кпп",
            "автомойка",
            "аптека",
            "дополнительное образование",
            "ночной клуб",
            "азс",
            "образовательное учреждение",
            "общежитие",
            "рынок",
            "парковка",
            "общественное учреждение",
            "туалет",
            "автовокзал",
            "кинотеатр",
            "театр",
            "шиномонтаж",
            "полиция",
            "библиотека",
            "детский центр",
            "мчс",
            "концертный зал",
            "планетарий",
            "храм",
            "возможно жилое",
            "жилое",
            "другое"
        };
        public Form1()
        {
            InitializeComponent();

            cb_showOnMap.Items.Clear();
            for (int i = 0; i < buildingTypes.Count - 3; i++)
                cb_showOnMap.Items.Add(buildingTypes[i]);
            cb_showOnMap.SelectedIndex = 0;
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            // Настройки для компонента GMap
            gmap.Bearing = 0;

            // Перетаскивание правой кнопки мыши
            gmap.CanDragMap = true;

            // Перетаскивание карты левой кнопкой мыши
            gmap.DragButton = MouseButtons.Left;

            gmap.GrayScaleMode = true;

            // Все маркеры будут показаны
            gmap.MarkersEnabled = true;

            // Максимальное приближение
            gmap.MaxZoom = 17;

            // Минимальное приближение
            gmap.MinZoom = 2;

            // Курсор мыши в центр карты
            gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;

            // Отключение нигативного режима
            gmap.NegativeMode = false;

            // Разрешение полигонов
            gmap.PolygonsEnabled = true;

            // Разрешение маршрутов
            gmap.RoutesEnabled = true;

            // Скрытие внешней сетки карты
            gmap.ShowTileGridLines = false;

            // При загрузке 10-кратное увеличение
            gmap.Zoom = 10;

            // Изменение размеров
            // gmap.Dock = DockStyle.Fill;

            // Чья карта используется
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gmap.MapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;

            gmap.SetPositionByKeywords("Пермь");

            // Создаём новый список маркеров для городов
            GMapOverlay markersOverlay = new GMapOverlay("markers");
            gmap.Overlays.Add(markersOverlay);
            //новый список маркеров для заведений (лаба 2)
            GMapOverlay markersOverlay2 = new GMapOverlay("markersDistrict");
            gmap.Overlays.Add(markersOverlay2);
        }

        private void gmap_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private string TypeToRus(string tp)
        {
            if (tp == "school")
                return buildingTypes[0];

            if (tp == "fire_station")
                return buildingTypes[1];

            if (tp == "social_facility")
                return buildingTypes[2];

            if (tp == "clinic" || tp == "doctors" || tp == "hospital")
                return buildingTypes[3];

            if (tp == "cafe" || tp == "restaurant" || tp == "food_court" || tp == "fast_food" || tp == "bar")
                return buildingTypes[4];

            if (tp == "townhall" || tp == "courthouse")
                return buildingTypes[5];

            if (tp == "community_centre")
                return buildingTypes[6];

            if (tp == "arts_centre")
                return buildingTypes[7];

            if (tp == "post_office")
                return buildingTypes[8];

            if (tp == "kindergarten")
                return buildingTypes[9];

            if (tp == "bank")
                return buildingTypes[10];

            if (tp == "checkpoint")
                return buildingTypes[11];

            if (tp == "car_wash")
                return buildingTypes[12];

            if (tp == "pharmacy")
                return buildingTypes[13];

            if (tp == "training" || tp == "music_school")
                return buildingTypes[14];

            if (tp == "nightclub")
                return buildingTypes[15];

            if (tp == "fuel")
                return buildingTypes[16];

            if (tp == "college" || tp == "university")
                return buildingTypes[17];

            if (tp == "dormitory")
                return buildingTypes[18];

            if (tp == "marketplace")
                return buildingTypes[19];

            if (tp == "parking")
                return buildingTypes[20];

            if (tp == "public_building")
                return buildingTypes[21];

            if (tp == "toilets")
                return buildingTypes[22];

            if (tp == "bus_station")
                return buildingTypes[23];

            if (tp == "cinema")
                return buildingTypes[24];

            if (tp == "theatre")
                return buildingTypes[25];

            if (tp == "vehicle_inspection")
                return buildingTypes[26];

            if (tp == "police")
                return buildingTypes[27];

            if (tp == "library")
                return buildingTypes[28];

            if (tp == "childcare")
                return buildingTypes[29];

            if (tp == "rescue_station")
                return buildingTypes[30];

            if (tp == "concert_hall")
                return buildingTypes[31];

            if (tp == "planetarium")
                return buildingTypes[32];

            if (tp == "place_of_worship")
                return buildingTypes[33];

            if (tp == "yes")
                return buildingTypes[34];

            if (tp == "house" || tp == "apartments" || tp == "bungalow" || tp == "detached" || tp == "residential")
                return buildingTypes[35];

            return buildingTypes[36];// +"(" + tp + ")";
        }

        private int GetPopulationByRelation(string rel)
        {
            try
            {
                string url = "http://overpass-api.de/api/interpreter?data=[out:xml];relation(" + rel + ");out;";
                WebRequest wrGETURL;
                wrGETURL = WebRequest.Create(url);
                Stream objStream;
                objStream = wrGETURL.GetResponse().GetResponseStream();
                XmlReader xmlReader = XmlReader.Create(objStream);
                int pop = 0;
                while (xmlReader.Read())
                {
                    if (xmlReader.Name == "tag" && xmlReader.HasAttributes)
                    {
                        if (xmlReader.GetAttribute("k") == "population")
                        {
                            try
                            {
                                pop = int.Parse(xmlReader.GetAttribute("v"));
                                return pop;
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show("Ошибка при обработке результатов запроса населения. Текст: \n\n" + e.Message);
                                return 0; 
                            }
                        }
                    }
                }
                return pop;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка при запросе населения. Текст ошибки: \n\n" + e.Message);
                return 0;
            }
        }

        private void FillTable()
        {
            //если население не запросилось, надо посчитать
            if (city1 != null)
            {
                if (city1.Population <= 0)
                {
                    MessageBox.Show("Не удалось получить население из OSM. Население будет рассчитано в зависимости от этажности жилых зданий.");
                    city1.Population = CountPopulation(city1);
                }
            }
            if (city2 != null)
            {
                if (city2.Population <= 0)
                {
                    MessageBox.Show("Не удалось получить население из OSM. Население будет рассчитано в зависимости от этажности жилых зданий.");
                    city2.Population = CountPopulation(city2);
                }
            }
            
            dataGridView1.DataSource = null;
            DataTable dt = new DataTable();
            dt.Columns.Add("Тип");
            dt.Columns.Add(city1 != null ? city1.Name : "Город 1");
            dt.Columns.Add(city2 != null ? city2.Name : "Город 2");
            dt.Rows.Add("Население",
                city1 != null ? city1.Population : 0,
                city2 != null ? city2.Population : 0
                );
            for (int i = 0; i < buildingTypes.Count; i++)
            {
                if (i != 34 && i != 35)
                {
                    dt.Rows.Add(buildingTypes[i],
                    city1 != null ? city1.Buildings.Count(x => x.Type == buildingTypes[i]) : 0,
                    city2 != null ? city2.Buildings.Count(x => x.Type == buildingTypes[i]) : 0
                    );
                }
                else
                {
                    dt.Rows.Add(buildingTypes[i] + " 0-5 этажей",
                    city1 != null ? city1.Buildings.Count(x => x.Type == buildingTypes[i] && x.Levels >= 0 && x.Levels <= 5) : 0,
                    city2 != null ? city2.Buildings.Count(x => x.Type == buildingTypes[i] && x.Levels >= 0 && x.Levels <= 5) : 0
                    );
                    dt.Rows.Add(buildingTypes[i] + " 6-20 этажей",
                    city1 != null ? city1.Buildings.Count(x => x.Type == buildingTypes[i] && x.Levels >= 6 && x.Levels <= 20) : 0,
                    city2 != null ? city2.Buildings.Count(x => x.Type == buildingTypes[i] && x.Levels >= 6 && x.Levels <= 20) : 0
                    );
                    dt.Rows.Add(buildingTypes[i] + " >20 этажей",
                    city1 != null ? city1.Buildings.Count(x => x.Type == buildingTypes[i] && x.Levels >= 21) : 0,
                    city2 != null ? city2.Buildings.Count(x => x.Type == buildingTypes[i] && x.Levels >= 21) : 0
                    );
                }
            }
                
            dataGridView1.DataSource = dt;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (GetCityInfo(0))
                FillTable();
        }

        private void b_city2_Click(object sender, EventArgs e)
        {
            if (GetCityInfo(1))
                FillTable();
        }

        private bool GetCityInfo(int mode)
        {
            try
            {
                string cityRelation = "";
                if (mode == 0)
                    cityRelation = GMap.NET.MapProviders.OpenStreetMapProvider.Instance.GetRelationByCityName(tb_city1.Text);
                else if (mode == 1)
                    cityRelation = GMap.NET.MapProviders.OpenStreetMapProvider.Instance.GetRelationByCityName(tb_city2.Text);
                else if (mode == 3)
                    cityRelation = GMap.NET.MapProviders.OpenStreetMapProvider.Instance.GetRelationByCityName(tb_district.Text);
                WebRequest wrGETURL;
                string sURL = "http://overpass-api.de/api/interpreter?data=[maxsize:1073741824][out:xml];";
                sURL += "area(" + "360" + cityRelation;
                sURL += ")->.a;out body qt;";
                sURL += "(relation(area.a)[\"building\"~\"dormitory|apartments|bungalow|detached|house|residential|yes\"];";
                sURL += "way(area.a)[\"building\"~\"dormitory|apartments|bungalow|detached|house|residential|yes\"];";
                sURL += "node(area.a)[\"building\"~\"dormitory|apartments|bungalow|detached|house|residential|yes\"];)";
                sURL += ";out body qt;>;out skel qt;";
                wrGETURL = WebRequest.Create(sURL);
                Stream objStream;
                objStream = wrGETURL.GetResponse().GetResponseStream();

                if (mode == 0)
                    city1 = new CityClass(tb_city1.Text);
                else if (mode == 1)
                    city2 = new CityClass(tb_city2.Text);
                else if (mode == 3)
                    cityDistrict = new CityClass(tb_district.Text);

                List<CityBuilding> buildList = new List<CityBuilding>();

                XmlReader xmlReader = XmlReader.Create(objStream);
                while (xmlReader.Read())
                {
                    if ((xmlReader.NodeType == XmlNodeType.Element) && ((xmlReader.Name == "node") || (xmlReader.Name == "way")))
                    {
                        CityBuilding cb = new CityBuilding();
                        //координаты и id здания
                        cb.IdStr = xmlReader.GetAttribute("id");
                        if (xmlReader.Name == "node")
                        {
                            cb.LatStr = xmlReader.GetAttribute("lat");
                            cb.LonStr = xmlReader.GetAttribute("lon");
                            int cbInd = buildList.FindIndex(x => x.NdId == cb.IdStr);
                            if (cbInd != -1)
                            {
                                buildList[cbInd].LatStr = cb.LatStr;
                                buildList[cbInd].LonStr = cb.LonStr;
                            }
                        }
                        while (xmlReader.NodeType != XmlNodeType.EndElement && ((xmlReader.Name != "node") || (xmlReader.Name != "way")))
                        {
                            xmlReader.Read();
                            if (xmlReader.NodeType == XmlNodeType.Element && (xmlReader.Name == "node"))
                                break;
                            //if (cb.NdId == "" && xmlReader.Name == "nd" && xmlReader.HasAttributes)
                            if (xmlReader.Name == "nd" && xmlReader.HasAttributes)
                            {
                                cb.NdId = xmlReader.GetAttribute("ref");
                            }
                            if (xmlReader.Name == "tag" && xmlReader.HasAttributes)
                            {
                                if (xmlReader.GetAttribute("k") == "amenity")
                                    cb.Type = TypeToRus(xmlReader.GetAttribute("v"));

                                if (xmlReader.GetAttribute("k") == "building" && cb.Type == "unknow")
                                    cb.Type = TypeToRus(xmlReader.GetAttribute("v"));

                                if (xmlReader.GetAttribute("k") == "name")
                                    cb.Name = xmlReader.GetAttribute("v");

                                if (xmlReader.GetAttribute("k") == "building:levels")
                                {
                                    try { cb.Levels = int.Parse(xmlReader.GetAttribute("v")); }
                                    catch { cb.Levels = 0; }
                                }


                                if (xmlReader.GetAttribute("k") == "description")
                                    cb.Description = xmlReader.GetAttribute("v");

                            }
                        }
                        if (cb.Type != "unknow")
                            /*if (mode == 0)
                                city1.Buildings.Add(cb);
                            else if (mode == 1)
                                city2.Buildings.Add(cb);
                            else if (mode == 3)
                                cityDistrict.Buildings.Add(cb);*/
                            buildList.Add(cb);
                    }
                }

                if (mode == 0)
                    city1.Buildings = buildList;
                else if (mode == 1)
                    city2.Buildings = buildList;
                else if (mode == 3)
                    cityDistrict.Buildings = buildList;

                if (mode == 0)
                    city1.Population = GetPopulationByRelation(cityRelation);
                else if (mode == 1)
                    city2.Population = GetPopulationByRelation(cityRelation);
                else if (mode == 3)
                    cityDistrict.Population = GetPopulationByRelation(cityRelation);

                /*if (mode != 3)
                    FillTable();
                else
                    FillTableDistrict();*/


                PointLatLng pointt = new PointLatLng();
                if (mode == 0)
                    pointt = gmap.SetPositionByKeywords(tb_city1.Text).Value;
                else if (mode == 1)
                    pointt = gmap.SetPositionByKeywords(tb_city2.Text).Value;
                else if (mode == 3)
                    pointt = gmap.SetPositionByKeywords(tb_district.Text).Value;
                if (mode != 3)
                {
                    GMarkerGoogle marker1 = new GMarkerGoogle(pointt, GMarkerGoogleType.red);
                    GMarkerGoogle marker2 = new GMarkerGoogle(pointt, GMarkerGoogleType.blue);

                    marker1.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(marker1);
                    marker2.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(marker2);
                    marker1.Tag = "red";
                    marker2.Tag = "blue";
                    marker1.ToolTipText = tb_city1.Text;
                    marker2.ToolTipText = tb_city2.Text;

                    // Добавляем маркер в список маркеров
                    if (mode == 0)
                    {
                        if (gmap.Overlays[0].Markers.Any(x => x.Tag == "red"))
                            gmap.Overlays[0].Markers.RemoveAt(gmap.Overlays[0].Markers.IndexOf(gmap.Overlays[0].Markers.First(x => x.Tag == "red")));
                    }
                    else if (mode == 1)
                    {
                        if (gmap.Overlays[0].Markers.Any(x => x.Tag == "blue"))
                            gmap.Overlays[0].Markers.RemoveAt(gmap.Overlays[0].Markers.IndexOf(gmap.Overlays[0].Markers.First(x => x.Tag == "blue")));
                    }

                    if (mode == 0)
                        gmap.Overlays[0].Markers.Add(marker1);
                    else if (mode == 1)
                        gmap.Overlays[0].Markers.Add(marker2);
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка. Текст ошибки: \n\n" + e.Message);
                return false;
            }
        }

        private void b_district_Click(object sender, EventArgs e)
        {
            if (GetCityInfo(3))
                FillTableDistrict();
        }

        private void FillTableDistrict()
        {
            //если население не запросилось, надо посчитать
            if (cityDistrict.Population <= 0)
            {
                MessageBox.Show("Не удалось получить население из OSM. Население будет рассчитано в зависимости от этажности жилых зданий.");
                cityDistrict.Population = CountPopulation(cityDistrict);
            }
            dataGridView2.DataSource = null;
            DataTable dt = new DataTable();
            dt.Columns.Add(" ");
            dt.Columns.Add(cityDistrict != null ? cityDistrict.Name : " ");
            //dt.Columns.Add("Плотность покрытия");
            dt.Rows.Add("Население",
                cityDistrict != null ? cityDistrict.Population : 0
                );
            for (int i = 0; i < buildingTypes.Count; i++)
            {
                if (i != 34 && i != 35)
                {
                    dt.Rows.Add(buildingTypes[i],
                    cityDistrict != null ? cityDistrict.Buildings.Count(x => x.Type == buildingTypes[i]) : 0
                    );
                }
                else
                {
                    dt.Rows.Add(buildingTypes[i] + " 0-5 этажей",
                    cityDistrict != null ? cityDistrict.Buildings.Count(x => x.Type == buildingTypes[i] && x.Levels >= 0 && x.Levels <= 5) : 0
                    );
                    dt.Rows.Add(buildingTypes[i] + " 6-20 этажей",
                    cityDistrict != null ? cityDistrict.Buildings.Count(x => x.Type == buildingTypes[i] && x.Levels >= 6 && x.Levels <= 20) : 0
                    );
                    dt.Rows.Add(buildingTypes[i] + " >20 этажей",
                    cityDistrict != null ? cityDistrict.Buildings.Count(x => x.Type == buildingTypes[i] && x.Levels >= 21) : 0
                    );
                }
            }

            dataGridView2.DataSource = dt;
            for (int i = 0; i < dataGridView2.Columns.Count; i++)
                dataGridView2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private int CountPopulation(CityClass city)
        {
            int pop = 0;
            Random rnd = new Random();
            for (int i = 0; i < city.Buildings.Count; i++)
            {
                if (city.Buildings[i].Type == buildingTypes[34] || city.Buildings[i].Type == buildingTypes[35])
                {
                    if (city.Buildings[i].Levels == 1)
                    {
                        pop += 3;
                    }
                    else if (city.Buildings[i].Levels == 2)
                    {
                        if (city.Buildings[i].Type == buildingTypes[35])
                            pop += 48;
                        else
                            pop += 5;
                    }
                    else if (city.Buildings[i].Levels == 3)
                    {
                        pop += 56;
                    }
                    //else if (city.Buildings[i].Levels > 3 && city.Buildings[i].Levels <= 5)
                    else if (city.Buildings[i].Levels == 5)
                    {
                        pop += 200;
                    }
                    //else if (city.Buildings[i].Levels > 5 && city.Buildings[i].Levels <= 9)
                    else if (city.Buildings[i].Levels == 9)
                    {
                        pop += 600;
                    }
                    //else if (city.Buildings[i].Levels > 9 && city.Buildings[i].Levels <= 16)
                    else if (city.Buildings[i].Levels == 16)
                    {
                        pop += 336;
                    }
                    //else if (city.Buildings[i].Levels > 16 && city.Buildings[i].Levels <= 25)
                    else if (city.Buildings[i].Levels == 25)
                    {
                        pop += 500;
                    }
                    /*else if (city.Buildings[i].Levels > 25)
                    {
                        pop += 500 + ((city.Buildings[i].Levels - 25) * 4 * 4);
                    }*/
                    else
                    {
                        /*int ranVal = rnd.Next(1, 100);
                        pop += ranVal;*/
                        pop += 1;
                    }
                }
            }
            return pop;
        }

        private void b_showOnMap_Click(object sender, EventArgs e)
        {
            string typeToShow = (string)cb_showOnMap.SelectedItem;

            gmap.Overlays[1].Markers.Clear();

            for (int i = 0; i < cityDistrict.Buildings.Count; i++)
            {
                if (cityDistrict.Buildings[i].Type == typeToShow)
                {
                    GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(cityDistrict.Buildings[i].Lat, cityDistrict.Buildings[i].Lon), GMarkerGoogleType.green);
                    if (cityDistrict.Buildings[i].Lat != 0 && cityDistrict.Buildings[i].Lon != 0)
                    {
                        marker.Tag = "green";
                        marker.ToolTipText = cityDistrict.Buildings[i].Name + "\n\n" + cityDistrict.Buildings[i].Description;
                        gmap.Overlays[1].Markers.Add(marker);
                    }
                }
            }

            if (gmap.Overlays[1].Markers.Count == 0)
                MessageBox.Show("Не удалось получить координаты ни одного из выбранных объектов.");
        }
    }
}
