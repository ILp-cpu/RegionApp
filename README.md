Net.Core 2.2 + MS SQL

Структура солюшена (WebApplication8):

TelerikRegionCoreClient - клиентская часть
RegionApi - WebApi Core - доступ через апи к данным
RegionContext - контекст БД
RegionService - сервисы доступа к данным (на самом деле репозитории
RegionModel - вспомогательный проект для Моделей данных


Приложенные файлы:
test_reg.bak -бекап БД
sql.txt - скрипт создания таблиц и данных
region_1.jpg - скриншоты приложения (на случай, если не захотите запускать, поднимать бекап итд)
region_2.jpg
region_3.jpg


Т.к. не писал до этого на Core, большая часть времени ушло на создание инфраструктуры, а не на само задание. 
Поначалу версия Core 3. не хотела работать в принципе (не видела зависимости), потом сложности были с Kendo.
В итоге после серии апдейтов заработала 2.2, на ней решил и остановится.

Создана БД - потом через DataBase First  EF сгенерировала сущности, скоторыми потом и работал.
(на самом деле, наверное лучше было бы использовать Code First, но раз начал, не стал переделывать)

Проект RegionService тут, возможно, тоже лишний, его поидее можно объединить с RegionContext, но в итоге оставил.

Приложение осуществляет показ данных маршрутов.
Клиентская часть через WEB API получает необходимые данные. 
WEb API  в свою очередь через зависимость сервисов обращается к БД и предоставляет доступ к данным.

редактирование не стал делать, потому как впринципе тоже самое. Обращение к контроллеру и дальше WEb Api.
Затем на клиенте событие grid.dataSourse.read() для пересчета итоговых данных.

Если это необходимо, могу сделать.


Насчет расчета итоговых данных, сделано через Linq. 
Впринципе, считаю, лучшим вариантом - когда большие данные - сделать через t-sql вьюху c расчетом результатов для первых двух уровней (либо даже для трех, надо смотреть).
Либо хранимку. Мне кажется так будет быстрее в итоге. Но это обсуждаемо.

В коде есть прописаные адреса (web API, конекшн стринг), конечно это выносится в web.config или чтото подобное. Просто для текущего задания посчитал это не особо важным. Делал быстро.

TelerikRegionCoreClient связь с WebApi через Helper/helper.cs (client.BaseAddress = new Uri("http://localhost:27037/");)
WebApi через Startup.cs задает сонекшн стринг для контекста БД



