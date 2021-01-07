using System;
using System.Collections.Generic;
using System.Text;
using DO;

namespace DS
{
    public static class DataSource
    {
        public static List<Station> listStations; //list of stations
        public static List<Bus> listBuses; //list of buses
        public static List<Line> listLines; //list of lines
        public static List<LineStation> listLineStations; //list of lines stations
        public static List<AdjacentStations> listAdjacentStations; //list of adjacent stations
        public static List<LineTrip> listLineTrip; //list of lines trip
        static DataSource()
        {
            InitAllLists();
        }
        static void InitAllLists()
        {
            #region InitialStationsList

            listStations = new List<Station>
            {
                new Station
                {
                    Code = 73,
                    Name = "שדרות גולדה מאיר/המשורר אצ''ג",
                    Address = "רחוב:שדרות גולדה מאיר  עיר: ירושלים ",
                    Latitude = 31.825302,
                    Longitude = 35.188624
                },
                new Station
                {
                    Code = 76,
                    Name = "בית ספר צור באהר בנות/אלמדינה אלמונוורה",
                    Address = "רחוב:אל מדינה אל מונאוורה  עיר: ירושלים",
                    Latitude = 31.738425,
                    Longitude = 35.228765
                },
                new Station
                {
                    Code = 77,
                    Name = "בית ספר אבן רשד/אלמדינה אלמונוורה",
                    Address = "רחוב:אל מדינה אל מונאוורה  עיר: ירושלים ",
                    Latitude = 31.738676,
                    Longitude = 35.226704
                },
                new Station
                {
                    Code = 78,
                    Name = "שרי ישראל/יפו",
                    Address = "רחוב:שדרות שרי ישראל 15 עיר: ירושלים",
                    Latitude = 31.789128,
                    Longitude = 35.206146
                },
                new Station
                {
                    Code = 83,
                    Name = "בטן אלהווא/חוש אל מרג",
                    Address = "רחוב:בטן אל הווא  עיר: ירושלים",
                    Latitude = 31.766358,
                    Longitude = 35.240417
                },
                new Station
                {
                    Code = 84,
                    Name = "מלכי ישראל/הטורים",
                    Address = " רחוב:מלכי ישראל 77 עיר: ירושלים ",
                    Latitude = 31.790758,
                    Longitude = 35.209791
                },
                new Station
                {
                    Code = 85,
                    Name = "בית ספר לבנים/אלמדארס",
                    Address = "רחוב:אלמדארס  עיר: ירושלים",
                    Latitude = 31.768643,
                    Longitude = 35.238509
                },
                new Station
                {
                    Code = 86,
                    Name = "מגרש כדורגל/אלמדארס",
                    Address = "רחוב:אלמדארס  עיר: ירושלים",
                    Latitude = 31.769899,
                    Longitude = 35.23973
                },
                new Station
                {
                    Code = 88,
                    Name = "בית ספר לבנות/בטן אלהוא",
                    Address = " רחוב:בטן אל הווא  עיר: ירושלים",
                    Latitude = 31.767064,
                    Longitude = 35.238443
                },
                new Station
                {
                    Code = 89,
                    Name = "דרך בית לחם הישה/ואדי קדום",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים ",
                    Latitude = 31.765863,
                    Longitude = 35.247198
                },
                new Station
                {
                    Code = 90,
                    Name = "גולדה/הרטום",
                    Address = "רחוב:דרך בית לחם הישנה  עיר: ירושלים",
                    Latitude = 31.799804,
                    Longitude = 35.213021
                },
                new Station
                {
                    Code = 91,
                    Name = "דרך בית לחם הישה/ואדי קדום",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים ",
                    Latitude = 31.765717,
                    Longitude = 35.247102
                },
                new Station
                {
                    Code = 93,
                    Name = "חוש סלימה 1",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים",
                    Latitude = 31.767265,
                    Longitude = 35.246594
                },
                new Station
                {
                    Code = 94,
                    Name = "דרך בית לחם הישנה ב",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים",
                    Latitude = 31.767084,
                    Longitude = 35.246655
                },
                new Station
                {
                    Code = 95,
                    Name = "דרך בית לחם הישנה א",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים",
                    Latitude = 31.768759,
                    Longitude = 31.768759
                },
                new Station
                {
                    Code = 97,
                    Name = "שכונת בזבז 2",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים",
                    Latitude = 31.77002,
                    Longitude = 35.24348
                },
                new Station
                {
                    Code = 102,
                    Name = "גולדה/שלמה הלוי",
                    Address = " רחוב:שדרות גולדה מאיר  עיר: ירושלים",
                    Latitude = 31.8003,
                    Longitude = 35.208257
                },
                new Station
                {
                    Code = 103,
                    Name = "גולדה/הרטום",
                    Address = " רחוב:שדרות גולדה מאיר  עיר: ירושלים",
                    Latitude = 31.8,
                    Longitude = 35.214106
                },
                new Station
                {
                    Code = 105,
                    Name = "גבעת משה",
                    Address = " רחוב:גבעת משה 2 עיר: ירושלים",
                    Latitude = 31.797708,
                    Longitude = 35.217133
                },
                new Station
                {
                    Code = 106,
                    Name = "גבעת משה",
                    Address = " רחוב:גבעת משה 3 עיר: ירושלים",
                    Latitude = 31.797535,
                    Longitude = 35.217057
                },
                new Station
                {
                    Code = 108,
                    Name = "עזרת תורה/עלי הכהן",
                    Address = "  רחוב:עזרת תורה 25 עיר: ירושלים",
                    Latitude = 31.797535,
                    Longitude = 35.213728
                },
                new Station
                {
                    Code = 109,
                    Name = "עזרת תורה/דורש טוב",
                    Address = "  רחוב:עזרת תורה 21 עיר: ירושלים ",
                    Latitude = 31.796818,
                    Longitude = 35.212936
                },
                new Station
                {
                    Code = 110,
                    Name = "עזרת תורה/דורש טוב",
                    Address = " רחוב:עזרת תורה 12 עיר: ירושלים",
                    Latitude = 31.796129,
                    Longitude = 35.212698
                },
                new Station
                {
                    Code = 111,
                    Name = "יעקובזון/עזרת תורה",
                    Address = "  רחוב:יעקובזון 1 עיר: ירושלים",
                    Latitude = 31.794631,
                    Longitude = 35.21161
                },
                new Station
                {
                    Code = 112,
                    Name = "יעקובזון/עזרת תורה",
                    Address = " רחוב:יעקובזון  עיר: ירושלים",
                    Latitude = 31.79508,
                    Longitude = 35.211684
                },
                new Station
                {
                    Code = 113,
                    Name = "זית רענן/אוהל יהושע",
                    Address = "  רחוב:זית רענן 1 עיר: ירושלים",
                    Latitude = 31.796255,
                    Longitude = 35.211065
                },
                new Station
                {
                    Code = 115,
                    Name = "זית רענן/תורת חסד",
                    Address = " רחוב:זית רענן  עיר: ירושלים",
                    Latitude = 31.798423,
                    Longitude = 35.209575
                },
                new Station
                {
                    Code = 116,
                    Name = "זית רענן/תורת חסד",
                    Address = "  רחוב:הרב סורוצקין 48 עיר: ירושלים ",
                    Latitude = 31.798689,
                    Longitude = 35.208878
                },
                new Station
                {
                    Code = 117,
                    Name = "קרית הילד/סורוצקין",
                    Address = "  רחוב:הרב סורוצקין  עיר: ירושלים",
                    Latitude = 31.799165,
                    Longitude = 35.206918
                },
                new Station
                {
                    Code = 119,
                    Name = "סורוצקין/שנירר",
                    Address = "  רחוב:הרב סורוצקין 31 עיר: ירושלים",
                    Latitude = 31.797829,
                    Longitude = 35.205601
                },
                new Station
                {
                    Code = 1485,
                    Name = "שדרות נווה יעקוב/הרב פרדס ",
                    Address = "רחוב: שדרות נווה יעקוב  עיר:ירושלים ",
                    Latitude = 31.840063,
                    Longitude = 35.240062

                },
                new Station
                {
                    Code = 1486,
                    Name = "מרכז קהילתי /שדרות נווה יעקוב",
                    Address = "רחוב:שדרות נווה יעקוב ירושלים עיר:ירושלים ",
                    Latitude = 31.838481,
                    Longitude = 35.23972
                },


                new Station
                {
                    Code = 1487,
                    Name = " מסוף 700 /שדרות נווה יעקוב ",
                    Address = "חוב:שדרות נווה יעקב 7 עיר: ירושלים  ",
                    Latitude = 31.837748,
                    Longitude = 35.231598
                },
                new Station
                {
                    Code = 1488,
                    Name = " הרב פרדס/אסטורהב ",
                    Address = "רחוב:מעגלות הרב פרדס  עיר: ירושלים רציף  ",
                    Latitude = 31.840279,
                    Longitude = 35.246272
                },
                new Station
                {
                    Code = 1490,
                    Name = "הרב פרדס/צוקרמן ",
                    Address = "רחוב:מעגלות הרב פרדס 24 עיר: ירושלים   ",
                    Latitude = 31.843598,
                    Longitude = 35.243639
                },
                new Station
                {
                    Code = 1491,
                    Name = "ברזיל ",
                    Address = "רחוב:ברזיל 14 עיר: ירושלים",
                    Latitude = 31.766256,
                    Longitude = 35.173
                },
                new Station
                {
                    Code = 1492,
                    Name = "בית וגן/הרב שאג ",
                    Address = "רחוב:בית וגן 61 עיר: ירושלים ",
                    Latitude = 31.76736,
                    Longitude = 35.184771
                },
                new Station
                {
                    Code = 1493,
                    Name = "בית וגן/עוזיאל ",
                    Address = "רחוב:בית וגן 21 עיר: ירושלים    ",
                    Latitude = 31.770543,
                    Longitude = 35.183999
                },
                new Station
                {
                    Code = 1494,
                    Name = " קרית יובל/שמריהו לוין ",
                    Address = "רחוב:ארתור הנטקה  עיר: ירושלים    ",
                    Latitude = 31.768465,
                    Longitude = 35.178701
                },
                new Station
                {
                    Code = 1510,
                    Name = " קורצ'אק / רינגלבלום ",
                    Address = "רחוב:יאנוש קורצ'אק 7 עיר: ירושלים",
                    Latitude = 31.759534,
                    Longitude = 35.173688
                },
                new Station
                {
                    Code = 1511,
                    Name = " טהון/גולומב ",
                    Address = "רחוב:יעקב טהון  עיר: ירושלים     ",
                    Latitude = 31.761447,
                    Longitude = 35.175929
                },
                new Station
                {
                    Code = 1512,
                    Name = "הרב הרצוג/שח''ל ",
                    Address = "רחוב:הרב הרצוג  עיר: ירושלים רציף",
                    Latitude = 31.761447,
                    Longitude = 35.199936
                },
                new Station
                {
                    Code = 1514,
                    Name = "פרץ ברנשטיין/נזר דוד ",
                    Address = "רחוב:הרב הרצוג  עיר: ירושלים רציף",
                    Latitude = 31.759186,
                    Longitude = 35.189336
                },


             new Station
            {
            Code = 1518,
            Name = "פרץ ברנשטיין/נזר דוד",
            Address = " רחוב:פרץ ברנשטיין 56 עיר: ירושלים ",
            Latitude = 31.759121,
            Longitude = 35.189178
        },
              new Station
              {
            Code = 1522,
            Name = "מוזיאון ישראל/רופין",
            Address = "  רחוב:דרך רופין  עיר: ירושלים ",
            Latitude = 31.774484,
            Longitude = 35.204882
                },

             new Station
                  {
             Code = 1523,
            Name = "הרצוג/טשרניחובסקי",
            Address = "   רחוב:הרב הרצוג  עיר: ירושלים  ",
            Latitude = 31.769652,
            Longitude = 35.208248
                },
              new Station
                {
              Code = 1524,
            Name = "רופין/שד' הזז",
            Address = "    רחוב:הרב הרצוג  עיר: ירושלים   ",
               Latitude = 31.769652,
                 Longitude = 35.208248,
              },
                new Station
                {
                    Code = 121,
                    Name = "מרכז סולם/סורוצקין ",
                    Address = " רחוב:הרב סורוצקין 13 עיר: ירושלים",
                    Latitude = 31.796033,
                    Longitude =35.206094
                },
                new Station
                {
                    Code = 123,
                    Name = "אוהל דוד/סורוצקין ",
                    Address = "  רחוב:הרב סורוצקין 9 עיר: ירושלים",
                    Latitude = 31.794958,
                    Longitude =35.205216
                },
                new Station
                {
                    Code = 122,
                    Name = "מרכז סולם/סורוצקין ",
                    Address = "  רחוב:הרב סורוצקין 28 עיר: ירושלים",
                    Latitude = 31.79617,
                    Longitude =35.206158
                }
                
            };

            #endregion InitialStationsList
            #region InitialBusList

            listBuses = new List<Bus>
            {
                new Bus
                {
                    LicenseNum = 12343576,
                    FromDate = new DateTime(2018, 7, 8),
                    TotalTrip = 100000,
                    FuelRemain = 80.2,
                    Status = DOenums.BusStatus.זמין
                },
                new Bus
                {
                    LicenseNum = 87654567,
                    FromDate = new DateTime(2020, 10, 22),
                    TotalTrip = 10000,
                    FuelRemain = 50.3,
                    Status = DOenums.BusStatus.זמין
                },
                new Bus
                {
                    LicenseNum = 20090890,
                    FromDate = new DateTime(2015, 12, 1),
                    TotalTrip = 120000,
                    FuelRemain = 23.5,
                    Status = DOenums.BusStatus.זמין
                },
                new Bus
                {
                    LicenseNum = 98074231,
                    FromDate = new DateTime(2019, 11, 3),
                    TotalTrip = 15000,
                    FuelRemain = 45.9,
                    Status = DOenums.BusStatus.זמין
                },
                new Bus
                {
                    LicenseNum = 40506066,
                    FromDate = new DateTime(2010, 10, 16),
                    TotalTrip = 200540,
                    FuelRemain = 10,
                    Status = DOenums.BusStatus.בתדלוק
                },
                new Bus
                {
                    LicenseNum = 17846530,
                    FromDate = new DateTime(2013, 7, 27),
                    TotalTrip = 151234,
                    FuelRemain = 67,
                    Status = DOenums.BusStatus.זמין
                },
                new Bus
                {
                    LicenseNum = 87348787,
                    FromDate = new DateTime(2020, 4, 14),
                    TotalTrip = 4567,
                    FuelRemain = 22.6,
                    Status = DOenums.BusStatus.זמין
                },
                new Bus
                {
                    LicenseNum = 54546575,
                    FromDate = new DateTime(2018, 3, 14),
                    TotalTrip = 40980,
                    FuelRemain = 0,
                    Status = DOenums.BusStatus.בתדלוק
                },
                new Bus
                {
                    LicenseNum = 23453496,
                    FromDate = new DateTime(2019, 5, 17),
                    TotalTrip = 20003,
                    FuelRemain = 50,
                    Status = DOenums.BusStatus.בנסיעה
                },
                new Bus
                {
                    LicenseNum = 87687625,
                    FromDate = new DateTime(2016, 4, 19),
                    TotalTrip = 80450,
                    FuelRemain = 27.6,
                    Status = DOenums.BusStatus.זמין
                },
                new Bus
                {
                    LicenseNum = 43247698,
                    FromDate = new DateTime(1999, 12, 17),
                    TotalTrip = 300000,
                    FuelRemain = 0,
                    Status = DOenums.BusStatus.בטיפול
                },
                new Bus
                {
                    LicenseNum = 45457638,
                    FromDate = new DateTime(2019, 11, 18),
                    TotalTrip = 15330,
                    FuelRemain = 39.6,
                    Status = DOenums.BusStatus.זמין
                },
                new Bus
                {
                    LicenseNum = 98763650,
                    FromDate = new DateTime(2020, 9, 28),
                    TotalTrip = 2500,
                    FuelRemain = 17.8,
                    Status = DOenums.BusStatus.זמין
                },
                new Bus
                {
                    LicenseNum = 45382957,
                    FromDate = new DateTime(2020, 1, 12),
                    TotalTrip = 89045,
                    FuelRemain = 34.8,
                    Status = DOenums.BusStatus.זמין
                },
                new Bus
                {
                    LicenseNum = 90080098,
                    FromDate = new DateTime(2019, 8, 18),
                    TotalTrip = 54098,
                    FuelRemain = 43.9,
                    Status = DOenums.BusStatus.בטיפול
                },
                new Bus
                {
                    LicenseNum = 70006593,
                    FromDate = new DateTime(2018, 6, 26),
                    TotalTrip = 101089,
                    FuelRemain = 11.4,
                    Status = DOenums.BusStatus.זמין
                },
                new Bus
                {
                    LicenseNum = 24240746,
                    FromDate = new DateTime(2017, 10, 6),
                    TotalTrip = 109670,
                    FuelRemain = 28.7,
                    Status = DOenums.BusStatus.זמין
                },
                new Bus
                {
                    LicenseNum = 38602756,
                    FromDate = new DateTime(2019, 8, 19),
                    TotalTrip = 57892,
                    FuelRemain = 38.2,
                    Status = DOenums.BusStatus.זמין
                },
                new Bus
                {
                    LicenseNum = 78945665,
                    FromDate = new DateTime(2016, 5, 15),
                    TotalTrip = 178954,
                    FuelRemain = 11.2,
                    Status = DOenums.BusStatus.זמין
                },
                new Bus
                {
                    LicenseNum = 12312300,
                    FromDate = new DateTime(2020, 12, 29),
                    TotalTrip = 0,
                    FuelRemain = 50,
                    Status = DOenums.BusStatus.זמין
                }
            };

            #endregion InitialBusList
            #region InitialLinesList
            listLines = new List<Line>
            {
                new Line
                {
                 Id=1,
                 Code=33,
                 Area=DOenums.Areas.ירושלים,
                 FirstStation=77,
                 LastStation=78
                },
                new Line
                {
                 Id=2,
                 Code=74,
                 Area=DOenums.Areas.ירושלים,
                 FirstStation=83,
                 LastStation=86
                },
                new Line
                {
                 Id=3,
                 Code=75,
                 Area=DOenums.Areas.ירושלים,
                 FirstStation=88,
                 LastStation=83
                },
                new Line
                {
                 Id=4,
                 Code=55,
                 Area=DOenums.Areas.ירושלים,
                 FirstStation=90,
                 LastStation=94
                },
                new Line
                {
                 Id=5,
                 Code=52,
                 Area=DOenums.Areas.ירושלים,
                 FirstStation=102,
                 LastStation=97
                },
                new Line
                {
                 Id=6,
                 Code=67,
                 Area=DOenums.Areas.ירושלים,
                 FirstStation=76,
                 LastStation=73
                },
                new Line
                {
                 Id=7,
                 Code=69,
                 Area=DOenums.Areas.ירושלים,
                 FirstStation=110,
                 LastStation=115
                },
                new Line
                {
                 Id=8,
                 Code=64,
                 Area=DOenums.Areas.ירושלים,
                 FirstStation=117,
                 LastStation=1491
                },
                new Line
                {
                 Id=9,
                 Code=31,
                 Area=DOenums.Areas.ירושלים,
                 FirstStation=88,
                 LastStation=89
                },
                new Line
                {
                 Id=10,
                 Code=32,
                 Area=DOenums.Areas.ירושלים,
                 FirstStation=122,
                 LastStation=1523
                }
            };

            #endregion InitialLinesList
            #region InitialLinesStationsList

            listLineStations = new List<LineStation>
            {
                new LineStation
                {
                    LineId = 1,
                    Station = 77,
                    LineStationIndex = 1,
                    PrevStation = 0,
                    NextStation = 73
                },
                new LineStation
                {
                    LineId = 1,
                    Station = 73,
                    LineStationIndex = 2,
                    PrevStation = 77,
                    NextStation = 76
                },
                new LineStation
                {
                    LineId = 1,
                    Station = 76,
                    LineStationIndex = 3,
                    PrevStation = 73,
                    NextStation = 78
                },
                new LineStation
                {
                    LineId = 1,
                    Station = 78,
                    LineStationIndex = 4,
                    PrevStation = 76,
                    NextStation = 83
                },
                new LineStation
                {
                    LineId = 1,
                    Station = 83,
                    LineStationIndex = 5,
                    PrevStation = 78,
                    NextStation = 84
                },
                new LineStation
                {
                    LineId = 1,
                    Station = 84,
                    LineStationIndex = 6,
                    PrevStation = 83,
                    NextStation = 85
                },
                new LineStation
                {
                    LineId = 1,
                    Station = 85,
                    LineStationIndex = 7,
                    PrevStation = 84,
                    NextStation = 89
                },
                new LineStation
                {
                    LineId = 1,
                    Station = 89,
                    LineStationIndex = 8,
                    PrevStation = 85,
                    NextStation = 93
                },
                new LineStation
                {
                    LineId = 1,
                    Station = 93,
                    LineStationIndex = 9,
                    PrevStation = 89,
                    NextStation = 78
                },
                new LineStation
                {
                    LineId = 1,
                    Station = 78,
                    LineStationIndex = 10,
                    PrevStation = 93,
                    NextStation = 0
                },
                new LineStation
                {
                    LineId = 2,
                    Station = 83,
                    LineStationIndex = 1,
                    PrevStation = 0,
                    NextStation = 93
                },
                new LineStation
                {
                    LineId = 2,
                    Station = 93,
                    LineStationIndex = 2,
                    PrevStation = 83,
                    NextStation = 94
                },
                new LineStation
                {
                    LineId = 2,
                    Station = 94,
                    LineStationIndex = 3,
                    PrevStation = 93,
                    NextStation = 95
                },
                new LineStation
                {
                    LineId = 2,
                    Station = 95,
                    LineStationIndex = 4,
                    PrevStation = 94,
                    NextStation = 102
                },
                new LineStation
                {
                    LineId = 2,
                    Station = 102,
                    LineStationIndex = 5,
                    PrevStation = 95,
                    NextStation = 86
                },
                new LineStation
                {
                    LineId = 2,
                    Station = 86,
                    LineStationIndex = 6,
                    PrevStation = 102,
                    NextStation = 84
                },
                new LineStation
                {
                    LineId = 2,
                    Station = 84,
                    LineStationIndex = 7,
                    PrevStation = 86,
                    NextStation = 77
                },
                new LineStation
                {
                    LineId = 2,
                    Station = 77,
                    LineStationIndex = 8,
                    PrevStation = 84,
                    NextStation = 76
                },
                new LineStation
                {
                    LineId = 2,
                    Station = 76,
                    LineStationIndex = 9,
                    PrevStation = 77,
                    NextStation = 86
                },
                new LineStation
                {
                    LineId = 2,
                    Station = 86,
                    LineStationIndex = 10,
                    PrevStation = 76,
                    NextStation = 0
                },
                new LineStation
                {
                    LineId = 3,
                    Station = 88,
                    LineStationIndex = 1,
                    PrevStation = 0,
                    NextStation = 89
                },
                new LineStation
                {
                    LineId = 3,
                    Station = 89,
                    LineStationIndex = 2,
                    PrevStation = 88,
                    NextStation = 93
                },
                new LineStation
                {
                    LineId = 3,
                    Station = 93,
                    LineStationIndex = 3,
                    PrevStation = 89,
                    NextStation = 95
                },
                new LineStation
                {
                    LineId = 3,
                    Station = 95,
                    LineStationIndex = 4,
                    PrevStation = 93,
                    NextStation = 106
                },
                new LineStation
                {
                    LineId = 3,
                    Station = 106,
                    LineStationIndex = 5,
                    PrevStation = 95,
                    NextStation = 108
                },
                new LineStation
                {
                    LineId = 3,
                    Station = 108,
                    LineStationIndex = 6,
                    PrevStation = 106,
                    NextStation = 109
                },
                new LineStation
                {
                    LineId = 3,
                    Station = 109,
                    LineStationIndex = 7,
                    PrevStation = 108,
                    NextStation = 84
                },
                new LineStation
                {
                    LineId = 3,
                    Station = 84,
                    LineStationIndex = 8,
                    PrevStation = 109,
                    NextStation = 89
                },
                new LineStation
                {
                    LineId = 3,
                    Station = 89,
                    LineStationIndex = 9,
                    PrevStation = 84,
                    NextStation = 83
                },
                new LineStation
                {
                    LineId = 3,
                    Station = 83,
                    LineStationIndex = 10,
                    PrevStation = 89,
                    NextStation = 0
                },
                new LineStation
                {
                    LineId = 4,
                    Station = 90,
                    LineStationIndex = 1,
                    PrevStation = 0,
                    NextStation = 89
                },
                new LineStation
                {
                    LineId = 4,
                    Station = 89,
                    LineStationIndex = 2,
                    PrevStation = 90,
                    NextStation = 93
                },
                new LineStation
                {
                    LineId = 4,
                    Station = 93,
                    LineStationIndex = 3,
                    PrevStation = 89,
                    NextStation = 108
                },
                new LineStation
                {
                    LineId = 4,
                    Station = 108,
                    LineStationIndex = 4,
                    PrevStation = 93,
                    NextStation = 109
                },
                new LineStation
                {
                    LineId = 4,
                    Station = 109,
                    LineStationIndex = 5,
                    PrevStation = 108,
                    NextStation = 105
                },
                new LineStation
                {
                    LineId = 4,
                    Station = 105,
                    LineStationIndex = 6,
                    PrevStation = 109,
                    NextStation = 110
                },
                new LineStation
                {
                    LineId = 4,
                    Station = 110,
                    LineStationIndex = 7,
                    PrevStation = 105,
                    NextStation = 84
                },
                new LineStation
                {
                    LineId = 4,
                    Station = 84,
                    LineStationIndex = 8,
                    PrevStation = 110,
                    NextStation = 95
                },
                new LineStation
                {
                    LineId = 4,
                    Station = 95,
                    LineStationIndex = 9,
                    PrevStation = 84,
                    NextStation = 94
                },
                new LineStation
                {
                    LineId = 4,
                    Station = 94,
                    LineStationIndex = 10,
                    PrevStation = 95,
                    NextStation = 0
                },
                new LineStation
                {
                    LineId = 5,
                    Station = 102,
                    LineStationIndex = 1,
                    PrevStation = 0,
                    NextStation = 111
                },
                new LineStation
                {
                    LineId = 5,
                    Station = 111,
                    LineStationIndex = 2,
                    PrevStation = 102,
                    NextStation = 115
                },
                new LineStation
                {
                    LineId = 5,
                    Station = 115,
                    LineStationIndex = 3,
                    PrevStation = 111,
                    NextStation = 117
                },
                new LineStation
                {
                    LineId = 5,
                    Station = 117,
                    LineStationIndex = 4,
                    PrevStation = 115,
                    NextStation = 1486
                },
                new LineStation
                {
                    LineId = 5,
                    Station = 1486,
                    LineStationIndex = 5,
                    PrevStation = 117,
                    NextStation = 1487
                },
                new LineStation
                {
                    LineId = 5,
                    Station = 1487,
                    LineStationIndex = 6,
                    PrevStation = 1486,
                    NextStation = 1490
                },
                new LineStation
                {
                    LineId = 5,
                    Station = 1490,
                    LineStationIndex = 7,
                    PrevStation = 1487,
                    NextStation = 1511
                },
                new LineStation
                {
                    LineId = 5,
                    Station = 1511,
                    LineStationIndex = 8,
                    PrevStation = 1490,
                    NextStation = 108
                },
                new LineStation
                {
                    LineId = 5,
                    Station = 108,
                    LineStationIndex = 9,
                    PrevStation = 1511,
                    NextStation = 97
                },
                new LineStation
                {
                    LineId = 5,
                    Station = 97,
                    LineStationIndex = 10,
                    PrevStation = 108,
                    NextStation = 0
                }
            };

            #endregion InitialLinesStationsList
            #region InitialLineTrip

            listLineTrip = new List<LineTrip>
            {
                new LineTrip
                {
                    LineId = 1,
                    StartAt = new TimeSpan(7,0,0), 
                    FinishAt = new TimeSpan(23,0,0),
                    Frequency = new TimeSpan(0,30,0)
                },
                new LineTrip
                {
                    LineId = 2,
                    StartAt = new TimeSpan(6,15,0),
                    FinishAt = new TimeSpan(18,45,0),
                    Frequency = new TimeSpan(0,30,0)
                },
                new LineTrip
                {
                    LineId = 3,
                    StartAt = new TimeSpan(8,20,0),
                    FinishAt = new TimeSpan(23,40,0),
                    Frequency = new TimeSpan(0,20,0)
                },
                new LineTrip
                {
                    LineId = 4,
                    StartAt = new TimeSpan(7,0,0),
                    FinishAt = new TimeSpan(21,0,0),
                    Frequency = new TimeSpan(1,0,0)
                },
                new LineTrip
                {
                    LineId = 5,
                    StartAt = new TimeSpan(8,30,0),
                    FinishAt = new TimeSpan(22,0,0),
                    Frequency = new TimeSpan(0,20,0)
                },
                new LineTrip
                {
                    LineId = 6,
                    StartAt = new TimeSpan(7,0,0),
                    FinishAt = new TimeSpan(0,0,0),
                    Frequency = new TimeSpan(0,15,0)
                },
                new LineTrip
                {
                    LineId = 7,
                    StartAt = new TimeSpan(9,30,0),
                    FinishAt = new TimeSpan(21,30,0),
                    Frequency = new TimeSpan(1,0,0)
                },
                new LineTrip
                {
                    LineId = 8,
                    StartAt = new TimeSpan(14,0,0),
                    FinishAt = new TimeSpan(1,0,0),
                    Frequency = new TimeSpan(30,0,0)
                },
                new LineTrip
                {
                    LineId = 9,
                    StartAt = new TimeSpan(6,20,0),
                    FinishAt = new TimeSpan(0,10,0),
                    Frequency = new TimeSpan(0,10,0)
                },
                new LineTrip
                {
                    LineId = 10,
                    StartAt = new TimeSpan(7,45,0),
                    FinishAt = new TimeSpan(13,0,0),
                    Frequency = new TimeSpan(0,15,0)
                }
            };

            #endregion InitialLineTrip
            #region InitialAdjacentStations

            listAdjacentStations = new List<AdjacentStations>();
            foreach (LineStation item in listLineStations)
                if (item.NextStation != 0)
                {
                    AdjacentStations ads = new AdjacentStations();
                    ads.Station1 = item.Station;
                    ads.Station2 = item.NextStation;
                    //calculate distance and time
                    listAdjacentStations.Add(ads);
                }

            #endregion InitialAdjacentStations
        }
    }
}
