create database fisioclin;
use fisioclin;

--------------------------------------------------------------------------------
-- TABELA PACIENTE
--------------------------------------------------------------------------------
#armazenda os dados do paciente
create table paciente (
    id_pac int not null auto_increment primary key,
    #atentar-se para os not null e os unique, os unique são para nao deixar cadastrar 2 iguais, então tem que criar uma logica para evitar isso
    nome_pac varchar(200) not null,
    cpf_pac varchar(15),
    rg_pac varchar(20),
    data_nascimento_pac date,
    sexo_pac varchar(10),
    telefone_pac varchar(20),
    email_pac varchar(200),
    cep_pac varchar(20),
    rua_pac varchar(200),
    numero_pac varchar(20),
    bairro_pac varchar(200)
);
#SELECT *FROM paciente;

--------------------------------------------------------------------------------
-- TABELA CARGO
--------------------------------------------------------------------------------
#armazena os dados referente as funções de cada FUNCIONARIO
create table cargo (
    id_car int not null auto_increment primary key,
    nome_car varchar(200) not null,
    departamento_car varchar(200),
    descricao_car varchar(300),
    carga_horaria_car int,
    data_criacao_car date,
    data_atualizacao_car date,
    observacoes_car varchar(200)
);

--------------------------------------------------------------------------------
-- TABELA FUNCIONARIO
--------------------------------------------------------------------------------
#armazena os dados de cada funcionario
create table funcionario (
    id_fun int not null auto_increment primary key,
    nome_fun varchar(200) not null,
    cpf_fun varchar(14),
    rg_fun varchar(20),
    data_nascimento_fun date,
    telefone_fun varchar(20),
    email_fun varchar(200),
    tipo_vinculo_fun varchar(100),
    registro_profissional_fun varchar(200),
    especialidade_fun varchar(200),
    subespecialidade_fun varchar(200),
    certificados_fun varchar(200),
    data_contratacao_fun date,
    id_car_fk int null,
    foreign key (id_car_fk) references cargo(id_car) on delete set null
);

--------------------------------------------------------------------------------
-- TABELA SALA
--------------------------------------------------------------------------------
#armazena as informações de cada sala de atendimento
create table sala (
    id_sal int not null auto_increment primary key,
    nome_sal varchar(200) not null,
    numero_sal varchar(50),
    capacidade_sal int,
    tipo_sal varchar(200),
    disponibilidade_sal enum('disponivel','ocupada') default 'disponivel',
    observacao_sal varchar(300)
);
#default é sobre valor padrao, se nao passar nada ele usa o padrao
insert into sala values (null, 'fisioterapia', 1, 3, 'não sei', default, 'sala aberta');


--------------------------------------------------------------------------------
-- TABELA SESSAO
--------------------------------------------------------------------------------
#dados de cada consulta
create table sessao (
    id_ses int not null auto_increment primary key,
    data_ses date not null,
    horario_ses time not null,
    tipo_ses varchar(200),
    observacao_ses varchar(200),
    id_pac_fk int null,
    id_fun_fk int null,
    id_sal_fk int null,
    foreign key (id_pac_fk) references paciente(id_pac) on delete set null,
    foreign key (id_fun_fk) references funcionario(id_fun) on delete set null,
    foreign key (id_sal_fk) references sala(id_sal) on delete set null
);

--------------------------------------------------------------------------------
-- TABELA AGENDA
--------------------------------------------------------------------------------
#dados de consultas agendadas, aqui vc verifica se ja existe naquele horario uma sala ou funcionario ocupado
create table agenda (
    id_age int not null auto_increment primary key,
    data_age date,
    horario_age time,
    id_sal_fk int null,
    id_fun_fk int null,
    observacao_age varchar(200),
    foreign key (id_sal_fk) references sala(id_sal) on delete set null,
    foreign key (id_fun_fk) references funcionario(id_fun) on delete set null
);

--------------------------------------------------------------------------------
-- LOGIN PACIENTE
--------------------------------------------------------------------------------
create table login_paciente (
    id_lop int not null auto_increment primary key,
    email_lop varchar(200) not null,
    senha_lop varchar(200) not null,
    id_pac_fk int null,
    foreign key (id_pac_fk) references paciente(id_pac) on delete set null
);

--------------------------------------------------------------------------------
-- LOGIN FUNCIONARIO
--------------------------------------------------------------------------------
create table login_funcionario (
    id_lof int not null auto_increment primary key,
    email_lof varchar(200) not null,
    senha_lof varchar(200) not null,
    id_fun_fk int null,
    foreign key (id_fun_fk) references funcionario(id_fun) on delete set null
);


