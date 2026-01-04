namespace Api_Telemetry_F1.Common
{
    public class CoutryIdMapping
    {
        public record NationalityInfo(
        byte Id,
        string CountryNameEn,
        string CountryNamePtBr,
        string NationalityEn,
        string NationalityPtBr);

        // uso total de i.a, pra facilitar a vida xD
        private static readonly Dictionary<byte, NationalityInfo> Map = new()
        {
            { 1,  new(1,  "United States",          "Estados Unidos",       "American",         "Americano") },
            { 2,  new(2,  "Argentina",              "Argentina",            "Argentinean",      "Argentino") },
            { 3,  new(3,  "Australia",              "Austrália",            "Australian",       "Australiano") },
            { 4,  new(4,  "Austria",                "Áustria",              "Austrian",         "Austriaco") },
            { 5,  new(5,  "Azerbaijan",             "Azerbaijão",           "Azerbaijani",      "Azerbaijano") },
            { 6,  new(6,  "Bahrain",                "Bahrein",              "Bahraini",         "Bareinita") },
            { 7,  new(7,  "Belgium",                "Bélgica",              "Belgian",          "Belga") },
            { 8,  new(8,  "Bolivia",                "Bolívia",              "Bolivian",         "Boliviano") },
            { 9,  new(9,  "Brazil",                 "Brasil",               "Brazilian",        "Brasileiro") },
            { 10, new(10, "United Kingdom",         "Reino Unido",          "British",          "Britânico") },
            { 11, new(11, "Bulgaria",               "Bulgária",             "Bulgarian",        "Búlgaro") },
            { 12, new(12, "Cameroon",               "Camarões",             "Cameroonian",      "Camarones") },
            { 13, new(13, "Canada",                 "Canadá",               "Canadian",         "Canadense") },
            { 14, new(14, "Chile",                  "Chile",                "Chilean",          "Chileno") },
            { 15, new(15, "China",                  "China",                "Chinese",          "Chinês") },
            { 16, new(16, "Colombia",               "Colômbia",             "Colombian",        "Colombiano") },
            { 17, new(17, "Costa Rica",             "Costa Rica",           "Costa Rican",      "Costa-riquenho") },
            { 18, new(18, "Croatia",                "Croácia",              "Croatian",         "Croata") },
            { 19, new(19, "Cyprus",                 "Chipre",               "Cypriot",          "Cipriota") },
            { 20, new(20, "Czech Republic",         "República Tcheca",     "Czech",            "Tcheco") },
            { 21, new(21, "Denmark",                "Dinamarca",            "Danish",           "Dinamarquês") },
            { 22, new(22, "Netherlands",            "Países Baixos",        "Dutch",            "Holandês") },
            { 23, new(23, "Ecuador",                "Equador",              "Ecuadorian",       "Equatoriano") },
            { 24, new(24, "United Kingdom",         "Reino Unido",          "English",          "Inglês") },
            { 25, new(25, "United Arab Emirates",   "Emirados Árabes Unidos","Emirian",          "Emirati") },
            { 26, new(26, "Estonia",                "Estônia",              "Estonian",         "Estônio") },
            { 27, new(27, "Finland",                "Finlândia",            "Finnish",          "Finlandês") },
            { 28, new(28, "France",                 "França",               "French",           "Francês") },
            { 29, new(29, "Germany",                "Alemanha",             "German",           "Alemão") },
            { 30, new(30, "Ghana",                  "Gana",                 "Ghanaian",         "Ganês") },
            { 31, new(31, "Greece",                 "Grécia",               "Greek",            "Grego") },
            { 32, new(32, "Guatemala",              "Guatemala",            "Guatemalan",       "Guatemalteco") },
            { 33, new(33, "Honduras",               "Honduras",             "Honduran",         "Hondurenho") },
            { 34, new(34, "Hong Kong",              "Hong Kong",            "Hong Konger",      "Honconguês") },
            { 35, new(35, "Hungary",                "Hungria",              "Hungarian",        "Húngaro") },
            { 36, new(36, "Iceland",                "Islândia",             "Icelander",        "Islandês") },
            { 37, new(37, "India",                  "Índia",                "Indian",           "Indiano") },
            { 38, new(38, "Indonesia",              "Indonésia",            "Indonesian",       "Indonésio") },
            { 39, new(39, "Ireland",                "Irlanda",              "Irish",            "Irlandês") },
            { 40, new(40, "Israel",                 "Israel",               "Israeli",          "Israelense") },
            { 41, new(41, "Italy",                  "Itália",               "Italian",          "Italiano") },
            { 42, new(42, "Jamaica",                "Jamaica",              "Jamaican",         "Jamaicano") },
            { 43, new(43, "Japan",                  "Japão",                "Japanese",         "Japonês") },
            { 44, new(44, "Jordan",                 "Jordânia",             "Jordanian",        "Jordano") },
            { 45, new(45, "Kuwait",                 "Kuwait",               "Kuwaiti",          "Kuwaitiano") },
            { 46, new(46, "Latvia",                 "Letônia",              "Latvian",          "Letão") },
            { 47, new(47, "Lebanon",                "Líbano",               "Lebanese",         "Libanês") },
            { 48, new(48, "Lithuania",              "Lituânia",             "Lithuanian",       "Lituano") },
            { 49, new(49, "Luxembourg",             "Luxemburgo",           "Luxembourger",     "Luxemburguês") },
            { 50, new(50, "Malaysia",               "Malásia",              "Malaysian",        "Malaio") },
            { 51, new(51, "Malta",                  "Malta",                "Maltese",          "Maltês") },
            { 52, new(52, "Mexico",                 "México",               "Mexican",          "Mexicano") },
            { 53, new(53, "Monaco",                 "Mônaco",               "Monegasque",       "Monegasco") },
            { 54, new(54, "New Zealand",            "Nova Zelândia",        "New Zealander",    "Neozelandês") },
            { 55, new(55, "Nicaragua",              "Nicarágua",            "Nicaraguan",       "Nicaraguense") },
            { 56, new(56, "United Kingdom",         "Reino Unido",          "Northern Irish",   "Irlandês do Norte") },
            { 57, new(57, "Norway",                 "Noruega",              "Norwegian",        "Norueguês") },
            { 58, new(58, "Oman",                   "Omã",                  "Omani",            "Omanense") },
            { 59, new(59, "Pakistan",               "Paquistão",            "Pakistani",        "Paquistanês") },
            { 60, new(60, "Panama",                 "Panamá",               "Panamanian",       "Panamenho") },
            { 61, new(61, "Paraguay",               "Paraguai",             "Paraguayan",       "Paraguaio") },
            { 62, new(62, "Peru",                   "Peru",                 "Peruvian",         "Peruano") },
            { 63, new(63, "Poland",                 "Polônia",              "Polish",           "Polonês") },
            { 64, new(64, "Portugal",               "Portugal",             "Portuguese",       "Português") },
            { 65, new(65, "Qatar",                  "Catar",                "Qatari",           "Catarense") },
            { 66, new(66, "Romania",                "Romênia",              "Romanian",         "Romeno") },
            { 68, new(68, "El Salvador",            "El Salvador",          "Salvadoran",       "Salvadorenho") },
            { 69, new(69, "Saudi Arabia",           "Arábia Saudita",       "Saudi",            "Saudita") },
            { 70, new(70, "United Kingdom",         "Reino Unido",          "Scottish",         "Escocês") },
            { 71, new(71, "Serbia",                 "Sérvia",               "Serbian",          "Sérvio") },
            { 72, new(72, "Singapore",              "Singapura",            "Singaporean",      "Cingapuriano") },
            { 73, new(73, "Slovakia",               "Eslováquia",           "Slovakian",        "Eslovaco") },
            { 74, new(74, "Slovenia",               "Eslovênia",            "Slovenian",        "Esloveno") },
            { 75, new(75, "South Korea",            "Coreia do Sul",        "South Korean",     "Sul-coreano") },
            { 76, new(76, "South Africa",           "África do Sul",        "South African",    "Sul-africano") },
            { 77, new(77, "Spain",                  "Espanha",              "Spanish",          "Espanhol") },
            { 78, new(78, "Sweden",                 "Suécia",               "Swedish",          "Sueco") },
            { 79, new(79, "Switzerland",            "Suíça",                "Swiss",            "Suíço") },
            { 80, new(80, "Thailand",               "Tailândia",            "Thai",             "Tailandês") },
            { 81, new(81, "Turkey",                 "Turquia",              "Turkish",          "Turco") },
            { 82, new(82, "Uruguay",                "Uruguai",              "Uruguayan",        "Uruguaio") },
            { 83, new(83, "Ukraine",                "Ucrânia",              "Ukrainian",        "Ucraniano") },
            { 84, new(84, "Venezuela",              "Venezuela",            "Venezuelan",       "Venezuelano") },
            { 85, new(85, "Barbados",               "Barbados",             "Barbadian",        "Barbadiano") },
            { 86, new(86, "United Kingdom",         "Reino Unido",          "Welsh",            "Galês") },
            { 87, new(87, "Vietnam",                "Vietnã",               "Vietnamese",       "Vietnamita") },
            { 88, new(88, "Algeria",                "Argélia",              "Algerian",         "Argelino") },
            { 89, new(89, "Bosnia and Herzegovina", "Bósnia e Herzegovina", "Bosnian",          "Bosníaco") },
            { 90, new(90, "Philippines",            "Filipinas",            "Filipino",         "Filipino") }
        };
        public static string GetCountryNameEn(byte id)
            => Map.TryGetValue(id, out var info) ? info.CountryNameEn : "Unknown";

        public static string GetCountryNamePtBr(byte id)
            => Map.TryGetValue(id, out var info) ? info.CountryNamePtBr : "Desconhecido";

        public static string GetNationalityEn(byte id)
            => Map.TryGetValue(id, out var info) ? info.NationalityEn : "Unknown";

        public static string GetNationalityPtBr(byte id)
            => Map.TryGetValue(id, out var info) ? info.NationalityPtBr : "Desconhecida";

        public static NationalityInfo? GetFullInfo(byte id)
            => Map.TryGetValue(id, out var info) ? info : null;
    }
}
