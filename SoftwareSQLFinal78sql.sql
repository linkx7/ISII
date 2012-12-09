create database is2atencionmedica
use is2atencionmedica
use master
/*==============================================================*/
/* Table: ESPECIALIDAD                                          */
/*==============================================================*/
create table ESPECIALIDAD (
   IDESPECIALIDAD       int  identity                 not null,
   NOMBREESPECIALIDAD   varchar(20)          null,
   constraint PK_ESPECIALIDAD primary key nonclustered (IDESPECIALIDAD)
)
go

/*==============================================================*/
/* Table: HISTORIACLINICA                                       */
/*==============================================================*/
create table HISTORIACLINICA (
   IDHISTORIACLINICA    int          identity        not null,
   IDPACIENTE           int                  null,
   CODIGOHISTORIACLINICA varchar(10)          null,
   TIPOSANGRE           varchar(10)          null,
   ALERGIA              varchar(50)          null,
   constraint PK_HISTORIACLINICA primary key nonclustered (IDHISTORIACLINICA)
)
go

/*==============================================================*/
/* Table: HOJAATENCION                                          */
/*==============================================================*/
create table HOJAATENCION (
   IDHOJAATENCION       int             identity     not null,
   IDTURNO              int                  null,
   IDHISTORIACLINICA    int                  null,
   CODIGOHOJAATENCION   char(10)             null,
   HORAATENCION         datetime             null,
   SINTOMAS             char(100)            null,
   DIAGNOSTICO          char(40)             null,
   PRESCRIPCION         char(100)            null,
   constraint PK_HOJAATENCION primary key nonclustered (IDHOJAATENCION)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_3_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_3_FK on HOJAATENCION (
IDTURNO ASC
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_4_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_4_FK on HOJAATENCION (
IDHISTORIACLINICA ASC
)
go

/*==============================================================*/
/* Table: HORARIO                                               */
/*==============================================================*/
create table HORARIO (
   IDHORARIO            int           identity       not null,
   IDMEDICO             int                  null,
   FECHA                datetime             not null,
   HORA                 varchar(6)           not null,
   ESTADO               varchar(10)          not null,
   constraint PK_HORARIO primary key nonclustered (IDHORARIO)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_5_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_5_FK on HORARIO (
IDMEDICO ASC
)
go

/*==============================================================*/
/* Table: LOGIN                                                 */
/*==============================================================*/
create table LOGIN (
   IDLOGIN              int             identity     not null,
   USUARIO              varchar(12)          null,
   CONTRASENIA          varchar(15)          null,
   constraint PK_LOGIN primary key nonclustered (IDLOGIN)
)
go

/*==============================================================*/
/* Table: MEDICO                                                */
/*==============================================================*/
create table MEDICO (
   IDMEDICO             int             identity     not null,
   IDESPECIALIDAD       int                  null,
   EXTMEDICO            int                  null,
   CEDULAMEDICO         varchar(10)          null,
   NOMBRESMEDICO        varchar(50)          null,
   APELLIDOSMEDICO      varchar(50)          null,
   DIRECCIONMEDICO      varchar(60)          null,
   ESTADOCIVILMEDICO    varchar(10)          null,
   EMAILMEDICO          varchar(40)          null,
   SEXOMEDICO           varchar(10)          null,
   ESTADOMEDICO         varchar(15)			 null,
   constraint PK_MEDICO primary key nonclustered (IDMEDICO)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_6_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_6_FK on MEDICO (
IDESPECIALIDAD ASC
)
go

/*==============================================================*/
/* Table: PACIENTE                                              */
/*==============================================================*/
create table PACIENTE (
   IDPACIENTE           int            identity      not null,
   CEDULAPACIENTE       varchar(10)          null,
   NOMBRESPACIENTE      varchar(50)          null,
   APELLIDOSPACIENTE    varchar(50)          null,
   DIRECCIONPACIENTE    varchar(60)          null,
   ESTADOCIVILPACIENTE  varchar(10)          null,
   TELEFONOPACIENTE     varchar(12)          null,
   EMAILPACIENTE        varchar(40)          null,
   SEXOPACIENTE         varchar(10)          null,
   FECHANACIMIENTO      datetime             null,
   constraint PK_PACIENTE primary key nonclustered (IDPACIENTE)
)
go

/*==============================================================*/
/* Table: SECRETARIA                                            */
/*==============================================================*/
create table SECRETARIA (
   IDSECRETARIA         int            identity      not null,
   CEDULASECRETARIA     varchar(10)          null,
   NOMBRESSECRETARIA    varchar(50)          null,
   APELLIDOSSECRETARIA  varchar(50)          null,
   DIRECCIONSECRETARIA  varchar(60)          null,
   ESTADOCIVILSECRETARIA varchar(10)          null,
   EMAILSECRETARIA      varchar(40)          null,
   constraint PK_SECRETARIA primary key nonclustered (IDSECRETARIA)
)
go

/*==============================================================*/
/* Table: TURNO                                                 */
/*==============================================================*/
create table TURNO (
   IDTURNO              int          identity        not null,
   IDPACIENTE           int                  null,
   FECHAASIGNADA        datetime             null,
   HORAASIGNADA         varchar(6)           null,
   FECHAEMISIONCOMPROBANTE datetime             null,
   constraint PK_TURNO primary key nonclustered (IDTURNO)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_1_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_1_FK on TURNO (
IDPACIENTE ASC
)
go

alter table HISTORIACLINICA
   add constraint FK_HISTORIA_REFERENCE_PACIENTE foreign key (IDPACIENTE)
      references PACIENTE (IDPACIENTE)
go

alter table HOJAATENCION
   add constraint FK_HOJAATEN_RELATIONS_TURNO foreign key (IDTURNO)
      references TURNO (IDTURNO)
go

alter table HOJAATENCION
   add constraint FK_HOJAATEN_RELATIONS_HISTORIA foreign key (IDHISTORIACLINICA)
      references HISTORIACLINICA (IDHISTORIACLINICA)
go

alter table HORARIO
   add constraint FK_HORARIO_RELATIONS_MEDICO foreign key (IDMEDICO)
      references MEDICO (IDMEDICO)
go

alter table MEDICO
   add constraint FK_MEDICO_RELATIONS_ESPECIAL foreign key (IDESPECIALIDAD)
      references ESPECIALIDAD (IDESPECIALIDAD)
go

alter table TURNO
   add constraint FK_TURNO_RELATIONS_PACIENTE foreign key (IDPACIENTE)
      references PACIENTE (IDPACIENTE)
go

insert into LOGIN values('admin','admin')
insert into LOGIN values('secre','secre')
