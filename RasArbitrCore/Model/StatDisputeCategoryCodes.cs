﻿namespace RasArbitrCore.Model
{
    public class StatDisputeCategoryCodes
    {
        private static Dictionary<string, string> categories = new()
        {
            { "[НЕ ЗАДАН]", string.Empty },
            { "1. Споры о заключении договоров(контрактов)", "1" },
            { "1.1. Споры о заключении договоров на поставку товаров, выполнение работ, оказание услуг для государственных и муниципальных нужд", "1.1" },
            { "2. Споры о признании договоров недействительными", "2" },
            { "3. Споры о неисполнении или ненадлежащем исполнении обязательств по договорам купли-продажи", "3" },
            { "3.1. Споры о неисполнении или ненадлежащем исполнении обязательств по договорам поставки", "3.1" },
            { "3.1.1. Споры о неисполнении или ненадлежащем исполнении обязательств по договорам поставки товаров для государственных и муниципальных нужд", "3.1.1" },
            { "3.2. Споры о неисполнении или ненадлежащем исполнении обязательств по договорам энергоснабжения", "3.2" },
            { "3.3. Споры о неисполнении или ненадлежащем исполнении обязательств по договорам купли-продажи недвижимости и предприятий", "3.3" },
            { "4. Споры о неисполнении или ненадлежащем исполнении обязательств по договорам аренды", "4" },
            { "4.1. Споры о неисполнении или ненадлежащем исполнении обязательств по договорам финансовой аренды (лизинга)", "4.1" },
            { "5. Споры о неисполнении или ненадлежащем исполнении обязательств по договорам подряда", "5" },
            { "5.1. Споры о неисполнении или ненадлежащем исполнении обязательств по договорам строительного подряда6. Споры о неисполнении или ненадлежащем исполнении обязательств по договорам долевого участия в строительстве", "5.1" },
            { "7. Споры о неисполнении или ненадлежащем исполнении обязательств по договорам в сфере транспортной деятельности", "7" },
            { "7.1. Споры о неисполнении или ненадлежащем исполнении обязательств по договорам перевозки", "7.1" },
            { "7.1.1. Споры о неисполнении или ненадлежащем исполнении обязательств по договорам международной перевозки", "7.1.1" },
            { "7.2. Споры о неисполнении или ненадлежащем исполнении обязательств по договорам транспортной экспедиции", "7.2" },
            { "8. Споры о неисполнении или ненадлежащем исполнении обязательств по договорам займа и кредита", "8" },
            { "9. Споры о неисполнении или ненадлежащем исполнении обязательств по договорам банковского счета, при осуществлении расчетов", "9" },
            { "9.2. о привлечении к админ. ответственности за недобросовестную конкуренцию", "9.2" },
            { "10. Споры о неисполнении или ненадлежащем исполнении обязательств по договорам страхования", "10" },
            { "11. Споры о неисполнении или ненадлежащем исполнении обязательств по договорам хранения", "11" },
            { "12. Споры о неисполнении или ненадлежащем исполнении обязательств по договорам возмездного оказания услуг", "12" },
            { "13. Споры о неисполнении или ненадлежащем исполнении обязательств по посредническим договорам", "13" },
            { "14. Споры о неисполнении или ненадлежащем исполнении обязательств по иным видам договоров", "14" },
            { "16. Корпоративные споры", "16" },
            { "16.1. Споры, связанные с созданием, реорганизацией и ликвидацией юридических лиц", "16.1" },
            { "16.2. Споры, связанные с принадлежностью акций и долей участия, установлением их обременений и реализацией вытекающих из них прав", "16.2" },
            { "16.3. Споры по искам участников юридического лица о возмещении убытков, причиненных юрлицу", "16.3" },
            { "16.4. Споры о признании недействительными сделок, совершенных юр. лицом, и (или) применении последствий недействительности таких сделок", "16.4" },
            { "16.5. Споры, связанные с назначением или избранием, прекращением, приостановлением полномочий и ответственностью лиц, входящих в состав органов управления, в т.ч. между указанными лицами и юр. лицом", "16.5" },
            { "16.6. Споры, связанные с эмиссией ценных бумаг", "16.6" },
            { "16.6.1. Споры, связанные с оспариванием ненормативных правовых актов, решений госорганов, органов местного самоуправления, иных органов, должностных лиц, органов управления эмитента", "16.6.1" },
            { "16.6.2. Споры, связаные с эмиссией ценных бумаг, об оспаривании сделок, совершен. в процессе размещения эмис. ценных бумаг, отчетов об итогах их выпуска", "16.6.2" },
            { "16.7. Споры, вытекающие из деятельности держателей реестра владельцев ценных бумаг", "16.7" },
            { "16.8. Споры о созыве общего собрания участников юридического лица", "16.8" },
            { "16.9. Споры об обжаловании решений органов управления юридического лица", "16.9" },
            { "16.10. Споры, вытекающие из деятельности нотариусов по удостоверению сделок с долями в уставном капитале ООО", "16.10" },
            { "17. Споры о ценных бумагах", "17" },
            { "17.1. Споры о ненадлежащем исполнении и возмещении убытков", "17.1" },
            { "17.2. Спор, по вопросам вытекающим из деятельности депозитариев", "17.2" },
            { "18. Споры, связанные с защитой права собственности, иных вещных прав", "18" },
            { "18.1. Споры о признании права собственности", "18.1" },
            { "18.2. Споры об истребовании имущества из чужого незаконного владения", "18.2" },
            { "18.3. Споры об устранении нарушений прав собственника, не связанных с лишением владения", "18.3" },
            { "19. Споры о защите деловой репутации", "19" },
            { "20. Споры, связанные с охраной интеллектуальной собственности", "20" },
            { "20.1. Споры об обжаловании решений Роспатента", "20.1" },
            { "20.1.1. Споры об обжаловании решений Роспатента по товарным знакам", "20.1.1" },
            { "20.1.2. Споры об обжаловании решений Роспатента по изобретениям, полезным моделям, промышленным образцам", "20.1.2" },
            { "20.1.3. Споры об обжаловании решений Роспатента по патентам на селекционное достижение", "20.1.3" },
            { "20.1.4. Споры об обжаловании решений уполномоченных органов Правительством РФ по рассмотрению заявки на выдачу патента на секретные изобретения", "20.1.4" },
            { "20.2. Споры о защите исключительных прав", "20.2" },
            { "20.2.1. Споры о защите авторских и смежных прав", "20.2.1" },
            { "20.2.1.1. о защите авторских прав", "20.2.1.1" },
            { "20.2.1.2. о защите смежных прав", "20.2.1.2" },
            { "20.2.2. Споры о защите патентных прав", "20.2.2" },
            { "20.2.2.1. о праве прежде- и послепользования", "20.2.2.1" },
            { "20.2.3. Споры о защите исключительных прав, связанных с нарушением селекционных достижений", "20.2.3" },
            { "20.2.4. Споры о защите исключительных прав на топологии интегральных микросхем", "20.2.4" },
            { "20.2.5. Споры о защите исключительных прав на секрет производства (ноу-хау)", "20.2.5" },
            { "20.2.6. Споры о защите исключительных прав на средства индивидуализации", "20.2.6" },
            { "20.2.6.1. Споры о защите исключительных прав на товарные знаки", "20.2.6.1" },
            { "20.2.6.2. Споры о защите исключительных прав на фирменные наименования", "20.2.6.2" },
            { "20.2.6.3. Споры связанные с защитой нарушенных или оспоренных прав на наименование мест происхождения товаров ", "20.2.6.3" },
            { "20.2.6.4. Споры связанные с защитой нарушенных или оспоренных прав на коммерческие обозначения", "20.2.6.4" },
            { "20.2.7. Споры связанные с защитой нарушенных или оспоренных прав на возмещение убытков", "20.2.7" },
            { "20.2.8. Споры связанные с защитой нарушенных или оспоренных прав на взыскание компенсации", "20.2.8" },
            { "20.2.9. Споры связанные с защитой нарушенных или оспоренных прав на конфискации контрафактных экземпляров", "20.2.9" },
            { "20.2.10. Споры связанные с защитой нарушенных или оспоренных прав на конфискацию оборудования", "20.2.10" },
            { "20.2.11. Споры связанные с защитой нарушенных или оспоренных прав на ликвидацию", "20.2.11" },
            { "20.3. Споры о присуждении компенсации за нарушение права на судопроизводство в разумные сроки", "20.3" },
            { "20.3.1. Споры о присуждении компенсации за нарушение права на судопроизводство в разумные сроки, по делам, рассмотренным Судом по интеллектуальным правам", "20.3.1" },
            { "20.3.2. о признании договоров недействительными", "20.3.2" },
            { "20.3.3. о неисполнении или ненадлежащем исполнении обязательств по договорам", "20.3.3" },
            { "20.4. Споры о присуждении компенсации за нарушение права на исполнение суд. акта в разумные сроки", "20.4" },
            { "20.4.1. Споры о присуждении компенсации за нарушение права на исполнение суд. акта в разумные сроки, по делам, рассмотренным Судом по интеллектуальным правам", "20.4.1" },
            { "20.5. Споры по иным основаниям", "20.5" },
            { "20.5.1. Споры связанные с принятием обеспечительных мер", "20.5.1" },
            { "20.5.2. Споры связанные с совершением исполнительных действий", "20.5.2" },
            { "20.5.3. Споры связанные с возвращением заявления, искового заявления, апелляционной или кассационной жалобы", "20.5.3" },
            { "20.6. Споры об оспаривании постановлений административных органов о привлечении к административной ответственности (ч. 2 ст. 14.33 КоАП РФ)", "20.6" },
            { "21. Споры, вытекающие из внедоговорных обязательств", "21" },
            { "21.1. Споры о возмещении вреда", "21.1" },
            { "21.1.1. Споры о возмещении вреда, причиненного федеральными государственными органами", "21.1.1" },
            { "21.1.1.1. Споры о возмещении вреда, причиненного судебным приставом-исполнителем", "21.1.1.1" },
            { "21.1.2. Споры о возмещении вреда, причиненного государственными органами субъектов РФ", "21.1.2" },
            { "21.1.3. Споры о возмещении вреда, причиненного органами местного самоуправления", "21.1.3" },
            { "21.1.4. Споры о возмещении вреда в связи с обеспечением иска", "21.1.4" },
            { "21.1.4.1. Споры о возмещении вреда в связи с обеспечением иска, в случае оставления иска без рассмотрения", "21.1.4.1" },
            { "21.1.4.2. Споры о возмещении вреда в связи с обеспечением иска, в случае прекращения производства по делу", "21.1.4.2" },
            { "21.2. Споры о неосновательном обогащении, вытекающем из внедоговорных обязательств", "21.2" },
            { "22. Споры, связанные с применением бюджетного законодательства", "22" },
            { "22.1. Споры о нецелевом использовании бюджетных средств", "22.1" },
            { "22.1.1. Споры о нецелевом использовании средств федерального бюджета", "22.1.1" },
            { "22.2. Споры, возникшие в связи с предоставлением юридическому лицу бюджетных средств на возвратной и возмездной основе", "22.2" },
            { "22.3. Споры об обжаловании действий (бездействия) органов, исполняющих судебные акты", "22.3" },
            { "22.4. Споры о взыскании убытков из средств соответствующего бюджета, связанных с реализацией законов о предоставлении льгот отдельным категориям граждан", "22.4" },
            { "23. Споры о создании, реорганизации и ликвидации организаций", "23" },
            { "23.1. Споры о создании, реорганизации и ликвидации организаций на основании исков налоговых органов", "23.1" },
            { "24. Споры о государственной регистрации", "24" },
            { "24.1. Споры о государственной регистрации юр.лиц и ИП", "24.1" },
            { "24.1.1. Споры о признании недействительной государственной регистрации юридических лиц и индивидуальных предпринимателей", "24.1.1" },
            { "24.1.2. Споры об обжаловании отказа в государственной регистрации юридических лиц и индивидуальных предпринимателей", "24.1.2" },
            { "24.1.3. Споры об уклонении от государственной регистрации юридических лиц и индивидуальных предпринимателей", "24.1.3" },
            { "24.2. Споры о государственной регистрации прав на недвижимое имущество", "24.2" },
            { "24.2.1. Споры по делам об оспаривании зарегистрированных прав на недвижимое имущество и сделок с ним", "24.2.1" },
            { "24.2.2. Споры об обжаловании отказа в государственной регистрации прав на недвижимое имущество и сделок с ним", "24.2.2" },
            { "24.2.3. Споры об уклонении от государственной регистрации прав на недвижимое имущество и сделок с ним", "24.2.3" },
            { "24.3. Об уклонении от государственной регистрации юридических лиц и индивидуальных предпринимателей", "24.3" },
            { "24.4. Об оспаривании зарегистрированных прав на недвижимое имущество и сделок с ним", "24.4" },
            { "24.5. Об обжаловании отказа в государственной регистрации прав на недвижимое имущество и сделок с ним", "24.5" },
            { "24.6. Об уклонении от государственной регистрации прав на недвижимое имущество и сделок с ним", "24.6" },
            { "25. Споры, связанные с применением налогового законодательства", "25" },
            { "25.1. Споры по делам об оспаривании нормативных правовых актов в сфере налогов и сборов", "25.1" },
            { "25.2. Споры по делам об оспаривании ненормативных актов налоговых органов и действий (бездействия) должностных лиц", "25.2" },
            { "25.2.1. Споры по делам об оспаривании ненормативных актов налоговых органов в связи с отказом в возмещении НДС", "25.2.1" },
            { "25.3. Споры о взыскании обязательных платежей и санкций по налогам и сборам", "25.3" },
            { "25.3.1. Споры о взыскании обязательных платежей и санкций на основании п. 3 ст. 46 НК РФ", "25.3.1" },
            { "25.4. Споры о возврате из бюджета средств, излишне взысканных налоговыми органами либо излишне уплаченных налогоплательщиками", "25.4" },
            { "25.4.1. Споры о возврате из федерального бюджета средств, излишне взысканных налоговыми органами, либо излишне уплаченных", "25.4.1" },
            { "25.5. Споры о возмещении убытков, причиненных незаконными решениями налоговых органов или незаконными действиями (бездействием) их должностных лиц", "25.5" },
            { "26. Споры, связанные с применением таможенного законодательства", "26" },
            { "26.1. Споры по делам об оспаривании нормативных правовых актов в области таможенного дела", "26.1" },
            { "26.2. Споры по делам об оспаривании ненормативных правовых актов таможенных органов и действий (бездействия) должностных лиц", "26.2" },
            { "26.3. Споры о взыскании таможенных пошлин, налогов", "26.3" },
            { "26.4. Споры о возмещении убытков или вреда, причиненных таможенными органами лицам или их имуществу", "26.4" },
            { "27. Споры, связанные с применением законодательства об охране окружающей среды", "27" },
            { "27.1. Споры по делам об оспаривании ненормативных правовых актов, связанных с применением законодательства об охране окружающей среды", "27.1" },
            { "27.2. Споры о возмещении вреда, причиненного в результате нарушений законодательства об охране окружающей среды", "27.2" },
            { "28. Споры, связанные с применением законодательства о земле", "28" },
            { "28.1. Споры по делам об оспаривании ненормативных правовых актов, связанных с применением законодательства о земле", "28.1" },
            { "28.1.1. Споры об изъятии, прекращении или ограничении права на земельный участок", "28.1.1" },
            { "28.2. Споры о признании права собственности на землю", "28.2" },
            { "28.3. Споры об истребовании земельного участка из чужого незаконного владения", "28.3" },
            { "28.4. Споры об устранении нарушений прав собственника на землю, не связанных с лишением владения", "28.4" },
            { "28.5. Споры, возникающие в связи с неисполнением или ненадлежащим исполнением обязательств из совершения сделок с землей", "28.5" },
            { "28.5.1. Споры, возникающие в связи с неисполнением или ненадлежащим исполнением обязательств из совершения с землей сделок купли-продажи", "28.5.1" },
            { "28.5.2. Споры, возникающие в связи с неисполнением или ненадлежащим исполнением обязательств из совершения с землей сделок аренды", "28.5.2" },
            { "29. Споры, связанные с применением антимонопольного законодательства", "29" },
            { "29.1. Споры по искам антимонопольных органов об оспаривании нормативных правовых актов", "29.1" },
            { "29.1.1. Споры по искам антимонопольных органов об оспаривании нормативных правовых актов федеральных государственных органов", "29.1.1" },
            { "29.1.2. Споры по искам антимонопольных органов об оспаривании нормативных правовых актов государственных органов субъектов РФ", "29.1.2" },
            { "29.1.3. Споры по искам антимонопольных органов об оспаривании нормативных правовых актов органов местного самоуправления", "29.1.3" },
            { "29.2. Споры по искам антимонопольных органов об оспаривании ненормативных правовых актов", "29.2" },
            { "29.2.1. Споры по искам антимонопольных органов об оспаривании ненормативных правовых актов федеральных государственных органов", "29.2.1" },
            { "29.2.2. Споры по искам антимонопольных органов об оспаривании ненормативных правовых актов государственных органов субъектов РФ", "29.2.2" },
            { "29.2.3. Споры по искам антимонопольных органов об оспаривании ненормативных правовых актов органов местного самоуправления", "29.2.3" },
            { "29.3. Споры по искам антимонопольных органов об обязании заключить договор", "29.3" },
            { "29.4. Споры по искам антимонопольных органов об изменении или расторжении договора", "29.4" },
            { "29.5. Споры по искам антимонопольных органов о ликвидации юридических лиц", "29.5" },
            { "29.6. Споры по искам антимонопольных органов о признании недействительными договоров", "29.6" },
            { "29.7. Споры по искам антимонопольных органов о признании торгов недействительными", "29.7" },
            { "29.8. Споры по искам антимонопольных органов о взыскании в федеральный бюджет необоснованного дохода (прибыли)", "29.8" },
            { "29.9. Споры о понуждении к исполнению решений и предписаний антимонопольного органа", "29.9" },
            { "29.10. Споры о запрете распространения рекламы, о публичном опровержении недостоверной рекламы", "29.10" },
            { "30. Споры по делам об оспаривании нормативных правовых актов", "30" },
            { "30.1. Споры по делам об оспаривании нормативных правовых актов федеральных государственных органов", "30.1" },
            { "30.2. Споры по делам об оспаривании нормативных правовых актов государственных органов субъектов РФ", "30.2" },
            { "30.3. Споры по делам об оспаривании нормативных правовых актов органов местного самоуправления", "30.3" },
            { "31. Споры об оспаривании ненормативных правовых актов, решений и действий (бездействия) государственных органов, органов местного самоуправления, иных органов, организаций, наделенных федеральным законом отдельными государственными или иными публичными полномочиями, должностных лиц", "31" },
            { "31.1. Споры по делам об оспаривании ненормативных правовых актов, решений и действий (бездействия) федеральных государственных органов", "31.1" },
            { "31.1.1. Споры по делам об оспаривании ненормативных правовых актов, решений и действий (бездействия) антимонопольных органов", "31.1.1" },
            { "31.1.1.1. по делам о нарушениях, указанных в п. 4 ч. 1 ст. 14 ФЗ \"О защите конкуренции\"", "31.1.1.1" },
            { "31.1.2. Споры по делам об оспаривании ненормативных правовых актов, решений и действий (бездействия) судебных приставов-исполнителей", "31.1.2" },
            { "31.2. Споры по делам об оспаривании ненормативных правовых актов, решений и действий (бездействия) государственных органов субъектов РФ", "31.2" },
            { "31.3. Споры по делам об оспаривании ненормативных правовых актов, решений и действий (бездействия) органов местного самоуправления", "31.3" },
            { "31.4. Споры по делам об оспаривании ненормативных правовых актов, решений и действий (бездействия) государственных внебюджетных органов", "31.4" },
            { "31.4.1. Споры по делам об оспаривании ненормативных правовых актов, решений и действий (бездействия) пенсионного фонда", "31.4.1" },
            { "32. Споры, связанные с применением законодательства об административных правонарушениях", "32" },
            { "32.1. Споры по делам об оспаривании решений административных органов о привлечении к административной ответственности", "32.1" },
            { "32.1.1. Споры по делам об оспаривании решений налоговых органов о привлечении к административной ответственности", "32.1.1" },
            { "32.1.2. Споры по делам об оспаривании решений таможенных органов о привлечении к административной ответственности", "32.1.2" },
            { "32.1.3. Споры по делам об оспаривании решений антимонопольных органов о привлечении к административной ответственности", "32.1.3" },
            { "32.1.4. Споры по делам об оспаривании решений органов, осуществляющих контроль за использованием земли, о привлечении к административной ответственности", "32.1.4" },
            { "32.1.5. Споры по делам об оспаривании решений органов, осуществляющих контроль в сфере охраны окружающей среды, о привлечении к административной ответственности", "32.1.5" },
            { "32.1.6. Споры по делам об оспаривании решений органов, уполномоченных в области финансовых рынков, о привлечении к административной ответственности", "32.1.6" },
            { "32.1.7. Споры по делам об оспаривании решений органов, осуществляющих функции по контролю и надзору в финансово-бюджетной сфере, о привлечении к административной ответственности", "32.1.7" },
            { "32.1.8. Споры по делам об оспаривании решений судебных приставов-исполнителей о привлечении к административной ответственности", "32.1.8" },
            { "32.1.9. Споры по делам об оспаривании решений органов Росалкогольрегулирования о привлечении к административной ответственности", "32.1.9" },
            { "32.2. Споры о привлечении к административной ответственности", "32.2" },
            { "32.2.1. Споры о привлечении к административной ответственности за нарушение требований по производству, обороту, продаже этилового спирта, алкогольной и спиртосодержащей продукции", "32.2.1" },
            { "32.2.2. Споры о привлечении к административной ответственности за осуществление предпринимательской деятельности без государственной регистрации или без лицензии", "32.2.2" },
            { "32.2.3. Споры о привлечении к административной ответственности за незаконное использование товарного знака", "32.2.3" },
            { "32.2.4. Споры о привлечении к административной ответственности за правонарушения, связанные с банкротством", "32.2.4" },
            { "32.2.5. Споры о привлечении к административной ответственности за нарушение требований проектной документации, порядка строительства, невыполнения в срок законного предписания органов по надзору в области строительства", "32.2.5" },
            { "32.2.6. Споры о привлечении к административной ответственности за злоупотребление доминирующим положением на товарном рынке", "32.2.6" },
            { "32.2.7. Споры о привлечении к административной ответственности за заключение ограничивающего конкуренцию соглашения, недобросовестную конкуренцию", "32.2.7" },
            { "32.2.8. Споры о привлечении к административной ответственности за непредставление документов о споре, связанном с созданием юрлица, управлением им или участия в нем, участникам юрлица", "32.2.8" },
            { "33. Споры о взыскании с организаций и граждан обязательных платежей и санкций, если не предусмотрен иной порядок их взыскания", "33" },
            { "33.1. Споры о взыскании по заявлениям Пенсионного фонда обязательных платежей и санкций с организаций и граждан", "33.1" },
            { "33.2. Споры о взыскании по заявлениям Фонда социального страхования обязательных платежей и санкций с организаций и граждан", "33.2" },
            { "34. Иные экономические споры", "34" },
            { "34.1. Споры по иным основаниям, с принятием обеспечительных мер", "34.1" },
            { "34.2. Споры по иным основаниям, с совершением исполнительных действий", "34.2" },
            { "34.3. Споры по иным основаниям, с возвратом заявлений, исковых  заявлений, апелляционных и кассационных жалоб", "34.3" },
            { "34.4. Споры по обжалованию решений (определений) по делам о присуждении компенсации за нарушение права на судопроизводство в разумный срок", "34.4" },
            { "34.5. Споры по обжалованию решений (определений) по делам о присуждении компенсации за нарушение права на исполнение судебного акта в разумный срок", "34.5" },
            { "35. Споры об установлении фактов, имеющих юридическое значение", "35" },
            { "36. Споры о несостоятельности (банкротстве)", "36" },
            { "36.1. Споры по введению процедур банкротства", "36.1" },
            { "36.2. Споры о результатах рассмотрения заявлений, жалоб, ходатайств, разногласий", "36.2" },
            { "36.3. Банкротство физического лица", "36.3" },
            { "37. Споры об оспаривании решений третейских судов", "37" },
            { "38. Споры о выдаче исполнительного листа на принудительное исполнение решения третейского суда", "38" },
            { "39. Споры о признании и приведении в исполнение решений иностранных судов и иностранных арбитражных решений", "39" },
            { "50. Споры по делам об оспаривании нормативных правовых актов Президента РФ", "50" },
            { "51. Споры по делам об оспаривании нормативных правовых актов Правительства РФ", "51" },
            { "52. Споры по дела об оспаривании нормативных правовых актов Федеральных органов исполнительной власти", "52" },
            { "53. Споры по делам об оспаривании ненормативных правовых актов Президента РФ", "53" },
            { "54.1. Дела об оспаривании ненормативных правовых актов Совета Федерации", "54.1" },
            { "54.2. Дела об оспаривании ненормативных правовых актов Государственной Думы", "54.2" },
            { "55. Споры по делам об оспаривании ненормативных правовых актов Правительства РФ", "55" },
            { "55.1. Споры по дела об оспаривании ненормативных правовых актов Совета Федерации", "55.1" },
            { "55.2. Споры по делам об оспаривании ненормативных правовых актов Государственной Думы", "55.2" },
            { "56. Экономические споры между Российской Федерацией и субъектами Российской Федерации", "56" },
            { "57. Экономические споры между субъектами Российской Федерации", "57" },
            { "58. споры между федеральными органами гос. власти и органами гос. власти субъектов РФ", "58" },
            { "59. споры между высшими органами государственной власти субъектов РФ", "59" },
            { "60.1. жалоба на решение ВККС и ККС о досрочном прекращении полномочий судей", "60.1" },
            { "60.2. жалоба на решение ВККС о наложении дисциплинарных взысканий", "60.2" },
            { "60.3. жалоба на решение ВККС о результатах квалификационной аттестации", "60.3" },
            { "60.4. обращение Председателя Верховного Суда Российской Федерации", "60.4" },
            { "60.5. обращение граждан и организаций на действие (бездействие) судей", "60.5" },
            { "71. об оспаривании нормативно-правовых актов федер. органов исп. власти в обл. правовой охраны рез-ов интеллект. деятельности и средств индивидуализации", "71" },
            { "71.1. об оспаривании норм. прав. актов федер. органов исп. власти в обл. правовой охраны патентных прав", "71.1" },
            { "71.2. об оспаривании норм. прав. актов федер. органов исп. власти в обл. правовой охраны прав на селекционные достижения", "71.2" },
            { "71.3. об оспаривании норм. прав. актов федер. органов исп. власти в обл. правовой охраны прав на топологии интегральных микросхем", "71.3" },
            { "71.4. об оспаривании норм. прав. актов федер. органов исп. власти в обл. правовой охраны прав на секреты производства (ноу-хау)", "71.4" },
            { "71.5. об оспаривании норм. прав. актов федер. органов исп. власти в обл. правовой охраны прав на средства индивидуализации юр. лиц, товаров, работ, услуг и предприятий", "71.5" },
            { "71.6. об оспаривании норм. прав. актов федер. органов исп. власти в обл. правовой охраны прав на использование рез-ов интеллект. деятельности", "71.6" },
            { "72. о предоставлении или прекращении правовой охраны рез-ов интеллект. деятельности и средств индивидуализации (за искл. объек-ов автор-их и смеж. прав, топологий интегр. микросхем)", "72" },
            { "72.1. об оспаривании ненормативных правовых актов, решений и действий (бездействия)", "72.1" },
            { "72.1.1. об оспаривании ненорм. правовых актов федер. органа испол. власти по интеллект. собственности", "72.1.1" },
            { "72.1.1.1. о признании недействительным патента на изобретение, полезную модель, пром. образец", "72.1.1.1" },
            { "72.1.1.2. об отказе в признании недействительным патента на изобретение, полезную модель, промышленный образец", "72.1.1.2" },
            { "72.1.1.3. о выдаче патента на изобретение, полезную модель, промышленный образец", "72.1.1.3" },
            { "72.1.1.4. о признании недействительным решения о предоставлении правовой охраны товарному знаку", "72.1.1.4" },
            { "72.1.1.5. об отказе в признании недействительным  решения о предоставлении прав. охраны товарному знаку, наименовванию места происхождения товара и о предоставлении исключительного права на такое наименование", "72.1.1.5" },
            { "72.1.2. об оспаривании ненорм. правовых актов федер. органа исп. власти по селекционным достижениям", "72.1.2" },
            { "72.1.2.2. об отказе в признании недействительным патента на селекционное достижение", "72.1.2.2" },
            { "72.1.3. об оспаривании ненорм. правовых актов органов, уполном-ных Правительством РФ рассм-ть заявки на выдачу патента на секретные изобретения", "72.1.3" },
            { "72.1.4. об оспаривании реш-ий федер. антимоноп-ого органа о признании недобросов-ной конкур-ией действий, связ-ых с приобрет-ем исключит. права на средства индивидуализации", "72.1.4" },
            { "72.2. об установлении патентообладателя", "72.2" },
            { "72.3. о досрочном прекращении правовой охраны товарного знака вследствие его неиспользования", "72.3" },
            { "73. о возмещении вреда", "73" }
        };

        private static string[] names = categories.Keys.ToArray();
        public string[] Names
        {
            get => names;
        }

        public string GetCode(string CategoryName)
        {
            return categories.GetValueOrDefault(CategoryName);
        }
    }
}
