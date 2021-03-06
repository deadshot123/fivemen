create table ASNRecord(id integer primary key ,ASN VARCHAR2(50),FactoryId VARCHAR2(20),StorageId VARCHAR2(20),Carno VARCHAR2(30),ASNtype VARCHAR2(10),Different VARCHAR2(20),PN VARCHAR2(20),PlantNo VARCHAR2(20),HOLD VARCHAR2(20),Qty integer,scaner VARCHAR2(30),scantime DATE,status integer);
create table ASNDetail(id integer primary key ,ASN VARCHAR2(50),PN VARCHAR2(20),PlantNo VARCHAR2(20),HOLD VARCHAR2(20),SN VARCHAR2(20),xxjh VARCHAR2(20),scaner VARCHAR2(30),scantime DATE,status integer);
create table MoveLoc(id integer primary key     ,PlantNo VARCHAR2(20),OldLoc VARCHAR2(20),SN VARCHAR2(20),Qty integer,NewLoc VARCHAR2(20),scaner VARCHAR2(30),scantime DATE);
create table BuildPlant(id integer primary key         ,PlantNo VARCHAR2(20),SN VARCHAR2(20),xxjh VARCHAR2(20),scaner VARCHAR2(30),scantime DATE);
create table SplitPlant(id integer primary key        ,PlantNo VARCHAR2(20),SN VARCHAR2(20),IsWhole integer,scaner VARCHAR2(30),scantime DATE);
create table AssemblePlant(id integer primary key        ,OldPlant VARCHAR2(20),NewPlant VARCHAR2(20),SN VARCHAR2(20),Position VARCHAR2(30),xxjh VARCHAR2(20),scaner VARCHAR2(30),scantime DATE);
create table ShipmentRecord(id integer primary key    ,SO VARCHAR2(20),OtherSO VARCHAR2(200),Different VARCHAR2(20),PN VARCHAR2(20),ProductDifferent VARCHAR2(20),Qty integer,CarNo VARCHAR2(30),status integer,scaner VARCHAR2(30),scantime DATE);
create table ShipmentDetail(id integer primary key    ,SO VARCHAR2(20),SN VARCHAR2(20),ShipmentType integer,xxjh VARCHAR2(20),PlantNo VARCHAR2(20),scaner VARCHAR2(30),scantime DATE,status integer);
create table CheckRecord(id integer primary key ,LOC VARCHAR2(20),PN VARCHAR2(20),ProductDifferent VARCHAR2(20),Qty integer,status integer,scaner VARCHAR2(30),scantime DATE);
create table CheckDetail(id integer primary key ,SN VARCHAR2(20),xxjh VARCHAR2(20),PlantNo VARCHAR2(20),scaner VARCHAR2(30),scantime DATE,loc VARCHAR2(20));
