using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphicalShell.Resourses;


namespace GraphicalShell.Interface
{
   static class GraphInterface
    {
        private static List<string> par = new List<string>();
        private static List<string> args = new List<string>();
        private static List<string> arguments = new List<string>();
       
        /// <summary>
        /// инициализирует список с аргументами по значению параметра 1-IPCONFIG, 2-PING, 3-TRACERT
        /// </summary>
        /// <param name="op"></param>
        /// <returns></returns>
        public static IList GetArgumentsLvl0(int op)
        {
            args = new List<string>();
            switch (op)
            {
                case 2:

                    args.Add("Указать, что проверка связи продолжит отправлять сообщения запросов в место назначения, пока не будет прервано (/t)");
                    args.Add("задать  разрешение обратных имен выполняется на IP-адрес назначения (/а)");
                    args.Add("задать число отправленных запросов. По умолчанию 4 (/n)");
                    args.Add("указать длину (в байтах) поля данных в отправленных сообщениях запроса. По умолчанию 32, максимальный размер 65 527(/l)");
                    args.Add("указать, что сообщения должны отправляться с пометкой \"не фрагментировать\" в заголовке IP. По умолчанию 1 (доступно только в IPv4). ообщения запроса не могут быть фрагментированы маршрутизаторами по пути к назначению (/f)");
                    args.Add("задать срок жизни пакета TTL. Максимум 255 (/i)");
                    args.Add("указать значение для поля типа службы службы TOS в IP заголовке для отправки запроса (доступно только в IPv4). По умолчанию 0, максимальное значение 255 (/v)");
                    args.Add("указать, что параметр записи Route в заголовке IP-адреса используется для записи пути, полученного сообщением запроса, и соответствующего сообщения о ответе (доступно только в IPv4). Каждый прыжок в пути использует запись в параметре запись маршрута . Диапазон прыжка от 1 до 9.(/r)");
                    args.Add("указать, что параметр отметка времени Интернета в заголовке IP используется для записи времени прибытия сообщения запроса и соответствующего сообщения эхо-ответа для каждого прыжка. Минимальное значение 1 и максимальное 4.( /s)");
                    args.Add("указать, что сообщения запроса используют параметр свободного исходного маршрута в заголовке IP с набором промежуточных назначений, указанных в hostlist (доступно только в IPv4). Максимальное возможное число адресов или имен в списке узлов равно 9. (/j)");
                    args.Add("указать, что сообщения запроса используют в заголовке IP параметр с максимальным исходным маршрутом с набором промежуточных назначений, указанных в hostlist (доступно только в IPv4). Максимальное число адресов или имен в списке узлов равно 9. (/k)");
                    args.Add("указать время (в миллисекундах) ожидания получения сообщения о ответе, соответствующего заданному сообщению запроса. Если ответное сообщение не получено в течение времени ожидания, отображается сообщение об ошибке (\"запрос был превышен\").По умолчанию время ожидания составляет 4000 (4 секунды). (/w)");
                    args.Add("Указать, что путь приема-передачи отслеживается (доступно только в IPv6). (/R)");
                    args.Add("указать используемый адрес (доступно только в IPV6) (/S)");
                    args.Add("указать, что протокол IPv4 используется для проверки связи. Этот параметр не требуется для определения целевого узла с IPv4-адресом. Необходимо только указать целевой узел по имени (/4)");
                    args.Add("указать, Указывает, что протокол IPv6 используется для проверки связи. Этот параметр не требуется для определения целевого узла с IPv6-адресом. Необходимо только указать целевой узел по имени. (/6)");
                    args.Add("вывод справочной информации (/?)");
                    break;
                case 3:
                    args.Add("предотвратить попытки команды tracert разрешения IP-адресов промежуточных маршрутизаторов в имена. Увеличивает скорость вывода результатов команды tracert (/d)");
                    args.Add("задать максимальное количество переходов на пути при поиске конечного объекта. Значение по умолчанию 30 (/h)");
                    args.Add("указать для сообщений с запросом использование параметра свободной маршрутизации в заголовке IP с набором промежуточных мест назначения. Максимальное число адресов - 9, разделитель пробел (/j)");
                    args.Add("определить время ожидания ответов протокола ICMP или сообщений ICMP об истечении времени, соответствующих данному сообщению заказа. По умолчанию время ожидания составляет 4000 (4 секунды). (/w)");
                    args.Add("Указать, что путь приема-передачи отслеживается (доступно только в IPv6). (/R)");
                    args.Add("указать используемый адрес (доступно только в IPV6) (/S)");
                    args.Add("указать, что протокол IPv4 используется для проверки связи. Этот параметр не требуется для определения целевого узла с IPv4-адресом. Необходимо только указать целевой узел по имени (/4)");
                    args.Add("указать, Указывает, что протокол IPv6 используется для проверки связи. Этот параметр не требуется для определения целевого узла с IPv6-адресом. Необходимо только указать целевой узел по имени. (/6)");
                    args.Add("вывод справочной информации (/?)");
                    break;
                case 1:
                    //use one adapter
                    args.Add("вывести подробные сведения о конфигурации (/all)");
                    args.Add("освобождение адреса IPv4 для указаннного адаптера (/release)");
                    args.Add("освобождение адреса IPv6 для указанного сетевого адаптера (/release6)");
                    args.Add("обновление адреса IPv4 для указанного сетевого адаптера (/renew)");
                    args.Add("обновление адреса IPv6 для указанного сетевого адаптера (/renew6)");
                    args.Add("очистка кэша сопоставителя DNS (/flushdns)");
                    args.Add("обновление всех DHCP-аренд и перерегистрация DNS имен (/registerdns)");
                    args.Add("отображение содержимого кэша сопоставителя DNS (/displaydns)");
                    args.Add("отображение всех допустимых допустимых для этого адаптера идентификаторов класса DHCP IPv4 (/showclassid)");
                    args.Add("измеенение идентификатора класса DHCP IPv4 (/setclassid)");
                    args.Add("отображение всех допустимых для этого адаптера идентификаторов классов DHCP IPv6 (/showclassid6)");
                    args.Add("изменение идентификатора класса IPv6 (/setclassid6)");
                    args.Add("вывод справочной информации (/?)");
                    break;
                #region INDIVIDUAL WORK
                case 4:
                    args.Add("отображение всех активных подключений (/a)");
                    args.Add("отображение статистики Enternet в виде отображение статистики Ethernet в виде счетчиков принятых и отправленных байт и пакетов (/e)");
                    args.Add("отображение номеров портов в виде десятичных чисел (/n)");
                    args.Add("отображение соединений, включая идентификатор процесса PID для каждого соединения (/o)");
                    args.Add("отображение соединений для заданного протокола (/p); можно задавать протоколы TSP, UDP, TSPv6, UDPv6; При использовании с параметром (/s) к вышеперечисленным протоколам добавляются ICMTP, IP,  ICMTPv6, IPv6");
                    args.Add("отображение статистических данных протоколов (/s)");
                    args.Add("вывод справочной информации (/?)");
                    break;
                case 5:
                    args.Add("при прохождении списка узлов игнорировать предыдущий маршрут. Максимальное число списка адресов равно 9. Элементы поля помещаются в специальное поле заголовка отправляемых ICMP пакетов (/g)");
                    args.Add("задать максимальное количество переходов на пути при поиске конечного объекта. Значение по умолчанию 30 (/h)");
                    args.Add("использовать указанный адрес источника в отправляемых ICMP пакетах (/i)");
                    args.Add("Предотвращает попытки pathping осуществить доступ IP-адреса промежуточных маршрутизаторов к их именам. Это может ускорить отображение результатов pathping. (/n)");
                    args.Add("задание паузы между отправкой пакетов. По умолчанию 250. Этот параметр отправляет индивидуальные проверки связи на каждый промежуточный прыжок. (/p)");
                    args.Add("задать число запросов, отправляемому каждому маршрутизатору в пути. Значение по умолчанию составляет 100. (/q)");
                    args.Add("указать количество милисекунд ожидания каждого ответа. Если ответное сообщение не получено в течение времени ожидания, отображается сообщение об ошибке (\"запрос был превышен\"). Значение по умолчанию составляет 3000 мсек (3 сек). Этот параметр не связан с параметром времени /p, поскольку пареллельно отправляет несколько запросов проверки связи (/w)");
                    args.Add("тестировать возможность использованпия RSVP (Reservation Protocol, протокола настройки резервирования ресурсов), позволяющего динамически выделять ресурсы для различного вида трафика (/R)");
                    args.Add("тестировать возможность использований  QoS QoS (Quality of Service - качество обслуживания) - системы обслуживания пакетов разного содержания с учетом их приоритетов доставки получателю (/T)");
                    args.Add("принудительно использовать протокол IPv4 (/4)");
                    args.Add("принудительно использовать протокол IPv6 (/6)");
                    args.Add("вывод справочной информации (/?)");
                    break;
                #endregion
            }
            return args;
        }
        /// <summary>
        /// загружает аргументы в список 1-CONFIG, 2-PING, 3-TRANSERT;
        /// <summary>
        /// Подробнее: https://docs.microsoft.com/ru-ru/windows-server/administration/windows-commands/windows-commands
        /// <param name="parametr"></param>
        /// <returns></returns>
        public static IList LoadAruments(int parametr)
        {
            arguments = new List<string>();
            switch (parametr)
            {
                case 1:
                    arguments.Add("/all");
                    arguments.Add("/release");
                    arguments.Add("/release6");
                    arguments.Add("/renew");
                    arguments.Add("/renew6");
                    arguments.Add("/flushdns");
                    arguments.Add("/registerdns");
                    arguments.Add("/displaydns");
                    arguments.Add("/showclassid");
                    arguments.Add("/showclassid6");
                    arguments.Add("/setclassid");
                    arguments.Add("/setclassid6");
                    arguments.Add("/?");
                    break;
                
                case 2:
                    arguments.Add("/t");
                    arguments.Add("/a");
                    arguments.Add("/n");
                    arguments.Add("/l");
                    arguments.Add("/f");
                    arguments.Add("/i");
                    arguments.Add("/v");
                    arguments.Add("/r");
                    arguments.Add("/s");
                    arguments.Add("/j");
                    arguments.Add("/k");
                    arguments.Add("/w");
                    arguments.Add("/R");
                    arguments.Add("/S");
                    arguments.Add("/4");
                    arguments.Add("/6");
                    arguments.Add("/?");
                    
                   
                    break;
                case 3:
                    arguments.Add("/d");
                    arguments.Add("/h");
                    arguments.Add("/j");
                    arguments.Add("/w");
                    arguments.Add("/R");
                    arguments.Add("/S");
                    arguments.Add("/4");
                    arguments.Add("/6");
                    arguments.Add("/?");
                    break;
                #region INDIVIDUAL WORK
                case 4:
                    arguments.Add("/a");
                    arguments.Add("/e");
                    arguments.Add("/n");
                    arguments.Add("/o");
                    arguments.Add("/p");
                    arguments.Add("/s");
                    arguments.Add("/?");
                    break;
                case 5:
                    arguments.Add("/g");
                    arguments.Add("/h");
                    arguments.Add("/i");
                    arguments.Add("/n");
                    arguments.Add("/p");
                    arguments.Add("/q");
                    arguments.Add("/w");
                    arguments.Add("/P");
                    arguments.Add("/R");
                    arguments.Add("/T");
                    arguments.Add("/4");
                    arguments.Add("/6");
                    arguments.Add("/?");
                    break;
                #endregion
            }

            return arguments;
        }
        /// <summary>
        /// загружает ресурсы для аргументов. 1-CONFIG, 2-PING, 3-TRANSERT, 4-NETSTAT, 5-...
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static List<Element<string>>  LoadResourses(int parameter)
        {
            string m = "";
            List<Element<string>> elements = new List<Element<string>>();
            switch (parameter)
            {
                case 1:
                    m = "1.1.1.1.1";
                    elements.AddRange(new List<Element<string>>
                    {
                        
                        new Element<string>(id: 0, desc:"/all", value: "", min: string.Empty, max: GetMax(),mask:m,parent:GetParametr(parameter),v:false),
                        new Element<string>(id: 1, desc: "/release", value: "", min: string.Empty, max: GetMax(),mask:m,parent:GetParametr(parameter)),
                        new Element<string>(id:2,desc:"/release6",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter)),
                        new Element<string>(id:3, desc:"/renew",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter)),
                        new Element<string>(id:4, desc:"/renew6",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter)),
                        new Element<string>(id:5, desc:"/fulshdns",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter),v:false),
                        new Element<string>(id:6,desc:"/registerdns",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter),v:false),
                        new Element<string>(id:7,desc:"/displaydns",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter),v:false),
                        new Element<string>(id:8,desc:"/setclassid",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter)),
                        new Element<string>(id:9,desc:"/showclassid",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter)),
                        new Element<string>(id:10,desc:"/showclassid6",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter)),
                        new Element<string>(id:11,desc:"/setclassid6",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter)),
                        new Element<string>(id:12,desc:"/?",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter),v:false)
                    }
                    );
                    break;
                case 2:
                    elements.AddRange(new List<Element<string>>
                    {
                         new Element<string>(id: 0, desc: "/t", value: "", min: string.Empty, max: GetMax(),mask:m,parent:GetParametr(parameter),v:false),
                         new Element<string>(id: 1, desc: "/a", value: "", min: string.Empty, max: GetMax(),mask:m,parent:GetParametr(parameter),v:false),
                         new Element<string>(id:2,desc:"/n",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter)),
                         new Element<string>(id:3, desc:"/l",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter)),
                         new Element<string>(id:4, desc:"/f",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter),v:false),
                         new Element<string>(id:5, desc:"/i",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter)),
                         new Element<string>(id:6,desc:"/v",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter)),
                         new Element<string>(id:7,desc:"/r",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter)),
                         new Element<string>(id:8,desc:"/s",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter)),
                         new Element<string>(id:9,desc:"/j",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter)),
                         new Element<string>(id:10,desc:"/k",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter)),
                         new Element<string>(id:11,desc:"/R",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter),v:false),
                         new Element<string>(id:12, desc:"/S",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter)),
                         new Element<string>(id:13,desc:"/4",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter),v:false),
                         new Element<string>(id:14,desc:"/6",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter),v:false),
                         new Element<string>(id:15,desc:"/?",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter),v:false),
                         new Element<string>(id:16,desc:"final Value",value:"",min:string.Empty,max:GetMax(), mask:m, parent:GetParametr(parameter),isfinv:true)
                    }
                  ) ;
                    break;
                case 3:
                    elements.AddRange(new List<Element<string>>
                    {
                        new Element<string>(id: 0, desc: "/d", value: "", min: string.Empty, max: GetMax(),mask:m,parent:GetParametr(parameter),v:false),
                        new Element<string>(id: 1, desc: "/h", value: "", min: string.Empty, max: GetMax(),mask:m,parent:GetParametr(parameter)),
                        new Element<string>(id:2,desc:"/j",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter)),
                        new Element<string>(id:3, desc:"/w",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter)),
                        new Element<string>(id:4,desc:"/R",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter),v:false),
                        new Element<string>(id:5, desc:"/S",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter)),
                        new Element<string>(id:6,desc:"/4",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter),v:false),
                        new Element<string>(id:7,desc:"/6",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter),v:false),
                       new Element<string>(id:8,desc:"/?",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter),v:false),
                       new Element<string>(id:9,desc:"final Value",value:"",min:string.Empty,max:GetMax(), mask:m, parent:GetParametr(parameter),isfinv:true)
                    }
                  );
                    break;
                #region INDIVIDUAL WORK
                case 4:
                    elements.AddRange(new List<Element<string>>
                    {
                        new Element<string>(id: 0, desc: "/a", value: "", min: string.Empty, max: GetMax(), mask: m, parent: GetParametr(parameter), v:false),
                        new Element<string>(id: 1, desc: "/e", value: "", min: string.Empty, max: GetMax(), mask: m, parent:GetParametr(parameter),v:false),
                        new Element<string>(id:2,desc:"/n",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter),v:false),
                        new Element<string>(id:3,desc:"/o",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter),v:false),
                        new Element<string>(id:4,desc:"/p",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter),v:true),
                        new Element<string>(id:5, desc:"/s",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter),v:false),
                        new Element<string>(id:6, desc:"/?",value:"",min:string.Empty,max:GetMax(),mask:m, parent:GetParametr(parameter),v:false),
                        //new Element<string>(id:7,desc:"final Value",value:"",min:string.Empty,max:GetMax(), mask:m, parent:GetParametr(parameter),isfinv:true)
                    });
                    break;
                case 5:
                    elements.AddRange(new List<Element<string>>
                    {
                        new Element<string>(id:0,desc:"/g",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter)),
                        new Element<string>(id:1, desc:"/h",value:"",min:string.Empty,max:GetMax(), mask:m, parent:GetParametr(parameter)),
                        new Element<string>(id:2, desc:"/i",value:"",min:string.Empty,max:GetMax(), mask:m, parent:GetParametr(parameter)),
                        new Element<string>(id:3, desc: "/n", value:"",min:string.Empty,max:GetMax(), mask:m,parent:GetParametr(parameter),v:false),
                        new Element<string>(id:4, desc:"/p",value:"", min:string.Empty, max:GetMax(), mask:m,parent:GetParametr(parameter)),
                        new Element<string>(id:5, desc:"/q",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter)),
                        new Element<string>(id:6, desc:"/w",value:"",min:string.Empty,max:GetMax(),mask:m, parent:GetParametr(parameter)),
                        new Element<string>(id:7, desc:"/R",value:"",min:string.Empty,max:GetMax(),mask:m, parent:GetParametr(parameter),v:false),
                        new Element<string>(id:8, desc:"/T",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter),v:false),
                        new Element<string>(id:9, desc:"/4",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter),v:false),
                        new Element<string>(id:10,desc:"/6",value:"",min:string.Empty,max:GetMax(),mask:m,parent:GetParametr(parameter),v:false),
                        new Element<string>(id:6, desc:"/?",value:"",min:string.Empty,max:GetMax(),mask:m, parent:GetParametr(parameter),v:false),
                        new Element<string>(id:7,desc:"final Value",value:"",min:string.Empty,max:GetMax(), mask:m, parent:GetParametr(parameter),isfinv:true)
                    });
                    
                    
                    break;
                    #endregion
            }
            string GetMax()
            {
                return decimal.MaxValue.ToString();
               // return double.MaxValue.ToString();
            }
            return elements;
            
        }
        /// <summary>
        /// возвращает конечный аргумент значение. При отсутствии возвращает пустую строку
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetArgument(Element<string> element)
        {
            string data = "";
            return element.Value;
            //return data;
        }
        /// <summary>
        /// возвращает истину, если набор аргументов принимает конечный аргумент значение
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool IsHawingArumet(Element<string> element)
        {
            bool a = true;
            switch (GetParametr(element.Parent))
            {
                case 0:
                    a = false;
                    break;
                case 1:
                    
                    break;
                case 2:
                    a = false;
                    break;
            }
            return a;
        }
        /// <summary>
        ///  возвращает истину, если набор аргументов принимает конечный аргумент значение
        /// </summary>
        /// <param name="Parent"></param>
        /// <returns></returns>
        public static bool IsHawingArumet(string Parent)
        {
            bool a = true;
            switch (GetParametr(Parent))
            {
                case 0:
                    a = false;
                    break;
                case 1:

                    break;
                case 2:
                    a = false;
                    break;
            }
            return a;
        }
        /// <summary>
        /// валидация данных
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>

        public static bool Validate(Element<string> element)
        {
            //List<string> data = new List<string>();
            bool isvalid = true;
            if (element.IsFinalVaue)
            {

                ValidateHost(element.Value);
            }

            else
            {
                switch (element.Parent)
                {
                    case "IPCONFIG":
                        switch (element.Description)
                        {
                            case "/renew":
                            case "/renew6":
                            case "/realise":
                            case "/realise6":
                            case "/showclassid":
                                isvalid = ValidateHost(element.Value);
                                break;
                            case "/setcassid":
                                isvalid = (element.Value == "*") ? true : false;
                                if (!isvalid)
                                {
                                    if (element.Value.Split(' ').Length == 2)
                                    {
                                        if (int.TryParse(element.Value.Split(' ')[1], out _))
                                        {
                                            isvalid = ValidateHost(element.Value.Split(' ')[0]);
                                        }
                                    }
                                    else
                                        isvalid = ValidateHost(element.Value);
                                }
                                break;
                        }
                        break;
                    case "PING":
                        switch (element.Description)
                        {
                            case "/l":
                                if (int.TryParse(element.Value, out int r))
                                {
                                    if (!((r >= 0) || (r <= 655527)))
                                        isvalid = false;
                                }
                                else
                                {
                                    isvalid = false;
                                }
                                break;
                            case "/n":
                            case "/w":
                                if (!int.TryParse(element.Value, out _))
                                    isvalid = false;
                                break;
                            case "/v":
                            case "/i":
                                if (int.TryParse(element.Value, out r))
                                {
                                    if (!((r >= 0) || (r <= 255)))
                                        isvalid = false;
                                }
                                else
                                    isvalid = false;
                                break;
                            case "/r":
                                if (byte.TryParse(element.Value, out byte b))
                                {
                                    if (!((b >= 0) || (b <= 9)))
                                        isvalid = false;
                                }
                                else
                                    isvalid = false;
                                break;
                            case "/s":
                                if (byte.TryParse(element.Value, out b))
                                {
                                    if (!((b >= 1) || (b <= 4)))
                                        isvalid = false;
                                }
                                else
                                    isvalid = false;
                                break;
                            case "/j":
                            case "/k":
                                isvalid = ValidateHostsList(element.Value);
                                break;
                        }
                        break;
                    case "TRACERT":
                        switch (element.Description)
                        {
                            case "/h":
                                isvalid = int.TryParse(element.Value, out _) ? true : false;
                                break;
                            case "/j":
                                isvalid = ValidateHostsList(element.Value);
                                break;
                            case "/w":
                                isvalid = int.TryParse(element.Value, out _);
                                break;
                            case "/S":
                                isvalid = ValidateHost(element.Value);
                                break;
                        }
                        break;
                    case "NETSTAT":
                        bool haves = false;
                        switch (element.Description)
                        {
                            case "/S":
                                haves = true;
                                break;
                            case "/P":
                                if (haves)
                                    isvalid = standart(element.Value);

                                else
                                {
                                    isvalid = (
                                        standart(element.Value) ||
                                       element.Value.Equals("ismpv6", StringComparison.OrdinalIgnoreCase) || element.Value.Equals("icmp", StringComparison.OrdinalIgnoreCase)
                                        );
                                    break;
                                }
                                break;
                                bool standart(string s)
                                {
                                    return ((element.Value.Equals("tsp", StringComparison.OrdinalIgnoreCase) || element.Value.Equals("udp", StringComparison.OrdinalIgnoreCase) ||
                                       element.Value.Equals("tspv6", StringComparison.OrdinalIgnoreCase) || element.Value.Equals("udpv6", StringComparison.OrdinalIgnoreCase)
                                        ));
                        }
                            case "PATHPING":
                                break;
                                
                        }
                        bool ValidateHostsList(string val)
                        {
                            bool v = true;
                            if (((element.Value.Cast<string>().Count()) >= 0) || (element.Value.Cast<string>().Count() <= 9))
                            {
                                foreach (string h in GetHostList(element.Value))
                                {
                                    if (!ValidateHost(h))
                                    {

                                        v = false;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                v = false;
                            }
                            return v;
                        }
                        IEnumerable GetHostList(string exp)
                        {
                            return exp.Split(' ').Cast<string>().ToList();
                        }
                        break;
                    case "PATHPING":
                        switch (element.Description)
                        {
                            case "/g":
                                isvalid = ValidateHostsList(element.Value);
                                break;
                            case "/i":
                                isvalid = ValidateHost(element.Value);
                                break;
                            case "/p":
                                isvalid = int.TryParse(element.Value, out _);
                                break;
                            case "/w":
                                isvalid = int.TryParse(element.Value, out _);
                                break;
                        }
                        break;

                }               
            }
            return isvalid;
        }
       private static bool ValidateHost(string host)
        {
            bool isv = true;
            isv = host.Contains("*") || host.Contains("localhost") || host.Contains("?");
            foreach (string t in host.Split('.').Cast<string>().ToList())
            {
                if (!int.TryParse(t, out _))
                {
                    isv = false;
                    break;
                }
                else
                {
                    isv = true;
                }
            }
            return isv;
        }
        /// <summary>
        /// инициализация параметров
        /// </summary>
        /// <returns></returns>
        public static IList GetParams()
        {
            par = new List<string>();
            par.Add("IPCONFIG");
            par.Add("PING");
            par.Add("TRACERT");
            #region INDIVIDUAL WORK
            par.Add("NETSTAT");
            par.Add("PATHPING");
            #endregion
            return par;
        }
        public static bool SetVisible(CheckedListBox data, int arg)
        {
            return data.Visible = (arg >= 0) ? true : false;
          
        }
        /// <summary>
        /// поиск параметра из списка параметра по значению
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static string GetParametr(int arg)
        {
            try
            {
                return par.ElementAt(arg-1);
            }
           catch (Exception ex)
            {
                return ex.Message;
            }
        }
        /// <summary>
        /// поиск параметра из списка параметров по ID
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static int GetParametr (string arg)
        {
            try
            {
                return par.IndexOf(arg);
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
