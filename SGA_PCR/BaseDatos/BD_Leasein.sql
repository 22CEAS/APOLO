DROP DATABASE  IF EXISTS bd_leasein;
CREATE DATABASE bd_leasein;

use bd_leasein;

DROP TABLE IF EXISTS `bd_leasein`.`auxiliar`;
DROP TABLE IF EXISTS `bd_leasein`.`cambio`;
DROP TABLE IF EXISTS `bd_leasein`.`categoria`;
DROP TABLE IF EXISTS `bd_leasein`.`cliente`;
DROP TABLE IF EXISTS `bd_leasein`.`cliente_sucursal`;
DROP TABLE IF EXISTS `bd_leasein`.`cuota`;
DROP TABLE IF EXISTS `bd_leasein`.`devolucion`;
DROP TABLE IF EXISTS `bd_leasein`.`devolucion_det`;
DROP TABLE IF EXISTS `bd_leasein`.`disco_duro`;
DROP TABLE IF EXISTS `bd_leasein`.`disco_lc`;
DROP TABLE IF EXISTS `bd_leasein`.`estados`;
DROP TABLE IF EXISTS `bd_leasein`.`factura`;
DROP TABLE IF EXISTS `bd_leasein`.`ingreso`;
DROP TABLE IF EXISTS `bd_leasein`.`ingreso_det`;
DROP TABLE IF EXISTS `bd_leasein`.`ingreso_det_accesorios`;
DROP TABLE IF EXISTS `bd_leasein`.`laptop_cpu`;
DROP TABLE IF EXISTS `bd_leasein`.`licencia`;
DROP TABLE IF EXISTS `bd_leasein`.`marca`;
DROP TABLE IF EXISTS `bd_leasein`.`memoria`;
DROP TABLE IF EXISTS `bd_leasein`.`memoria_lc`;
DROP TABLE IF EXISTS `bd_leasein`.`modelo`;
DROP TABLE IF EXISTS `bd_leasein`.`observacion_deudas`;
DROP TABLE IF EXISTS `bd_leasein`.`orden_compra`;
DROP TABLE IF EXISTS `bd_leasein`.`pedido`;
DROP TABLE IF EXISTS `bd_leasein`.`procesador`;
DROP TABLE IF EXISTS `bd_leasein`.`proveedor`;
DROP TABLE IF EXISTS `bd_leasein`.`reparacion`;
DROP TABLE IF EXISTS `bd_leasein`.`requerimiento_compra`;
DROP TABLE IF EXISTS `bd_leasein`.`salida`;
DROP TABLE IF EXISTS `bd_leasein`.`salida_det`;
DROP TABLE IF EXISTS `bd_leasein`.`usuario`;
DROP TABLE IF EXISTS `bd_leasein`.`video`;

CREATE TABLE `auxiliar` (
  `idAuxiliar` int(11) NOT NULL,
  `cod_tabla` varchar(255) NOT NULL,
  `descripcion` varchar(255) DEFAULT NULL,
  `activo` tinyint(4) NOT NULL,
  PRIMARY KEY (`idAuxiliar`,`cod_tabla`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE `estados` (
  `idEstado` int(11) NOT NULL,
  `nombreEstado` varchar(100) NOT NULL,
  `descripcion` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`idEstado`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE categoria (
	  idCategoria INT AUTO_INCREMENT PRIMARY KEY,
    nombre NVARCHAR(80) NOT NULL,
		subCategoria NVARCHAR(80) NOT NULL,
    estado TINYINT NOT NULL,
		fec_ins DATETIME DEFAULT CURRENT_TIMESTAMP,
		fec_mod DATETIME DEFAULT CURRENT_TIMESTAMP,
		usuario_ins NVARCHAR(100),
		usuario_mod NVARCHAR(100)
)ENGINE=INNODB;


CREATE TABLE marca(
	  idMarca INT AUTO_INCREMENT PRIMARY KEY,
    nombre NVARCHAR(80) NOT NULL,
		idCategoria INT NOT NULL,
    estado TINYINT NOT NULL,
		fec_ins DATETIME DEFAULT CURRENT_TIMESTAMP,
		fec_mod DATETIME DEFAULT CURRENT_TIMESTAMP,
		usuario_ins NVARCHAR(100),
		usuario_mod NVARCHAR(100),
		FOREIGN KEY (idCategoria)
    REFERENCES categoria(idCategoria)
)ENGINE=INNODB;

CREATE TABLE modelo(
	  idModelo INT AUTO_INCREMENT PRIMARY KEY,
    nombre NVARCHAR(80) NOT NULL,
		idMarca INT NOT NULL,
    estado TINYINT NOT NULL,
		fec_ins DATETIME DEFAULT CURRENT_TIMESTAMP,
		fec_mod DATETIME DEFAULT CURRENT_TIMESTAMP,
		usuario_ins NVARCHAR(100),
		usuario_mod NVARCHAR(100),
		FOREIGN KEY (idMarca)
    REFERENCES marca(idMarca)
)ENGINE=INNODB;

CREATE TABLE video(
	  idVideo INT AUTO_INCREMENT PRIMARY KEY,
    codigo NVARCHAR(80) NOT NULL,
		idModelo INT NOT NULL,
		idCapacidad INT NOT NULL,
		capacidad DOUBLE NOT NULL,
		idTipo INT NOT NULL,
		tipo NVARCHAR(20) NOT NULL,
		cantidad INT NOT NULL,
		ubicacion NVARCHAR(80) NOT NULL,
		observacion NVARCHAR(255),
    estado TINYINT NOT NULL,
		fec_ins DATETIME DEFAULT CURRENT_TIMESTAMP,
		fec_mod DATETIME DEFAULT CURRENT_TIMESTAMP,
		usuario_ins NVARCHAR(100),
		usuario_mod NVARCHAR(100),
		FOREIGN KEY (idModelo)
    REFERENCES modelo(idModelo)
)ENGINE=INNODB;

CREATE TABLE procesador(
	  idProcesador INT AUTO_INCREMENT PRIMARY KEY,
    codigo NVARCHAR(80) NOT NULL,
		idModelo INT NOT NULL,
		idGeneracion INT NOT NULL,
		generacion INT NOT NULL, -- VA A JALAR DE UNA TABLA
		idVelocidad INT NOT NULL,
		velocidad NVARCHAR(20) NOT NULL, -- VA A JALAR DE UNA TABLA
		idVelocidadMax INT NOT NULL,
		velocidadMax DOUBLE NOT NULL, -- VA A JALAR DE UNA TABLA
		observacion NVARCHAR(255),
    estado TINYINT NOT NULL,
		fec_ins DATETIME DEFAULT CURRENT_TIMESTAMP,
		fec_mod DATETIME DEFAULT CURRENT_TIMESTAMP,
		usuario_ins NVARCHAR(100),
		usuario_mod NVARCHAR(100),
		FOREIGN KEY (idModelo)
    REFERENCES modelo(idModelo)
)ENGINE=INNODB;

CREATE TABLE memoria(
	  idMemoria INT AUTO_INCREMENT PRIMARY KEY,
    codigo NVARCHAR(80) NOT NULL,
		idModelo INT NOT NULL,
		idBusFrecuencia INT NOT NULL,
		busFrecuencia DOUBLE NOT NULL, -- VA A JALAR DE UNA TABLA
		idCapacidad INT NOT NULL,
		capacidad DOUBLE NOT NULL, -- VA A JALAR DE UNA TABLA
		idTipo INT NOT NULL,
		tipo NVARCHAR(20) NOT NULL, -- VA A JALAR DE UNA TABLA
		cantidad INT NOT NULL,
		ubicacion NVARCHAR(80) NOT NULL,
		observacion NVARCHAR(255),
    estado TINYINT NOT NULL,
		fec_ins DATETIME DEFAULT CURRENT_TIMESTAMP,
		fec_mod DATETIME DEFAULT CURRENT_TIMESTAMP,
		usuario_ins NVARCHAR(100),
		usuario_mod NVARCHAR(100),
		FOREIGN KEY (idModelo)
    REFERENCES modelo(idModelo)
)ENGINE=INNODB;
--
CREATE TABLE disco_duro(
	  idDisco INT AUTO_INCREMENT PRIMARY KEY,
    codigo NVARCHAR(80) NOT NULL,
		idModelo INT NOT NULL,
		idTamano INT NOT NULL,
		tamano NVARCHAR(80) NOT NULL, -- VA A JALAR DE UNA TABLA
		idCapacidad INT NOT NULL,
		capacidad DOUBLE NOT NULL, -- VA A JALAR DE UNA TABLA
		cantidad INT NOT NULL,
		ubicacion NVARCHAR(80) NOT NULL,
		observacion NVARCHAR(255),
    estado TINYINT NOT NULL,
		fec_ins DATETIME DEFAULT CURRENT_TIMESTAMP,
		fec_mod DATETIME DEFAULT CURRENT_TIMESTAMP,
		usuario_ins NVARCHAR(100),
		usuario_mod NVARCHAR(100),
		FOREIGN KEY (idModelo)
    REFERENCES modelo(idModelo)
)ENGINE=INNODB;

CREATE TABLE laptop_cpu(
	idLC INT  NOT NULL PRIMARY KEY,
	idIngreso INT,
	idIngresoDet INT,
	codigo NVARCHAR(80) NOT NULL,
	idModelo INT NOT NULL,
	descripcion NVARCHAR(255) NOT NULL, -- VA A JALAR DE UNA TABLA
	tamanoPantalla DOUBLE, -- solo laptop
	idProcesador INT NOT NULL,
	idVideo INT,  -- puede que tenga o no
	partNumber NVARCHAR(40),
	serieFabrica NVARCHAR(40),
	garantia NVARCHAR(20),
	fecInicioSeguro DATETIME,
	fecFinSeguro DATETIME,
	ubicacion NVARCHAR(80) NOT NULL,
	observacion NVARCHAR(255),
	compraSubarriendo TINYINT NOT NULL,
	estado TINYINT NOT NULL,
	fec_ins DATETIME DEFAULT CURRENT_TIMESTAMP,
	fec_mod DATETIME DEFAULT CURRENT_TIMESTAMP,
	usuario_ins NVARCHAR(100),
	usuario_mod NVARCHAR(100),
	FOREIGN KEY (idModelo)
	REFERENCES modelo(idModelo),
	FOREIGN KEY (idProcesador)
	REFERENCES procesador(idProcesador),
	FOREIGN KEY (idVideo)
	REFERENCES video(idVideo)
)ENGINE=INNODB;


CREATE TABLE memoria_LC(
		idMemoria INT NOT NULL,
		idLC INT NOT NULL,
		cantidad INT NOT NULL,
		idIngreso INT NULL,
		fec_ins DATETIME DEFAULT CURRENT_TIMESTAMP,
		fec_mod DATETIME DEFAULT CURRENT_TIMESTAMP,
		usuario_ins NVARCHAR(100),
		usuario_mod NVARCHAR(100),
		PRIMARY KEY (idMemoria, idLC),
		FOREIGN KEY (idMemoria)
    REFERENCES memoria(idMemoria),
		FOREIGN KEY (idLC)
    REFERENCES laptop_cpu(idLC)
)ENGINE=INNODB;

CREATE TABLE disco_LC(
		idDisco INT NOT NULL,
		idLC INT NOT NULL,
		cantidad INT NOT NULL,
		idIngreso INT NULL,
		fec_ins DATETIME DEFAULT CURRENT_TIMESTAMP,
		fec_mod DATETIME DEFAULT CURRENT_TIMESTAMP,
		usuario_ins NVARCHAR(100),
		usuario_mod NVARCHAR(100),
		PRIMARY KEY (idDisco, idLC),
		FOREIGN KEY (idDisco)
    REFERENCES disco_duro(idDisco),
		FOREIGN KEY (idLC)
    REFERENCES laptop_cpu(idLC)
)ENGINE=INNODB;

CREATE TABLE licencia(
	  idLicencia INT  NOT NULL PRIMARY KEY,
		idIngreso INT,
		idIngresoDet INT,
		idIngresoDetAccesorios INT,
    codigo NVARCHAR(80) NOT NULL,
		idModelo INT NOT NULL,
		idLC INT,
		clave NVARCHAR(80) NOT NULL, 
		fechaActivacion DATETIME, 
		ubicacion NVARCHAR(80) NOT NULL,
		observacion NVARCHAR(255),
    estado TINYINT NOT NULL,
		fec_ins DATETIME DEFAULT CURRENT_TIMESTAMP,
		fec_mod DATETIME DEFAULT CURRENT_TIMESTAMP,
		usuario_ins NVARCHAR(100),
		usuario_mod NVARCHAR(100),
		FOREIGN KEY (idModelo)
    REFERENCES modelo(idModelo),
		FOREIGN KEY (idLC)
    REFERENCES laptop_cpu(idLC)
)ENGINE=INNODB;

-- ingreso y salida

CREATE TABLE proveedor(
		idProveedor INT NOT NULL PRIMARY KEY,
		ruc NVARCHAR(11) UNIQUE NOT NULL,
		razonSocial NVARCHAR(255) NOT NULL,
		nombreComercial NVARCHAR(255),
		abreviacion NVARCHAR(11),
		direccion NVARCHAR(255),
		telefono NVARCHAR(20),
		fax NVARCHAR(20),
		email NVARCHAR(255),
		observacion NVARCHAR(255),
		nombreContacto NVARCHAR(255),
		telefonoContacto NVARCHAR(255),
		emailContacto NVARCHAR(255),
		estado TINYINT NOT NULL,
		fec_ins DATETIME DEFAULT CURRENT_TIMESTAMP,
		fec_mod DATETIME DEFAULT CURRENT_TIMESTAMP,
		usuario_ins NVARCHAR(100),
		usuario_mod NVARCHAR(100)
)ENGINE=INNODB;


CREATE TABLE usuario(
		idUsuario INT AUTO_INCREMENT PRIMARY KEY,
		dni NVARCHAR(8),
		nombre NVARCHAR(255),
		usuario NVARCHAR(20),
		password NVARCHAR(255),
		perfil INT,
		email NVARCHAR(255),
		estado TINYINT NOT NULL,
		fec_ins DATETIME DEFAULT CURRENT_TIMESTAMP,
		fec_mod DATETIME DEFAULT CURRENT_TIMESTAMP,
		usuario_ins NVARCHAR(100),
		usuario_mod NVARCHAR(100)
)ENGINE=INNODB;

CREATE TABLE cliente(
		idCliente INT NOT NULL PRIMARY KEY,
		tipoDocumento INT NOT NULL,
		nroDocumento NVARCHAR(20) UNIQUE NOT NULL,
		nombre_razonSocial NVARCHAR(255) NOT NULL,
		telefono NVARCHAR(20),
		email NVARCHAR(255),
		idKAM INT NOT NULL,
		nombreKam NVARCHAR(255) NOT NULL,
		estado TINYINT NOT NULL,
		fec_ins DATETIME DEFAULT CURRENT_TIMESTAMP,
		fec_mod DATETIME DEFAULT CURRENT_TIMESTAMP,
		usuario_ins NVARCHAR(100),
		usuario_mod NVARCHAR(100),
		FOREIGN KEY (idKAM)
    REFERENCES usuario(idUsuario)
)ENGINE=INNODB;

CREATE TABLE cliente_sucursal(
		idSucursal INT NOT NULL PRIMARY KEY,
		idCliente INT NOT NULL,
		nroDocumento NVARCHAR(100)NOT NULL,
		nombreContacto NVARCHAR(100)NOT NULL,
		direccion NVARCHAR(255) NOT NULL,
		telefono NVARCHAR(20),
		email NVARCHAR(255),
		observacion NVARCHAR(255),
		estado TINYINT NOT NULL,
		fec_ins DATETIME DEFAULT CURRENT_TIMESTAMP,
		fec_mod DATETIME DEFAULT CURRENT_TIMESTAMP,
		usuario_ins NVARCHAR(100),
		usuario_mod NVARCHAR(100),
		FOREIGN KEY (idCliente)
    REFERENCES cliente(idCliente)
)ENGINE=INNODB;


CREATE TABLE requerimiento_compra(
		idRO INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
		observacion NVARCHAR(255),
    estado TINYINT NOT NULL,
		fec_ins DATETIME DEFAULT CURRENT_TIMESTAMP,
		fec_mod DATETIME DEFAULT CURRENT_TIMESTAMP,
		usuario_ins NVARCHAR(100),
		usuario_mod NVARCHAR(100)
)ENGINE=INNODB;


CREATE TABLE orden_compra(
		idOC INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
		idRO INT NOT NULL,
		idProveedor INT NOT NULL,
		observacion NVARCHAR(255),
    estado TINYINT NOT NULL,
		fec_ins DATETIME DEFAULT CURRENT_TIMESTAMP,
		fec_mod DATETIME DEFAULT CURRENT_TIMESTAMP,
		usuario_ins NVARCHAR(100),
		usuario_mod NVARCHAR(100),
		FOREIGN KEY (idRO)
    REFERENCES requerimiento_compra(idRO),
		FOREIGN KEY (idProveedor)
    REFERENCES proveedor(idProveedor)
)ENGINE=INNODB;

CREATE TABLE pedido(
		idPedido INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
		fecPedido DATETIME NOT NULL,
		observacion NVARCHAR(255),
		estado TINYINT NOT NULL,
		fec_ins DATETIME DEFAULT CURRENT_TIMESTAMP,
		fec_mod DATETIME DEFAULT CURRENT_TIMESTAMP,
		usuario_ins NVARCHAR(100),
		usuario_mod NVARCHAR(100)
)ENGINE=INNODB;

CREATE TABLE salida(
		idSalida INT NOT NULL PRIMARY KEY,
		idCliente INT NOT NULL,
		idSucursal INT NOT NULL,
		rucDni NVARCHAR(100),
		nroContrato NVARCHAR(100),
		nroOC NVARCHAR(100),
		idPedido INT ,
		fecSalida DATETIME NOT NULL,
		fecIniContrato DATETIME NOT NULL,
		fecFinContrato DATETIME NOT NULL,
		observacion NVARCHAR(255),
		estado TINYINT NOT NULL,
		fec_ins DATETIME DEFAULT CURRENT_TIMESTAMP,
		fec_mod DATETIME DEFAULT CURRENT_TIMESTAMP,
		usuario_ins NVARCHAR(100),
		usuario_mod NVARCHAR(100),
		FOREIGN KEY (idSucursal)
    REFERENCES cliente_sucursal(idSucursal)
)ENGINE=INNODB;

CREATE TABLE salida_det(
		idSalidaDet INT NOT NULL PRIMARY KEY,
		idSalida INT NOT NULL,
		idLC INT NOT NULL,
		fecIniContrato DATETIME NOT NULL,
		fecFinContrato DATETIME NOT NULL,
		idProcesador INT,
		idVideo INT,
		idDisco1 INT,
		cantidadDisco1 INT,
		idDisco2 INT,
		cantidadDisco2 INT,
		idMemoria1 INT,
		cantidadMemoria1 INT,
		idMemoria2 INT,
		cantidadMemoria2 INT,
		idWindows INT,
		idOffice INT,
		idAntivirus INT,
		caracteristicas NVARCHAR(255)NOT NULL,
		guiaSalida NVARCHAR(255),
		motivoNoRecojo NVARCHAR(255),
		observacion NVARCHAR(255),
		estado TINYINT NOT NULL,
		fueDevuelto TINYINT NOT NULL,
		fec_ins DATETIME DEFAULT CURRENT_TIMESTAMP,
		fec_mod DATETIME DEFAULT CURRENT_TIMESTAMP,
		usuario_ins NVARCHAR(100),
		usuario_mod NVARCHAR(100),
		FOREIGN KEY (idSalida)
    REFERENCES salida(idSalida),
		FOREIGN KEY (idLC)
    REFERENCES laptop_cpu(idLC)
)ENGINE=INNODB;



CREATE TABLE cambio(
		idCambio INT NOT NULL PRIMARY KEY,
		idSalida INT NOT NULL,
		idSalidaDet INT NOT NULL,
		idLCAntiguo INT NOT NULL,
		fecIniContrato DATETIME NOT NULL,
		fecFinContrato DATETIME NOT NULL,
		codigoLCAntiguo NVARCHAR(80) NOT NULL,
		estadoLCAntiguo INT NOT NULL,
		idCliente INT NOT NULL,
		idSucursal INT NOT NULL,
		nombreCliente NVARCHAR(255) NOT NULL,
		rucDni NVARCHAR(11) NOT NULL,
		guiaCambio NVARCHAR(50) NOT NULL UNIQUE,
		fechaCambio DATETIME NOT NULL,
		ticketTecnico NVARCHAR(255),
		idLCNuevo INT NOT NULL,
		codigoLCNuevo NVARCHAR(80) NOT NULL,
		fueDevuelto TINYINT NOT NULL,
		pagaraCliente TINYINT NOT NULL,
		danoLC TINYINT NOT NULL,
		observacion NVARCHAR(255),
		estado TINYINT NOT NULL,
		fec_ins DATETIME DEFAULT CURRENT_TIMESTAMP,
		fec_mod DATETIME DEFAULT CURRENT_TIMESTAMP,
		usuario_ins NVARCHAR(100),
		usuario_mod NVARCHAR(100),
		FOREIGN KEY (idCliente)
    REFERENCES cliente(idCliente)
)ENGINE=INNODB;


CREATE TABLE devolucion(
		idDevolucion INT NOT NULL PRIMARY KEY,
		idCliente INT NOT NULL,
		rucDni NVARCHAR(11) NOT NULL,
		guiaDevolucion NVARCHAR(50) NOT NULL UNIQUE,
		fechaDevolucion DATETIME NOT NULL,
		observacion NVARCHAR(255),
		estado TINYINT NOT NULL,
		fec_ins DATETIME DEFAULT CURRENT_TIMESTAMP,
		fec_mod DATETIME DEFAULT CURRENT_TIMESTAMP,
		usuario_ins NVARCHAR(100),
		usuario_mod NVARCHAR(100),
		FOREIGN KEY (idCliente)
    REFERENCES cliente(idCliente)
)ENGINE=INNODB;

CREATE TABLE devolucion_det(
		idDevolucionDet INT NOT NULL PRIMARY KEY,
		idDevolucion INT NOT NULL,
		idSalidaDet INT NOT NULL,
		idSucursal INT NOT NULL,
		idLC INT NOT NULL,
		codigoLC NVARCHAR(255),
		marcaLC NVARCHAR(255),
		modeloLC NVARCHAR(255),
		pagaraCliente INT NOT NULL,
		danoLC INT NOT NULL,
		caracteristicas NVARCHAR(255),
		estadoLC TINYINT NOT NULL,
		observacion NVARCHAR(255),
		estado TINYINT NOT NULL,
		fec_ins DATETIME DEFAULT CURRENT_TIMESTAMP,
		fec_mod DATETIME DEFAULT CURRENT_TIMESTAMP,
		usuario_ins NVARCHAR(100),
		usuario_mod NVARCHAR(100),
		FOREIGN KEY (idDevolucion)
    REFERENCES devolucion(idDevolucion),
		FOREIGN KEY (idLC)
    REFERENCES laptop_cpu(idLC)
)ENGINE=INNODB;


CREATE TABLE observacion_deudas(
		idObservacionDeudas INT  NOT NULL PRIMARY KEY,
		idCliente INT NOT NULL,
		idLC INT NOT NULL,
		idSalidaDet INT,
		idDevolucion INT,
		idCambio INT,
		observacionDeuda NVARCHAR(1000),
		KAM NVARCHAR(255),
		guiaLevantamiento NVARCHAR(255) UNIQUE,
		observacionLevantamiento NVARCHAR(1000),
		fechaLevantamiento DATETIME NULL,
		estado TINYINT NOT NULL,
		fec_ins DATETIME DEFAULT CURRENT_TIMESTAMP,
		fec_mod DATETIME DEFAULT CURRENT_TIMESTAMP,
		usuario_ins NVARCHAR(100),
		usuario_mod NVARCHAR(100),
		FOREIGN KEY (idCliente)
    REFERENCES cliente(idCliente),
		FOREIGN KEY (idLC)
    REFERENCES laptop_cpu(idLC)
)ENGINE=INNODB;

CREATE TABLE ingreso(
	idIngreso INT  NOT NULL PRIMARY KEY,
	idOC INT NULL,
	idTipoIngreso INT NOT NULL,
	tipoIngreso NVARCHAR(255),
	idProveedor INT NOT NULL,
	razonSocial NVARCHAR(255),
	ruc NVARCHAR(11),
	facturaIngreso NVARCHAR(255),
	guiaIngreso NVARCHAR(255),
	fecIngresa DATETIME NOT NULL,
	idTipoMoneda INT NOT NULL,
	tipoMoneda NVARCHAR(255),
	montoCambio DOUBLE ,
	total DOUBLE NOT NULL,
	observacion NVARCHAR(255),
	estado TINYINT NOT NULL,
	fec_ins DATETIME DEFAULT CURRENT_TIMESTAMP,
	fec_mod DATETIME DEFAULT CURRENT_TIMESTAMP,
	usuario_ins NVARCHAR(100),
	usuario_mod NVARCHAR(100),
	FOREIGN KEY (idProveedor)
	REFERENCES proveedor(idProveedor)
)ENGINE=INNODB;


CREATE TABLE ingreso_det(
	idIngresoDet INT  NOT NULL PRIMARY KEY,
	idIngreso INT NOT NULL,
	idMarcaLC INT,
	idModeloLC INT,
	partNumber NVARCHAR(255),
	pantalla DOUBLE,
	garantia TINYINT,
	cantidad INT,
	subTotal DOUBLE NOT NULL,
	idProcesador INT,
	idVideo INT,
	idDisco1 INT,
	cantidadDisco1 INT,
	idDisco2 INT,
	cantidadDisco2 INT,
	idMemoria1 INT,
	cantidadMemoria1 INT,
	idMemoria2 INT,
	cantidadMemoria2 INT,
	idMemoria3 INT,
	cantidadMemoria3 INT,
	idModeloWindows INT,
	idModeloOffice INT,
	idModeloAntivirus INT,
	caracteristicas  NVARCHAR(255),
	observacion NVARCHAR(255),
	estado TINYINT NOT NULL,
	fec_ins DATETIME DEFAULT CURRENT_TIMESTAMP,
	fec_mod DATETIME DEFAULT CURRENT_TIMESTAMP,
	usuario_ins NVARCHAR(100),
	usuario_mod NVARCHAR(100),
	FOREIGN KEY (idIngreso)
	REFERENCES ingreso(idIngreso)
)ENGINE=INNODB;


CREATE TABLE ingreso_det_accesorios(
	idIngresoDetAccesorios INT  NOT NULL PRIMARY KEY,
	idIngreso INT NOT NULL,
	idCategoria INT,
	idModeloLicencia INT,
	clave  NVARCHAR(255),
	idDisco INT,
	idMemoria INT,
	cantidad INT,
	subTotal DOUBLE NOT NULL,
	observacion NVARCHAR(255),
	estado TINYINT NOT NULL,
	fec_ins DATETIME DEFAULT CURRENT_TIMESTAMP,
	fec_mod DATETIME DEFAULT CURRENT_TIMESTAMP,
	usuario_ins NVARCHAR(100),
	usuario_mod NVARCHAR(100),
	FOREIGN KEY (idIngreso)
	REFERENCES ingreso(idIngreso)
)ENGINE=INNODB;

CREATE TABLE factura(
		idFactura INT  NOT NULL PRIMARY KEY,
		idSalida INT NOT NULL,
		numFactura NVARCHAR(20) NOT NULL,
		fecIniPago DATETIME NOT NULL,
		fecFinPago DATETIME NOT NULL,
		fecEmisiom DATETIME NOT NULL,
		ruc NVARCHAR(11) NOT NULL,
		codigoLC NVARCHAR(80) NOT NULL,
		guiaSalida NVARCHAR(255),
		totalSoles DOUBLE,
		totalDolares DOUBLE,
		costoSoles DOUBLE,
		costoDolares DOUBLE,
		observacion NVARCHAR(255),
		estado TINYINT NOT NULL,
		fec_ins DATETIME DEFAULT CURRENT_TIMESTAMP,
		fec_mod DATETIME DEFAULT CURRENT_TIMESTAMP,
		usuario_ins NVARCHAR(100),
		usuario_mod NVARCHAR(100),
		FOREIGN KEY (idSalida)
    REFERENCES salida(idSalida)
)ENGINE=INNODB;

DROP TABLE IF EXISTS `cuota`;
CREATE TABLE cuota(
		idFactura INT  NOT NULL,
		idSalida INT  NOT NULL,
		idLC INT  NOT NULL,
		numFactura NVARCHAR(20) NOT NULL,
		fecInicioPago DATETIME NOT NULL,
		fecFinPago DATETIME NOT NULL,
		fecEmisiom DATETIME NOT NULL,
		ruc NVARCHAR(11) NOT NULL,
		codigoLC NVARCHAR(80) NOT NULL,
		guiaSalida NVARCHAR(255),
		totalSoles DOUBLE,
		totalDolares DOUBLE,
		costoSoles DOUBLE,
		costoDolares DOUBLE,
		observacion NVARCHAR(255),
		estado TINYINT NOT NULL,
		PRIMARY KEY (`idFactura`,`idSalida`,`idLC`),
		FOREIGN KEY (idSalida)
		REFERENCES salida(idSalida)
)ENGINE=INNODB;


DROP TABLE IF EXISTS `reparacion`;
CREATE TABLE reparacion(
		idReparacion INT NOT NULL PRIMARY KEY,
		idLC INT NOT NULL,
		codigoLC NVARCHAR(80) NOT NULL,
		fechaReparacion DATETIME NOT NULL,
		estadoLCAct TINYINT NOT NULL,
		estadoLCAnt TINYINT NOT NULL,
		observacionActual NVARCHAR(1000),
		observacionReparacion NVARCHAR(1000),
		estado TINYINT NOT NULL,
		fec_ins DATETIME DEFAULT CURRENT_TIMESTAMP,
		fec_mod DATETIME DEFAULT CURRENT_TIMESTAMP,
		usuario_ins NVARCHAR(100),
		usuario_mod NVARCHAR(100),
		FOREIGN KEY (idLC)
    REFERENCES laptop_cpu(idLC)
)ENGINE=INNODB;


DROP TABLE IF EXISTS `ingresos_salidas_internas`;
CREATE TABLE ingresos_salidas_internas(
		idIngresoSalida INT NOT NULL PRIMARY KEY,
		idLC INT NOT NULL,
		codigoLC NVARCHAR(80) NOT NULL,
		estadoLCAnt TINYINT NOT NULL,
		estadoLCAct TINYINT NOT NULL,
		fechaIngresoSalida DATE NOT NULL,
		documentoIdentidad NVARCHAR(255),
		nombrePersona NVARCHAR(1000),
		documentoReferencial NVARCHAR(255),
		tipoIngresoSalida INT NOT NULL,
		estado TINYINT NOT NULL,
		fec_ins DATETIME DEFAULT CURRENT_TIMESTAMP,
		fec_mod DATETIME DEFAULT CURRENT_TIMESTAMP,
		usuario_ins NVARCHAR(100),
		usuario_mod NVARCHAR(100),
		FOREIGN KEY (idLC)
    REFERENCES laptop_cpu(idLC)
)ENGINE=INNODB;

