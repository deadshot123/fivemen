create table myusers(id integer primary key autoincrement,name varchar(30),pwd varchar(50),rightstr varchar(60));
create table mydicts(id integer primary key autoincrement,dicttype integer,dictvalue varchar(200),dicttext varchar(200));
create table receiverecord(id integer primary key autoincrement,receiveno varchar(50),factory varchar(200),factoryid varchar(20),storage varchar(200),storageid varchar(20),carno varchar(30),receivetype varchar(10),qufen varchar(20),pnno varchar(20),tno varchar(20),hold varchar(20),sl integer,scaner varchar(30),scantime datetime,status integer);
create table receivedetail(id integer primary key autoincrement,receiveno varchar(50),pnno varchar(20),tno varchar(20),hold varchar(20),cuno varchar(20),xxjh varchar(20),scaner varchar(30),scantime datetime,status integer);
create table zutuo(id integer primary key autoincrement,tph varchar(20),sn varchar(20),xxjh varchar(20),scaner varchar(30),scantime datetime);
create table jietuo(id integer primary key autoincrement,tph varchar(20),sn varchar(20),iswhole integer,scaner varchar(30),scantime datetime);
create table sendrecord(id integer primary key autoincrement,so varchar(20),otherso varchar(200),qufen varchar(20),pnno varchar(20),cpqufen varchar(20),sl integer,carno varchar(30),status integer,scaner varchar(30),scantime datetime);
create table senddetail(id integer primary key autoincrement,so varchar(20),sn varchar(20),fahuotype integer,xxjh varchar(20),tph varchar(20),scaner varchar(30),scantime datetime,status integer);
create table pandianrecord(id integer primary key autoincrement,kw varchar(20),pnno varchar(20),cpqufen varchar(20),sl integer,status integer,scaner varchar(30),scantime datetime);
create table pandiandetail(id integer primary key autoincrement,sn varchar(20),xxjh varchar(20),tph varchar(20),scaner varchar(30),scantime datetime,kuwei varchar(20));
create table kuweiinfo(id integer primary key autoincrement,kuweicode varchar(20),fenqucode varchar(20),status integer);
create table yiku(id integer primary key autoincrement,ykw varchar(20),cp varchar(20),sl integer,mdkw varchar(20),scaner varchar(30),scantime datetime,tph varchar(20));
create table pintuo(id integer primary key autoincrement,tph varchar(20),sn varchar(20),wz varchar(30),xxjh varchar(20),scaner varchar(30),scantime datetime,ytph varchar(20));
