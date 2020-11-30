DROP VIEW IF EXISTS `bd_leasein`.`vista_datos_laptop_por_cambiar`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_disco_capacidad`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_disco_modelo`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_disco_tamano`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_documento_tipo`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_factura_cv`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_facturas_por_vencer`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_ingreso_tipo`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_ingresos_detalles_accesorios_modificable`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_ingresos_detalles_modificable`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_inventario_discos`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_inventario_laptops`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_inventario_memoria`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_kam_activos`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_laptops_almacen_lista`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_laptops_almacen_lista_sin_filtro`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_laptops_danados`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_laptops_detalle_alquiler_cliente_estado_alquilado`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_laptops_detalle_alquiler_plazo_alquiler`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_laptops_discos`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_laptops_marca`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_laptops_memorias`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_laptops_modelo`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_laptops_por_vencer`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_licencia_ingresos`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_licencia_lc_lista`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_licencia_lista`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_licencia_office_tipos`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_licencia_windows_tipos`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_lista_alquileres`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_lista_cambios`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_lista_devoluciones`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_lista_ingresos`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_lista_observaciones`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_lista_reparaciones`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_maestro_cliente`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_maestro_disco`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_maestro_laptops`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_maestro_licencias`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_maestro_memoria`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_maestro_procesador`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_maestro_sucursal_cliente`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_maestro_video`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_memoria_capacidad`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_memoria_categoria`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_memoria_frecuencia`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_memoria_modelo`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_moneda_tipo`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_procesador_generacion`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_procesador_marca`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_procesador_velocidad`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_procesador_velocidad_maxima`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_productos_por_facturar`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_productos_por_recoger`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_proveedor_lista`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_stock_disco_lc_almacen`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_stock_disco_lc_cliente`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_stock_disco_libre`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_stock_memoria_lc_almacen`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_stock_memoria_lc_cliente`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_stock_memoria_libre`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_stockdisponible_disco_libre`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_stockdisponible_licencia_libre`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_stockdisponible_memoria_libre`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_usuario_perfil`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_video_capacidad`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_video_marca`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_video_modelo`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_video_tipo`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_ConSinstockDisponible_memoria_libre`;
DROP VIEW IF EXISTS `bd_leasein`.`vista_ConSinstockDisponible_disco_libre`;

/*Se mostrará la tabla de discos duros en el maestro de discos*/
create view vista_maestro_disco as
Select 	d.idDisco as idDisco,
		m.idModelo as idTipo,
		m.nombre as tipo,
		d.idTamano as idTamano,
		d.tamano as tamano,
		d.idCapacidad as idCapacidad,
		d.capacidad as capacidad,
		d.estado as estado
From disco_duro d
	inner join modelo m on m.idModelo = d.idModelo ;
	
/*Se mostrará el stock de discos duros libres ubicados en almacen*/
create view vista_stock_disco_libre as
Select 	d.idDisco as idDisco,
		m.nombre as tipo,
		d.tamano as tamano,
		d.capacidad as capacidad,
		d.cantidad as cantidad,
		d.estado as estado
From disco_duro d
	inner join modelo m on m.idModelo = d.idModelo;


/*Se mostrará la lista de discos duros con stock mayor a 1*/
create view vista_stockDisponible_disco_libre as
Select 	d.idDisco as IdDisco,
		m.nombre as TipoDisco,
		d.tamano as Tamano,
		d.capacidad as Capacidad,
		d.cantidad as Cantidad,
		d.estado as Estado
From disco_duro d
	inner join modelo m on m.idModelo = d.idModelo 
where d.cantidad>0 and d.estado=1;

create view vista_ConSinstockDisponible_disco_libre as
Select 	d.idDisco as IdDisco,
		m.nombre as TipoDisco,
		d.tamano as Tamano,
		d.capacidad as Capacidad,
		d.cantidad as Cantidad,
		d.estado as Estado
From disco_duro d
	inner join modelo m on m.idModelo = d.idModelo ;

/*Se mostrará el stock de discos duros en almacen relacionados a una laptop_cpu*/
create view vista_stock_disco_LC_almacen as
Select dlc.idDisco,
		m.nombre as tipo,
		d.tamano as tamano,
		d.capacidad as capacidad,
		sum(dlc.cantidad) as Cantidad
From disco_LC dlc, laptop_cpu lc,
	disco_duro d inner join modelo m on m.idModelo = d.idModelo
where dlc.idDisco=d.idDisco and dlc.idLC=lc.idLC and lc.ubicacion="Almacen" 
group by dlc.idDisco;


/*Se mostrará el stock de discos duros en cliente relacionados a una laptop_cpu*/
create view vista_stock_disco_LC_cliente as
Select dlc.idDisco,
		m.nombre as tipo,
		d.tamano as tamano,
		d.capacidad as capacidad,
		sum(dlc.cantidad) as Cantidad
From disco_LC dlc, laptop_cpu lc,
	disco_duro d inner join modelo m on m.idModelo = d.idModelo
where dlc.idDisco=d.idDisco and dlc.idLC=lc.idLC and Not(lc.ubicacion="Almacen")
group by dlc.idDisco;


/*Se mostrará la tabla de memorias en el maestro de memorias*/
create view vista_maestro_memoria as
Select 	me.idMemoria as idMemoria,
		ma.idMarca as idCategoria,
		ma.nombre as categoria,
		m.idModelo as idTipo,
		m.nombre as tipo,
		me.idTipo as idTipo2,
		me.tipo as tipo2,
		me.idBusFrecuencia as idBusFrecuencia,
		me.busFrecuencia as frecuencia,
		me.idCapacidad as idCapacidad,
		me.capacidad as capacidad,
		me.estado as estado
From memoria me
	inner join modelo m on m.idModelo = me.idModelo
	inner join marca ma on m.idMarca = ma.idMarca ;
	
/*Se mostrará el stock de memorias libres ubicados en almacen*/
create view vista_stock_memoria_libre as
Select 	me.idMemoria as idMemoria,
		ma.nombre as categoria,
		m.nombre as tipo,
		me.busFrecuencia as frecuencia,
		me.capacidad as capacidad,
		me.cantidad as cantidad,
		me.tipo as Tipo2,
		me.estado as estado
From memoria me
	inner join modelo m on m.idModelo = me.idModelo
	inner join marca ma on m.idMarca = ma.idMarca ;

/*Se mostrará la lista de memorias con stock mayor a 1*/
create view vista_stockDisponible_memoria_libre as
Select 	me.idMemoria as IdMemoria,
		ma.nombre as categoria,
		m.nombre as TipoMemoria,
		me.busFrecuencia as frecuencia,
		me.capacidad as Capacidad,
		me.cantidad as Cantidad,
		me.tipo as Tipo2,
		me.estado as estado
From memoria me
	inner join modelo m on m.idModelo = me.idModelo
	inner join marca ma on m.idMarca = ma.idMarca 
where me.cantidad>0 and me.estado=1;

create view vista_ConSinstockDisponible_memoria_libre as
Select 	me.idMemoria as IdMemoria,
		ma.nombre as categoria,
		m.nombre as TipoMemoria,
		me.busFrecuencia as frecuencia,
		me.capacidad as Capacidad,
		me.cantidad as Cantidad,
		me.tipo as Tipo2,
		me.estado as estado
From memoria me
	inner join modelo m on m.idModelo = me.idModelo
	inner join marca ma on m.idMarca = ma.idMarca;
	

/*Se mostrará el stock de memorias en almacen relacionados a una laptop_cpu*/
create view vista_stock_memoria_LC_almacen as
Select mlc.idMemoria,
		ma.nombre as categoria,
		m.nombre as tipo,
		me.busFrecuencia as frecuencia,
		me.capacidad as capacidad,
		me.tipo as Tipo2,
		sum(mlc.cantidad) as Cantidad
From memoria_LC mlc, laptop_cpu lc,
	memoria me
	inner join modelo m on m.idModelo = me.idModelo
	inner join marca ma on m.idMarca = ma.idMarca
where mlc.idMemoria=me.idMemoria and mlc.idLC=lc.idLC and lc.ubicacion="Almacen" 
group by mlc.idMemoria;

/*Se mostrará el stock de memorias en cliente relacionados a una laptop_cpu*/
create view vista_stock_memoria_LC_cliente as
Select mlc.idMemoria,
		ma.nombre as categoria,
		m.nombre as tipo,
		me.busFrecuencia as frecuencia,
		me.capacidad as capacidad,
		me.tipo as Tipo2,
		sum(mlc.cantidad) as Cantidad
From memoria_LC mlc, laptop_cpu lc,
	memoria me
	inner join modelo m on m.idModelo = me.idModelo
	inner join marca ma on m.idMarca = ma.idMarca
where mlc.idMemoria=me.idMemoria and mlc.idLC=lc.idLC and Not(lc.ubicacion="Almacen") 
group by mlc.idMemoria;


/*Se mostrará la tabla de procesador en el maestro de procesador*/
create view vista_maestro_procesador as
Select 	p.idProcesador as idProcesador,
		ma.idMarca as idMarca,
		ma.nombre as marca,
		m.idModelo as idTipo,
		m.nombre as tipo,
		p.idGeneracion as idGeneracion,
		p.generacion as generacion,
		p.idVelocidad as idVelocidad,
		p.velocidad as velocidad,
		p.idVelocidadMax as idVelocidadMax,
		p.velocidadMax as velocidadMax,
		p.estado as estado
From procesador p
	inner join modelo m on m.idModelo = p.idModelo
	inner join marca ma on m.idMarca = ma.idMarca ;

/*Se mostrará la tabla de videos en el maestro de videos*/
create view vista_maestro_video as
Select 	v.idVideo as idVideo,
		ma.idMarca as idMarca,
		ma.nombre as marca,
		m.idModelo as idModelo,
		m.nombre as nombreModelo,
		v.idTipo as idTipo,
		v.tipo as tipo,
		v.idCapacidad as idCapacidad,
		v.capacidad as capacidad,
		v.estado as estado
From video v
	inner join modelo m on m.idModelo = v.idModelo
	inner join marca ma on m.idMarca = ma.idMarca ;
	


/*Se mostrará las capacidades de los discos*/
create view vista_disco_capacidad as
Select idAuxiliar, descripcion
from auxiliar
where cod_tabla="DISCO_CAPACIDAD" and activo=1;


/*Se mostrará el tamano de los discos*/
create view vista_disco_tamano as
Select idAuxiliar, descripcion
from auxiliar
where cod_tabla="DISCO_TAMANO" and activo=1;

		
/*Se mostrará los tipos de licencia de ofice*/
create view vista_licencia_office_tipos as
Select idAuxiliar, descripcion
from auxiliar
where cod_tabla="LICENCIA_OFFICE_TIPO" and activo=1;

		
/*Se mostrará los tipos de licencia de windows*/
create view vista_licencia_windows_tipos as
Select idAuxiliar, descripcion
from auxiliar
where cod_tabla="LICENCIA_WINDOWS_TIPO" and activo=1;


create view vista_maestro_licencias as
SELECT c.idCategoria as IdCategoria , c.nombre as Categoria, m.idMarca as IdMarca, m.nombre as Tipo, mo.idModelo as IdModelo, mo.nombre as Version
FROM categoria c 
INNER JOIN marca m on m.idCategoria=c.idCategoria 
INNER JOIN modelo mo on m.idMarca=mo.idMarca 
WHERE c.subCategoria='LICENCIAS';

		
/*Se mostrará las capacidades de la memoria*/
create view vista_memoria_capacidad as
Select idAuxiliar, descripcion
from auxiliar
where cod_tabla="MEMORIA_CAPACIDAD" and activo=1;

		
/*Se mostrará las categorias de la memoria*/
create view vista_memoria_categoria as
Select idAuxiliar, descripcion
from auxiliar
where cod_tabla="MEMORIA_CATEGORIA" and activo=1;

		
/*Se mostrará las frecuencias de la memoria*/
create view vista_memoria_frecuencia as
Select idAuxiliar, descripcion
from auxiliar
where cod_tabla="MEMORIA_FRECUENCIA" and activo=1;

		
/*Se mostrará las generaciones de los procesadores*/
create view vista_procesador_generacion as
Select idAuxiliar, descripcion
from auxiliar
where cod_tabla="PROCESADOR_GENERACION" and activo=1;

		
/*Se mostrará las velocidades de los procesadores*/
create view vista_procesador_velocidad as
Select idAuxiliar, descripcion
from auxiliar
where cod_tabla="PROCESADOR_VELOCIDAD" and activo=1;

		
/*Se mostrará las velocidades maxima de los procesadores*/
create view vista_procesador_velocidad_maxima as
Select idAuxiliar, descripcion
from auxiliar
where cod_tabla="PROCESADOR_VELOCIDAD_MAXIMA" and activo=1;

		
/*Se mostrará perfiles de los usuarios*/
create view vista_usuario_perfil as
Select idAuxiliar, descripcion
from auxiliar
where cod_tabla="USUARIO_PERFIL" and activo=1;

		
/*Se mostrará tipos de tarjeta de video*/
create view vista_video_tipo as
Select idAuxiliar, descripcion
from auxiliar
where cod_tabla="VIDEO_TIPO" and activo=1;

/*Se mostrará las capacidad de tarjeta de video*/
create view vista_video_capacidad as
Select idAuxiliar, descripcion
from auxiliar
where cod_tabla="VIDEO_CAPACIDAD" and activo=1;

/*Se mostrará los modelos de los videos*/
create view vista_video_modelo as
SELECT
	ma.idMarca as IdMarca,
	ma.nombre as NombreMarca,
	mo.idModelo as IdModelo,
	mo.nombre as NombreModelo
FROM
	modelo mo
	INNER JOIN marca ma ON mo.idMarca = ma.idMarca 
WHERE
	ma.idCategoria = 11;
		
/*Se mostrará los modelos de los discos SSD, HHD*/
create view vista_disco_modelo as
Select idModelo, nombre
from modelo
where idMarca=10 and estado=1;

		
/*Se mostrará los modelos de memoria DDR3, DDR4*/
create view vista_memoria_modelo as
Select idModelo, nombre
from modelo
where idMarca=7 and estado=1;

		
/*Se mostrará las marcas de los procesadores*/
create view vista_procesador_marca as
Select mo.idModelo, mo.nombre
from marca m INNER JOIN modelo mo on m.idMarca=mo.IdMarca
where m.idCategoria=9 and m.estado=1 ;


		
/*Se mostrará las marcas de las tarjetas de videos*/
create view vista_video_marca as
Select idMarca, nombre
from marca
where idCategoria=11 and estado=1;
		

/*Se mostrará todas las licencias*/
create view vista_licencia_lista as
Select l.idLicencia as IdLicencia,
				c.idCategoria as IdCategoria,
				c.nombre as Categoria,
				ma.idMarca as IdMarca,
				ma.nombre as Marca,
				mo.idModelo as IdModelo,
				mo.nombre as Version,
				l.clave as Clave,
				if(l.idLC is null,"",l.idLC) as IdLC,
				if(l.idLC is null,"",(select codigo from laptop_cpu lc where lc.idLC=l.idLC)) as CodigoLC,
				l.codigo as CodigoLicencia,
				l.ubicacion as Ubicacion,
				(select nombreEstado from estados e where e.idEstado=l.estado) as NombreEstado
from licencia l, modelo mo, marca ma, categoria c
where l.idModelo=mo.idModelo and ma.idMarca=mo.idMarca and c.idCategoria=ma.idCategoria;


/*Este es parecido al vista_licencia_lista, se usará para llamarlo junto a un where y colocar un idLC, pero la diferencia es que solo mostrará las que están actualmente a una laptop y activos, puede que haya licencias relacionadas a una laptop pero el estado este en 0, lo cual quiere decir que ya caduco, 1 es porque está activo*/
create view vista_licencia_lc_lista as
Select l.idLicencia as IdLicencia,
				c.idCategoria as IdCategoria,
				c.nombre as Categoria,
				ma.idMarca as IdMarca,
				ma.nombre as Marca,
				mo.idModelo as IdModelo,
				mo.nombre as Version,
				l.idLC as IdLC,
				l.clave as Clave,
				l.ubicacion as Ubicacion
from licencia l, modelo mo, marca ma, categoria c
where l.idModelo=mo.idModelo and ma.idMarca=mo.idMarca and c.idCategoria=ma.idCategoria and l.estado=1;

/*Se mostrará todas las licencias*/
create view vista_stockDisponible_licencia_libre as
Select l.idLicencia as IdLicencia,
				c.idCategoria as IdCategoria,
				c.nombre as Categoria,
				ma.idMarca as IdMarca,
				ma.nombre as Marca,
				mo.idModelo as IdModelo,
				mo.nombre as Version,
				l.idLC as IdLC,
				l.clave as Clave,
				l.ubicacion as Ubicacion
from licencia l, modelo mo, marca ma, categoria c
where l.idModelo=mo.idModelo and ma.idMarca=mo.idMarca and c.idCategoria=ma.idCategoria and l.estado=2 and l.idLC is null;
		
		
/*Se mostrará todas los proveedor*/
create view vista_proveedor_lista as		
Select 	idProveedor as idProveedor,
		ruc as ruc,
		razonSocial as razonSocial,
		nombreComercial as nombreComercial,
		abreviacion as abreviacion,
		direccion as direccion,
		telefono as telefono,
		fax as fax,
		email as email,
		observacion as observacion,
		nombreContacto as nombreContacto,
		telefonoContacto as telefonoContacto,
		emailContacto as emailContacto,
		estado as estado
From proveedor;
		
/*Se mostrará todos los tipos de documentos*/
create view vista_documento_tipo as	
Select idAuxiliar, descripcion
from auxiliar
where cod_tabla="TIPO_DOCUMENTO" and activo=1;
		
/*Se mostrará todos los KAMS activos*/
create view vista_KAM_activos as	
Select idUsuario as idUsuario,
		nombre as nombre
from usuario
where perfil=2 and estado=1 ;

/*Se mostrará la tabla de clientes en el maestro de clientes*/
create view vista_maestro_Cliente as
Select idCliente as idCliente,
		tipoDocumento as tipoDocumento,
		descripcion as nombreTipoDocumento,
		nroDocumento as nroDocumento,
		nombre_razonSocial as nombre_razonSocial,
		telefono as telefono,
		email as email,
		idKAM as idKAM,
		nombreKam as nombreKam,
    estado as estado
from cliente , auxiliar 
where tipoDocumento=idAuxiliar and cod_tabla='TIPO_DOCUMENTO';


/*Se mostrará la tabla de sucursales de un cliente en el maestro de sucursales clientes*/
create view vista_maestro_Sucursal_Cliente as
Select 	cs.idSucursal as idSucursal,
		cs.idCliente as idCliente,
		c.nombre_razonSocial as nombreCliente,
		cs.nroDocumento as nroDocumento,
		cs.nombreContacto as nombreContacto,
		cs.direccion as direccion,
		cs.telefono as telefono,
		cs.email as email,
		cs.observacion as observacion,
		cs.estado as estado
from cliente_sucursal cs , cliente c 
where cs.idCliente=c.idCliente;


/*Se mostrará la tabla de laptops en el maestro de laptops*/
create view vista_maestro_laptops as
Select 	l.idLC as idLC,
		ma.idMarca as idMarca,
		ma.nombre as marca,
		m.idModelo as idModelo,
		m.nombre as nombreModelo,
		l.codigo as codigo,
		l.tamanoPantalla as tamanoPantalla,
		l.idProcesador as idProcesador,
		if(l.idVideo is null,0,l.idVideo) as idVideo,
		l.partNumber as partNumber,
		l.serieFabrica as serieFabrica,
		l.garantia as garantia,
		l.fecInicioSeguro as fecInicioSeguro,
		l.fecFinSeguro as fecFinSeguro,
		l.ubicacion as ubicacion,
		l.observacion as observacion,
		l.estado as estado
From laptop_cpu l
	inner join modelo m on m.idModelo = l.idModelo
	inner join marca ma on m.idMarca = ma.idMarca ;
	

/*En la tabla salida se comparara la fecha final de alquiler con el dia actual.*/

create view vista_productos_por_recoger as
SELECT
	d.idSalidaDet AS IdSalidaDetalle,
	s.idSucursal AS IdSucursal,
	d.idLC AS IdLC,
	d.fecIniContrato AS fecIniContrato,
	d.fecFinContrato AS fecFinContrato,
	s.idCliente AS IdCliente,
	sc.nombreCliente AS Cliente,
	sc.nombreContacto AS Contacto,
	sc.direccion AS DireccionCliente,
	sc.telefono AS TelefonoContacto,
	lc.idMarca AS idMarca,
	lc.marca AS MarcaLC,
	lc.idModelo AS idModelo,
	lc.nombreModelo AS NombreModeloLC,
	lc.codigo AS Codigo,
	lc.tamanoPantalla AS TamanoPantalla,
	p.idProcesador AS idProcesador,
	p.marca AS marcaProcesador,
	p.tipo AS TipoProcesador,
	p.generacion AS GeneracionProcesador,
IF (( v.idVideo IS NULL ), 0, v.idVideo ) AS idVideo,
IF (( v.marca IS NULL ), '', v.marca ) AS marcaVideo,
IF (( v.nombreModelo IS NULL ), '', v.nombreModelo ) AS NombreModeloVideo,
IF (( v.capacidad IS NULL ), 0, v.capacidad ) AS CapacidadVideo,
IF (( v.tipo IS NULL ), '', v.tipo ) AS tipoVideo,
(to_days(curdate()) - to_days( d.fecFinContrato )) AS diasAtrasoRecojo,
	d.guiaSalida AS guia,
	d.motivoNoRecojo AS motivoNoRecojo,(
	SELECT c.nombreKam 
	FROM cliente c 
	WHERE ( c.idCliente = s.idCliente )) AS KAM,
	d.estado AS estado,
IF (( d.observacion IS NULL ), '', d.observacion ) AS CodigoAntiguo,
	'' AS GuiaAntigua,
	0 AS IdSalidaDetAntigua ,
		
	'' AS factura,
	'' AS fecInicioFactura,
	'' AS fecFinFactura,
	0 AS MontoSoles,
	0 AS MontoDolares,
	0 AS TotalDolares
	
FROM
	((((( salida s JOIN salida_det d ON (( s.idSalida = d.idSalida 
)))
LEFT JOIN vista_maestro_sucursal_cliente sc ON (( s.idSucursal = sc.idSucursal  ))) LEFT JOIN vista_maestro_laptops lc ON (( d.idLC = lc.idLC  )))
LEFT JOIN vista_maestro_procesador p ON ((
d.idProcesador = p.idProcesador 
))) LEFT JOIN vista_maestro_video v ON (( d.idVideo = v.idVideo  )))  ,
		cuota cu 
WHERE
	(( d.fueDevuelto = 0  ) AND ((( d.estado = 4 ) AND (( to_days( d.fecFinContrato ) - to_days( curdate())) < 0 )) 
		OR ( d.estado = 9 ))) 
		
		AND
			CASE WHEN d.caracteristicas='' THEN
				CONCAT( d.idLC, '-', d.idSalida ) NOT IN ( SELECT CONCAT( c.idLC, '-', c.idSalida ) FROM cuota c)
			ELSE
				CONCAT( d.idLC, '-', d.idSalida ) NOT IN ( SELECT CONCAT( c.idLC, '-', c.idSalida ) FROM cuota c) and
				(SELECT CONCAT( ca.IdLCAntiguo, '-', d.idSalida ) from cambio ca where ca.IdCambio=d.caracteristicas) NOT IN ( SELECT CONCAT( c.idLC, '-', c.idSalida ) FROM cuota c )
			END


UNION 



SELECT
	d.idSalidaDet AS IdSalidaDetalle,
	s.idSucursal AS IdSucursal,
	d.idLC AS IdLC,
	d.fecIniContrato AS fecIniContrato,
	d.fecFinContrato AS fecFinContrato,
	s.idCliente AS IdCliente,
	sc.nombreCliente AS Cliente,
	sc.nombreContacto AS Contacto,
	sc.direccion AS DireccionCliente,
	sc.telefono AS TelefonoContacto,
	lc.idMarca AS idMarca,
	lc.marca AS MarcaLC,
	lc.idModelo AS idModelo,
	lc.nombreModelo AS NombreModeloLC,
	lc.codigo AS Codigo,
	lc.tamanoPantalla AS TamanoPantalla,
	p.idProcesador AS idProcesador,
	p.marca AS marcaProcesador,
	p.tipo AS TipoProcesador,
	p.generacion AS GeneracionProcesador,
IF (( v.idVideo IS NULL ), 0, v.idVideo ) AS idVideo,
IF (( v.marca IS NULL ), '', v.marca ) AS marcaVideo,
IF (( v.nombreModelo IS NULL ), '', v.nombreModelo ) AS NombreModeloVideo,
IF (( v.capacidad IS NULL ), 0, v.capacidad ) AS CapacidadVideo,
IF (( v.tipo IS NULL ), '', v.tipo ) AS tipoVideo,
(to_days(curdate()) - to_days( d.fecFinContrato )) AS diasAtrasoRecojo,
	d.guiaSalida AS guia,
	d.motivoNoRecojo AS motivoNoRecojo,(
	SELECT c.nombreKam 
	FROM cliente c 
	WHERE ( c.idCliente = s.idCliente )) AS KAM,
	d.estado AS estado,
IF (( d.observacion IS NULL ), '', d.observacion ) AS CodigoAntiguo,
	'' AS GuiaAntigua,
	0 AS IdSalidaDetAntigua ,
	
	cu.numFactura AS factura,
	cu.fecInicioPago AS fecInicioFactura,
	cu.fecFinPago AS fecFinFactura,
	cu.totalSoles AS MontoSoles,
	cu.totalDolares AS MontoDolares,
	ROUND((cu.totalDolares+(cu.totalSoles/3.5)),2) AS TotalDolares
	
FROM
	((((( salida s JOIN salida_det d ON (( s.idSalida = d.idSalida 
)))
LEFT JOIN vista_maestro_sucursal_cliente sc ON (( s.idSucursal = sc.idSucursal  ))) LEFT JOIN vista_maestro_laptops lc ON (( d.idLC = lc.idLC  )))
LEFT JOIN vista_maestro_procesador p ON ((
d.idProcesador = p.idProcesador 
))) LEFT JOIN vista_maestro_video v ON (( d.idVideo = v.idVideo  ))) ,
		cuota cu 
WHERE
	(( d.fueDevuelto = 0  ) AND ((( d.estado = 4 ) AND (( to_days( d.fecFinContrato ) - to_days( curdate())) < 0 )) 
		OR ( d.estado = 9 ))) 
		AND
			CASE WHEN d.caracteristicas='' THEN
				CONCAT( d.idLC, '-', d.idSalida )= CONCAT( cu.idLC, '-', cu.idSalida ) 
			ELSE
				CONCAT( d.idLC, '-', d.idSalida )= CONCAT( cu.idLC, '-', cu.idSalida ) or
				(SELECT CONCAT( ca.IdLCAntiguo, '-', d.idSalida ) from cambio ca where ca.IdCambio=d.caracteristicas) = CONCAT( cu.idLC, '-', cu.idSalida )
			END
		
ORDER BY
	IdLC;


create view vista_productos_por_recoger_bk as
Select d.idSalidaDet as IdSalidaDetalle,
		s.idSucursal as IdSucursal,
		d.idLC as IdLC,
		d.fecIniContrato as fecIniContrato,
		d.fecFinContrato as fecFinContrato,
		s.idCliente as IdCliente,
		sc.nombreCliente as Cliente,
		sc.nombreContacto as Contacto,
		sc.direccion as DireccionCliente,
		sc.telefono as TelefonoContacto,
		lc.idMarca as idMarca,
		lc.marca as MarcaLC,
		lc.idModelo as idModelo,
		lc.nombreModelo as NombreModeloLC,
		lc.codigo as Codigo,
		lc.tamanoPantalla as TamanoPantalla,
		p.idProcesador as idProcesador,
		p.marca as marcaProcesador,
		p.tipo as TipoProcesador,
		p.generacion as GeneracionProcesador,
		if(v.idVideo is null,0,v.idVideo) as idVideo,
		if(v.marca is null,'',v.marca) as marcaVideo,
		if(v.nombreModelo is null,'',v.nombreModelo) as NombreModeloVideo,
		if(v.capacidad is null,0,v.capacidad) as CapacidadVideo,
		if(v.tipo is null,'',v.tipo) as tipoVideo,
		DATEDIFF(CURDATE(),d.fecFinContrato) as diasAtrasoRecojo,
		d.guiaSalida as guia,
		d.motivoNoRecojo as motivoNoRecojo,
		(Select c.nombreKam from cliente c where c.idCliente=s.idCliente) as KAM,
		d.estado
From salida s INNER JOIN salida_det d on s.idSalida=d.idSalida
		LEFT JOIN vista_maestro_sucursal_cliente sc on s.idSucursal=sc.idSucursal
		left join  vista_maestro_laptops lc on d.idLC=lc.idLC
		left join  vista_maestro_procesador p on d.idProcesador=p.idProcesador 
		left join vista_maestro_video v on d.idVideo=v.idVideo 
where d.fueDevuelto=0 
and ((d.estado=4 and  (DATEDIFF( d.fecFinContrato , CURDATE())<0)) 
		or d.estado=9)
ORDER BY lc.idLC ;


 
/*En la tabla de cuota se va a poner la ultima factura que se tenga de este producto, si se ingresa una nueva, se elimina esta fila y se inserta la nueva factura aqui. Si no hay ninguna factura en cuota significa que a ese producto nunca se ha facturado.*/
DROP VIEW IF EXISTS vista_productos_por_facturar;
create view vista_productos_por_facturar as
	SELECT
		( SELECT c.nombre_razonSocial FROM cliente c WHERE c.idCliente = s.idCliente ) AS cliente,
		d.fecIniContrato AS fecIniPlazoAlquiler,
		d.fecFinContrato AS fecFinPlazoAlquiler,
		"" AS factura,
		"" AS fecInicioFactura,
		"" AS fecFinFactura,
		"0" AS TotalSoles,
		"0" AS TotalDolares,
		"0" AS CostoSoles,
		"0" AS CostoDolares,
		"0" AS PendienteFacturarSoles,
		"0" AS PendienteFacturarDolares,
		lc.codigo AS codigoEquipo,
		d.guiaSalida AS guia,
		DATEDIFF( CURDATE(), d.fecIniContrato ) AS diasVencidos,
		( SELECT c.nombreKam FROM cliente c WHERE c.idCliente = s.idCliente ) AS KAM 
	FROM
		salida s
		INNER JOIN salida_det d ON s.idSalida = d.idSalida
		INNER JOIN laptop_cpu lc ON lc.idLC = d.idLC 
	WHERE
		d.estado = 4 
		AND
			CASE WHEN d.caracteristicas='' THEN
				CONCAT( d.idLC, '-', d.idSalida ) NOT IN ( SELECT CONCAT( c.idLC, '-', c.idSalida ) FROM cuota c)
			ELSE
				CONCAT( d.idLC, '-', d.idSalida ) NOT IN ( SELECT CONCAT( c.idLC, '-', c.idSalida ) FROM cuota c) and
				(SELECT CONCAT( ca.IdLCAntiguo, '-', d.idSalida ) from cambio ca where ca.IdCambio=d.caracteristicas) NOT IN ( SELECT CONCAT( c.idLC, '-', c.idSalida ) FROM cuota c )
			END
		
	UNION

	SELECT
		( SELECT c.nombre_razonSocial FROM cliente c WHERE c.idCliente = s.idCliente ) AS cliente,
		d.fecIniContrato AS fecIniPlazoAlquiler,
		d.fecFinContrato AS fecFinPlazoAlquiler,
		cu.numFactura AS factura,
		cu.fecInicioPago AS fecInicioFactura,
		cu.fecFinPago AS fecFinFactura,
		cu.totalSoles AS TotalSoles,
		cu.totalDolares AS TotalDolares,
		cu.costoSoles AS CostoSoles,
		cu.costoDolares AS CostoDolares,
		CEIL(DATEDIFF( CURDATE(), cu.fecFinPago )/30)*cu.totalSoles AS PendienteFacturarSoles,
		CEIL(DATEDIFF( CURDATE(), cu.fecFinPago )/30)*cu.totalDolares AS PendienteFacturarDolares,
		lc.codigo AS codigoEquipo,
		d.guiaSalida AS guia,
		DATEDIFF( CURDATE(), cu.fecFinPago ) AS diasVencidos,
		( SELECT c.nombreKam FROM cliente c WHERE c.idCliente = s.idCliente ) AS KAM 
	FROM
		salida s
		INNER JOIN salida_det d ON s.idSalida = d.idSalida
		INNER JOIN laptop_cpu lc ON lc.idLC = d.idLC,
		cuota cu 
	WHERE
		d.estado = 4 
		AND NOT ( d.fecFinContrato = cu.fecFinPago ) 
		AND cu.fecFinPago < CURDATE() 
		AND
			CASE WHEN d.caracteristicas='' THEN
				CONCAT( d.idLC, '-', d.idSalida )= CONCAT( cu.idLC, '-', cu.idSalida ) 
			ELSE
				CONCAT( d.idLC, '-', d.idSalida )= CONCAT( cu.idLC, '-', cu.idSalida ) or
				(SELECT CONCAT( ca.IdLCAntiguo, '-', d.idSalida ) from cambio ca where ca.IdCambio=d.caracteristicas) = CONCAT( cu.idLC, '-', cu.idSalida )
			END
	ORDER BY
		cliente,
		codigoEquipo ;

DROP VIEW IF EXISTS vista_productos_por_facturar_bk;
create view vista_productos_por_facturar_bk as
	SELECT
		( SELECT c.nombre_razonSocial FROM cliente c WHERE c.idCliente = s.idCliente ) AS cliente,
		d.fecIniContrato AS fecIniPlazoAlquiler,
		d.fecFinContrato AS fecFinPlazoAlquiler,
		"" AS factura,
		"" AS fecInicioFactura,
		"" AS fecFinFactura,
		lc.codigo AS codigoEquipo,
		d.guiaSalida AS guia,
		DATEDIFF( CURDATE(), d.fecIniContrato ) AS diasVencidos,
		( SELECT c.nombreKam FROM cliente c WHERE c.idCliente = s.idCliente ) AS KAM 
	FROM
		salida s
		INNER JOIN salida_det d ON s.idSalida = d.idSalida
		INNER JOIN laptop_cpu lc ON lc.idLC = d.idLC 
	WHERE
		d.estado = 4 
		AND
			CASE WHEN d.caracteristicas='' THEN
				CONCAT( d.idLC, '-', d.idSalida ) NOT IN ( SELECT CONCAT( c.idLC, '-', c.idSalida ) FROM cuota c)
			ELSE
				CONCAT( d.idLC, '-', d.idSalida ) NOT IN ( SELECT CONCAT( c.idLC, '-', c.idSalida ) FROM cuota c) and
				(SELECT CONCAT( ca.IdLCAntiguo, '-', d.idSalida ) from cambio ca where ca.IdCambio=d.caracteristicas) NOT IN ( SELECT CONCAT( c.idLC, '-', c.idSalida ) FROM cuota c )
			END
		
	UNION

	SELECT
		( SELECT c.nombre_razonSocial FROM cliente c WHERE c.idCliente = s.idCliente ) AS cliente,
		d.fecIniContrato AS fecIniPlazoAlquiler,
		d.fecFinContrato AS fecFinPlazoAlquiler,
		cu.numFactura AS factura,
		cu.fecInicioPago AS fecInicioFactura,
		cu.fecFinPago AS fecFinFactura,
		lc.codigo AS codigoEquipo,
		d.guiaSalida AS guia,
		DATEDIFF( CURDATE(), cu.fecFinPago ) AS diasVencidos,
		( SELECT c.nombreKam FROM cliente c WHERE c.idCliente = s.idCliente ) AS KAM 
	FROM
		salida s
		INNER JOIN salida_det d ON s.idSalida = d.idSalida
		INNER JOIN laptop_cpu lc ON lc.idLC = d.idLC,
		cuota cu 
	WHERE
		d.estado = 4 
		AND NOT ( d.fecFinContrato = cu.fecFinPago ) 
		AND cu.fecFinPago < CURDATE() 
		AND
			CASE WHEN d.caracteristicas='' THEN
				CONCAT( d.idLC, '-', d.idSalida )= CONCAT( cu.idLC, '-', cu.idSalida ) 
			ELSE
				CONCAT( d.idLC, '-', d.idSalida )= CONCAT( cu.idLC, '-', cu.idSalida ) or
				(SELECT CONCAT( ca.IdLCAntiguo, '-', d.idSalida ) from cambio ca where ca.IdCambio=d.caracteristicas) = CONCAT( cu.idLC, '-', cu.idSalida )
			END
	ORDER BY
		cliente,
		codigoEquipo;



DROP VIEW IF EXISTS vista_facturas_por_vencer;
create view vista_facturas_por_vencer as
SELECT
	( SELECT c.nombre_razonSocial FROM cliente c WHERE c.idCliente = s.idCliente ) AS cliente,
	d.fecIniContrato AS fecIniPlazoAlquiler,
	d.fecFinContrato AS fecFinPlazoAlquiler,
	cu.numFactura AS factura,
	cu.fecInicioPago AS fecInicioFactura,
	cu.fecFinPago AS fecFinFactura,
	lc.codigo AS codigoEquipo,
	d.guiaSalida AS guia,
	DATEDIFF( cu.fecFinPago, CURDATE() ) AS diasAntesVencer,
	( SELECT c.nombreKam FROM cliente c WHERE c.idCliente = s.idCliente ) AS KAM 
FROM
	salida s
	INNER JOIN salida_det d ON s.idSalida = d.idSalida
	INNER JOIN laptop_cpu lc ON lc.idLC = d.idLC,
	cuota cu 
WHERE
	d.estado = 4 
	AND NOT ( d.fecFinContrato = cu.fecFinPago ) 
	AND DATEDIFF( cu.fecFinPago, CURDATE() ) <=7 AND DATEDIFF( cu.fecFinPago, CURDATE() ) >=0 
	AND
	CASE
		WHEN d.caracteristicas = '' THEN
			CONCAT( d.idLC, '-', d.idSalida )= CONCAT( cu.idLC, '-', cu.idSalida ) ELSE CONCAT( d.idLC, '-', d.idSalida )= CONCAT( cu.idLC, '-', cu.idSalida ) 
			OR ( SELECT CONCAT( ca.IdLCAntiguo, '-', d.idSalida ) FROM cambio ca WHERE ca.IdCambio = d.caracteristicas ) = CONCAT( cu.idLC, '-', cu.idSalida ) 
		END 
ORDER BY
	cliente,
	codigoEquipo;



	
/*Se mostrará la tabla de laptops en el maestro de laptops*/
create view vista_laptops_almacen_lista as
SELECT lc.idLC as idLC,
		lc.idMarca as idMarca,
		lc.marca as marcaLC,
		lc.idModelo as idModelo,
		lc.nombreModelo as nombreModeloLC,
		lc.codigo as codigo,
		lc.tamanoPantalla as tamanoPantalla,
		p.idProcesador as idProcesador,
		p.marca as marcaProcesador,
		p.tipo as tipoProcesador,
		p.generacion as generacionProcesador,
		if(v.idVideo is null,0,v.idVideo) as idVideo,
		if(v.marca is null,'',v.marca) as marcaVideo,
		if(v.nombreModelo is null,'',v.nombreModelo) as nombreModeloVideo,
		if(v.capacidad is null,0,v.capacidad) as capacidadVideo,
		if(v.tipo is null,'',v.tipo) as tipoVideo,
		lc.partNumber as partNumber,
		lc.serieFabrica as serieFabrica,
		lc.garantia as garantia,
		lc.fecInicioSeguro as fecInicioSeguro,
		lc.fecFinSeguro as fecFinSeguro,
		lc.ubicacion as ubicacion,
		lc.observacion as observacion,
		lc.estado as estado
FROM vista_maestro_laptops lc 
		left join  vista_maestro_procesador p on lc.idProcesador=p.idProcesador 
		left join vista_maestro_video v on lc.idVideo=v.idVideo 
where lc.estado=2 and lc.ubicacion='ALMACEN'
ORDER BY lc.idLC;
	
/*Se mostrará la tabla de discos relacinados a una laptop*/
create view vista_laptops_discos as
SELECT lc.idLC as IdLC,
		d.idDisco as IdDisco,
		d.tipo as TipoDisco,
		d.tamano as Tamano,
		d.capacidad as Capacidad,
		dlc.cantidad as Cantidad
FROM vista_maestro_laptops lc, vista_maestro_disco d, disco_lc dlc
where lc.idLC=dlc.idLC and d.idDisco=dlc.idDisco 
ORDER BY d.tipo;


/*Se mostrará la tabla de discos relacinados a una laptop*/
create view vista_laptops_memorias as
SELECT lc.idLC as idLC,
		m.idMemoria as IdMemoria,
		m.tipo as TipoMemoria,
		m.tipo2 as Tipo2,
		m.capacidad as Capacidad,
		mlc.cantidad as Cantidad
FROM vista_maestro_laptops lc, vista_maestro_memoria m,  memoria_lc mlc
where lc.idLC=mlc.idLC and m.idMemoria=mlc.idMemoria
ORDER BY m.tipo;


/*Se mostrará los alquileres realizado*/
create view vista_lista_alquileres as
Select a.idSalida as idAlquiler,
			 a.idCliente as idCliente,
			 a.usuario_ins as nombreKam,
			 a.estado as idEstado,
			 c.nombre_razonSocial as nombreCliente,
			 cast(a.fec_ins as date) as fechaProceso,
			 e.nombreEstado as estado
From salida a inner join cliente c on a.idCliente=c.idCliente 
				inner join estados e on a.estado=e.idEstado;

/*Se mostrará los alquileres realizado*/
create view vista_laptops_almacen_lista_sin_filtro as
SELECT lc.idLC as idLC,
		lc.idMarca as idMarca,
		lc.marca as marcaLC,
		lc.idModelo as idModelo,
		lc.nombreModelo as nombreModeloLC,
		lc.codigo as codigo,
		lc.tamanoPantalla as tamanoPantalla,
		p.idProcesador as idProcesador,
		p.marca as marcaProcesador,
		p.tipo as tipoProcesador,
		p.generacion as generacionProcesador,
		if(v.idVideo is null,0,v.idVideo) as idVideo,
		if(v.marca is null,'',v.marca) as marcaVideo,
		if(v.nombreModelo is null,'',v.nombreModelo) as nombreModeloVideo,
		if(v.capacidad is null,0,v.capacidad) as capacidadVideo,
		if(v.tipo is null,'',v.tipo) as tipoVideo,
		lc.partNumber as partNumber,
		lc.serieFabrica as serieFabrica,
		lc.garantia as garantia,
		lc.fecInicioSeguro as fecInicioSeguro,
		lc.fecFinSeguro as fecFinSeguro,
		lc.ubicacion as ubicacion,
		lc.observacion as observacion,
		lc.estado as estado
FROM vista_maestro_laptops lc 
		left join  vista_maestro_procesador p on lc.idProcesador=p.idProcesador 
		left join vista_maestro_video v on lc.idVideo=v.idVideo 
ORDER BY lc.idLC ;

/*Se mostrará todas las laptops que pertenezcan a un cliente cuando se le filtre por idCliente y que además estén en estado alquilado*/
create view vista_laptops_detalle_alquiler_cliente_estado_alquilado as
Select d.idSalidaDet as IdSalidaDetalle,
		s.idSucursal as IdSucursal,
		d.idLC as IdLC,
		cast(d.fecFinContrato as Date) as FinPlazoAlquiler,
		s.idCliente as IdCliente,
		lc.idMarca as idMarca,
		lc.marca as MarcaLC,
		lc.idModelo as idModelo,
		lc.nombreModelo as NombreModeloLC,
		lc.codigo as Codigo,
		lc.tamanoPantalla as TamanoPantalla,
		p.idProcesador as idProcesador,
		p.marca as marcaProcesador,
		p.tipo as TipoProcesador,
		p.generacion as GeneracionProcesador,
		if(v.idVideo is null,0,v.idVideo) as idVideo,
		if(v.marca is null,'',v.marca) as marcaVideo,
		if(v.nombreModelo is null,'',v.nombreModelo) as NombreModeloVideo,
		if(v.capacidad is null,0,v.capacidad) as CapacidadVideo,
		if(v.tipo is null,'',v.tipo) as tipoVideo
From salida s INNER JOIN salida_det d on s.idSalida=d.idSalida
		left join  vista_maestro_laptops lc on d.idLC=lc.idLC
		left join  vista_maestro_procesador p on d.idProcesador=p.idProcesador 
		left join vista_maestro_video v on d.idVideo=v.idVideo 
where d.fueDevuelto=0 and (d.estado=4 or d.estado=9)
ORDER BY lc.idLC ;


create view vista_lista_devoluciones as
Select a.idDevolucion as IdDevolucion,
			 a.idCliente as IdCliente,
			 a.usuario_ins as NombreKam,
			 a.estado as IdEstado,
			 c.nombre_razonSocial as NombreCliente,
			 cast(a.fec_ins as date) as FechaProceso,
			 e.nombreEstado as Estado
From devolucion a inner join cliente c on a.idCliente=c.idCliente 
				inner join estados e on a.estado=e.idEstado;
				
				
create view vista_lista_cambios as
Select a.idCambio as IdCambio,
			 a.idCliente as IdCliente,
			 a.usuario_ins as NombreKam,
			 a.estado as IdEstado,
			 c.nombre_razonSocial as NombreCliente,
			 cast(a.fec_ins as date) as FechaProceso,
			 e.nombreEstado as Estado
From cambio a inner join cliente c on a.idCliente=c.idCliente 
				inner join estados e on a.estado=e.idEstado;

create view vista_datos_laptop_por_cambiar as
SELECT d.idLC as IdLCAntiguo,
		d.fecIniContrato as fecIniContrato,
		d.fecFinContrato as fecFinContrato,
		s.idSalida as IdSalida ,
		d.idSalidaDet as IdSalidaDet ,
		l.codigo as CodigoLCAntiguo,
		s.idCliente as IdCliente,
		s.idSucursal as IdSucursal,
		c.nombre_razonSocial as NombreCliente,
		s.rucDni as RucDni
FROM salida_det d 
		INNER JOIN salida s on d.idSalida=s.idSalida 
		INNER JOIN laptop_cpu l on d.idLC=l.idLC 
		INNER JOIN cliente c on s.idCliente=c.IdCliente
where d.estado=4 and fueDevuelto=0;


create view vista_laptops_marca as
Select m.idMarca, m.nombre
from marca m 
where m.idCategoria=1 and m.estado=1 ;


create view vista_laptops_modelo as
Select m.idMarca, mo.idModelo, mo.nombre
from marca m INNER JOIN modelo mo on m.idMarca=mo.IdMarca
where m.idCategoria=1 and m.estado=1 ;


create view vista_ingreso_tipo as
Select idAuxiliar, descripcion
from auxiliar
where cod_tabla="INGRESO_TIPO" and activo=1;


create view vista_moneda_tipo as
Select idAuxiliar, descripcion
from auxiliar
where cod_tabla="MONEDA_TIPO" and activo=1;


/*Se mostrará los alquileres realizado*/
create view vista_lista_ingresos as
Select a.idIngreso as idIngreso,
			 a.idProveedor as idProveedor,
			 a.usuario_ins as nombreKam,
			 a.estado as idEstado,
			 c.razonSocial as razonSocial,
			 cast(a.fec_ins as date) as fechaProceso,
			 e.nombreEstado as estado
From ingreso a inner join proveedor c on a.idProveedor=c.idProveedor 
				inner join estados e on a.estado=e.idEstado ;


/*Se mostrará los alquileres realizado*/
create view vista_licencia_ingresos as
Select l.idLicencia as IdLicencia,
				c.idCategoria as IdCategoria,
				c.nombre as Categoria,
				ma.idMarca as IdMarca,
				ma.nombre as Marca,
				mo.idModelo as IdModelo,
				mo.nombre as Version,
				l.idLC as IdLaptop,
				l.clave as Clave,
				l.ubicacion as Ubicacion,
				l.idIngreso as idIngreso,
				l.idIngresoDet as idIngresoDet,
				l.idIngresoDetAccesorios as idIngresoDetAccesorios,
				l.idLC as idLC
from licencia l, modelo mo, marca ma, categoria c
where l.idModelo=mo.idModelo and ma.idMarca=mo.idMarca and c.idCategoria=ma.idCategoria ;



create view vista_ingresos_detalles_modificable as
SELECT
	d.*,
	ma.nombre AS nombreMarca,
	mo.nombre AS nombreModelo,
	vp.tipo AS tipoProcesador,
	vp.generacion AS generacionProcesador,
	IFNULL( vv.nombreModelo, '' ) AS modeloVideo,
	IFNULL( vv.capacidad, '' ) AS capacidadVideo,
	IFNULL( vd1.capacidad, 0 ) AS CapacidadDisco1,
	IFNULL( vd1.tipo, '' ) AS TipoDisco1,
	IFNULL( vd1.tamano, '' ) AS TamanoDisco1,
	IFNULL( vd2.capacidad, 0 ) AS CapacidadDisco2,
	IFNULL( vd2.tipo, '' ) AS TipoDisco2,
	IFNULL( vd2.tamano, '' ) AS TamanoDisco2,
	IFNULL( m1.capacidad, 0 ) AS CapacidadMemoria1,
	IFNULL( m1.tipo, '' ) AS TipoMemoria1,
	IFNULL( m1.tipo2, '' ) AS Tipo2Memoria1,
	IFNULL( m2.capacidad, 0 ) AS CapacidadMemoria2,
	IFNULL( m2.tipo, '' ) AS TipoMemoria2,
	IFNULL( m2.tipo2, '' ) AS Tipo2Memoria2,
	IFNULL( m3.capacidad, 0 ) AS CapacidadMemoria3,
	IFNULL( m3.tipo, '' ) AS TipoMemoria3,
	IFNULL( m3.tipo2, '' ) AS Tipo2Memoria3,
	IFNULL( l1.Version, '' ) AS ModeloWindows,
	IFNULL( l1.Categoria, '' ) AS CategoriaWindows,
	IFNULL( l2.Version, '' ) AS ModeloOffice,
	IFNULL( l2.Categoria, '' ) AS CategoriaOffice,
	IFNULL( l3.Version, '' ) AS ModeloAntivirus,
	IFNULL( l3.Categoria, '' ) AS CategoriaAntivirus 
FROM
	ingreso_det d
	INNER JOIN marca ma ON d.idMarcaLC = ma.idMarca
	INNER JOIN modelo mo ON d.idModeloLC = mo.idModelo
	INNER JOIN vista_maestro_procesador vp ON d.idProcesador = vp.idProcesador
	LEFT JOIN vista_maestro_video vv ON d.idVideo = vv.idVideo
	LEFT JOIN vista_maestro_disco vd1 ON d.idDisco1 = vd1.idDisco
	LEFT JOIN vista_maestro_disco vd2 ON d.idDisco2 = vd2.idDisco
	LEFT JOIN vista_maestro_memoria m1 ON d.idMemoria1 = m1.idMemoria
	LEFT JOIN vista_maestro_memoria m2 ON d.idMemoria2 = m2.idMemoria
	LEFT JOIN vista_maestro_memoria m3 ON d.idMemoria3 = m3.idMemoria
	LEFT JOIN vista_maestro_licencias l1 ON d.idModeloWindows = l1.IdModelo
	LEFT JOIN vista_maestro_licencias l2 ON d.idModeloOffice = l2.IdModelo
	LEFT JOIN vista_maestro_licencias l3 ON d.idModeloAntivirus = l3.IdModelo ;
	
	
	
create view vista_ingresos_detalles_accesorios_modificable as
SELECT
	da.*,
	IFNULL( d.capacidad, '' ) AS CapacidadDisco,
	IFNULL( d.tipo, '' ) AS TipoDisco,
	IFNULL( d.tamano, '' ) AS TamanoDisco,
	IFNULL( m.capacidad, '' ) AS CapacidadMemoria,
	IFNULL( m.tipo, '' ) AS TipoMemoria,
	IFNULL( m.tipo2, '' ) AS Tipo2,
	IFNULL( l.Categoria, '' ) AS Categoria,
	IFNULL( l.IdCategoria, '' ) AS IdCategoriaLicencia,
	IFNULL( l.Tipo, '' ) AS Marca,
	IFNULL( l.Version, '' ) AS Version 
FROM
	ingreso_det_accesorios da
	LEFT JOIN vista_maestro_disco d ON da.idDisco = d.idDisco
	LEFT JOIN vista_maestro_memoria m ON da.idMemoria = m.idMemoria
	LEFT JOIN vista_maestro_licencias l ON da.idModeloLicencia = l.IdModelo ;
	
	
DROP view IF EXISTS `vista_factura_CV`;
create view vista_factura_CV as
SELECT
	CONCAT( s.rucDni, '-', l.codigo ) AS concatCodActCV,
	CONCAT( s.rucDni, '-', d.observacion ) AS concatCodAntCV,
	l.codigo,
	l.idLC AS IdLCActual,
	d.observacion AS CodigoAntiguo,
	cl.nombre_razonSocial,
	d.fecIniContrato,
	d.fecFinContrato,
	IFNULL( c.fecInicioPago, '31/12/1999' ) AS fecInicioPago,
	IFNULL( c.fecFinPago, '31/12/1999' ) AS fecFinPago,
	IFNULL( c.numFactura, '' ) AS numFactura,
	IFNULL( c.guiaSalida, '' ) AS guiaSalida,
	d.guiaSalida AS guiaActual,
	IFNULL((
		SELECT
			d2.guiaSalida AS GuiaSalidaAntiguo 
		FROM
			cambio c1
			INNER JOIN salida_det d2 ON d2.idLC = c1.idLCAntiguo 
		WHERE
			d.caracteristicas = c1.idCambio 
			),
		'' 
	) AS guiaAntigua,
	IFNULL((
		SELECT
			c2.fecInicioPago AS fecInicioPagoAntigua 
		FROM
			cambio c1
			INNER JOIN salida_det d2 ON d2.idLC = c1.idLCAntiguo
			INNER JOIN cuota c2 ON d2.idLC = c2.IdLC 
			AND d2.idSalida = c2.idSalida 
		WHERE
			d.caracteristicas = c1.idCambio 
			),
		'31/12/1999' 
	) AS fecInicioPagoAntigua,
	IFNULL((
		SELECT
			c2.fecFinPago AS fecFinPagoAntigua 
		FROM
			cambio c1
			INNER JOIN salida_det d2 ON d2.idLC = c1.idLCAntiguo
			INNER JOIN cuota c2 ON d2.idLC = c2.IdLC 
			AND d2.idSalida = c2.idSalida 
		WHERE
			d.caracteristicas = c1.idCambio 
			),
		'31/12/1999' 
	) AS fecFinPagoAntigua,
	IFNULL((
		SELECT
			c2.numFactura AS numFacturaAntigua 
		FROM
			cambio c1
			INNER JOIN salida_det d2 ON d2.idLC = c1.idLCAntiguo
			INNER JOIN cuota c2 ON d2.idLC = c2.IdLC 
			AND d2.idSalida = c2.idSalida 
		WHERE
			d.caracteristicas = c1.idCambio 
			),
		'' 
	) AS numFacturaAntigua,
	IFNULL((
		SELECT
			d2.idLC AS IdLCAntigua 
		FROM
			cambio c1
			INNER JOIN salida_det d2 ON d2.idLC = c1.idLCAntiguo 
		WHERE
			d.caracteristicas = c1.idCambio 
			),
		'' 
	) AS IdLCAntigua 
FROM
	salida s
	INNER JOIN salida_det d ON s.idSalida = d.idSalida
	LEFT JOIN laptop_cpu l ON d.idLC = l.idLC
	LEFT JOIN cuota c ON d.idLC = c.IdLC 
	AND d.idSalida = c.idSalida
	LEFT JOIN cliente cl ON s.rucDni = cl.nroDocumento 
WHERE
	d.estado = 4;
	
	
/*Se mostrará todas las laptops que pertenezcan a un cliente cuando se le filtre por idCliente y que además estén en estado alquilado*/
create view vista_laptops_detalle_alquiler_plazo_alquiler as
Select d.idSalidaDet as IdSalidaDetalle,
		s.idSucursal as IdSucursal,
		d.idLC as IdLC,
		d.fecIniContrato as fecIniContrato,
		d.fecFinContrato as fecFinContrato,
		s.idCliente as IdCliente,
		lc.idMarca as idMarca,
		lc.marca as MarcaLC,
		lc.idModelo as idModelo,
		lc.nombreModelo as NombreModeloLC,
		lc.codigo as Codigo,
		lc.tamanoPantalla as TamanoPantalla,
		p.idProcesador as idProcesador,
		p.marca as marcaProcesador,
		p.tipo as TipoProcesador,
		p.generacion as GeneracionProcesador,
		if(v.idVideo is null,0,v.idVideo) as idVideo,
		if(v.marca is null,'',v.marca) as marcaVideo,
		if(v.nombreModelo is null,'',v.nombreModelo) as NombreModeloVideo,
		if(v.capacidad is null,0,v.capacidad) as CapacidadVideo,
		if(v.tipo is null,'',v.tipo) as tipoVideo
From salida s INNER JOIN salida_det d on s.idSalida=d.idSalida
		left join  vista_maestro_laptops lc on d.idLC=lc.idLC
		left join  vista_maestro_procesador p on d.idProcesador=p.idProcesador 
		left join vista_maestro_video v on d.idVideo=v.idVideo 
where d.fueDevuelto=0 and d.estado=4
ORDER BY lc.idLC ;

create view vista_laptops_cuadro_vencimiento as
Select d.idSalidaDet as IdSalidaDetalle,
		s.idSucursal as IdSucursal,
		s.idSalida as IdSalida,
		d.idLC as IdLC,
		d.fecIniContrato as fecIniContrato,
		d.fecFinContrato as fecFinContrato,
		s.idCliente as IdCliente,
		sc.nombreCliente as Cliente,
		sc.nombreContacto as Contacto,
		sc.direccion as DireccionCliente,
		sc.telefono as TelefonoContacto,
		lc.idMarca as idMarca,
		lc.marca as MarcaLC,
		lc.idModelo as idModelo,
		lc.nombreModelo as NombreModeloLC,
		lc.codigo as Codigo,
		lc.tamanoPantalla as TamanoPantalla,
		p.idProcesador as idProcesador,
		p.marca as marcaProcesador,
		p.tipo as TipoProcesador,
		p.generacion as GeneracionProcesador,
		if(v.idVideo is null,0,v.idVideo) as idVideo,
		if(v.marca is null,'',v.marca) as marcaVideo,
		if(v.nombreModelo is null,'',v.nombreModelo) as NombreModeloVideo,
		if(v.capacidad is null,0,v.capacidad) as CapacidadVideo,
		if(v.tipo is null,'',v.tipo) as tipoVideo,
				
		d.guiaSalida AS guia,
		'' AS factura,
		'' AS fecInicioFactura,
		'' AS fecFinFactura,
		0 AS MontoSoles,
		0 AS MontoDolares,
		0 AS TotalDolares,
		DATEDIFF( CURDATE(), d.fecIniContrato ) AS diasVencidos,

	if(d.observacion is null,'',d.observacion) as CodigoAntiguo,
	
	IFNULL((Select dA.guiaSalida as GuiaAntigua
	From salida_det dA inner join laptop_cpu lc on dA.idLC=lc.idLC
	where dA.IdSalida=d.idSalida and lc.codigo=d.observacion), '') as GuiaAntigua,
	
	IFNULL((Select dA.idSalidaDet as IdSalidaDetAntigua
	From salida_det dA inner join laptop_cpu lc on dA.idLC=lc.idLC
	where dA.IdSalida=d.idSalida and lc.codigo=d.observacion), '') as IdSalidaDetAntigua
		
From salida s INNER JOIN salida_det d on s.idSalida=d.idSalida
		LEFT JOIN vista_maestro_sucursal_cliente sc on s.idSucursal=sc.idSucursal
		left join  vista_maestro_laptops lc on d.idLC=lc.idLC
		left join  vista_maestro_procesador p on d.idProcesador=p.idProcesador 
		left join vista_maestro_video v on d.idVideo=v.idVideo ,
		cuota cu 
where d.fueDevuelto=0 and d.estado=4
and  (DATEDIFF( d.fecFinContrato , CURDATE())>=0  )
		AND
			CASE WHEN d.caracteristicas='' THEN
				CONCAT( d.idLC, '-', d.idSalida ) NOT IN ( SELECT CONCAT( c.idLC, '-', c.idSalida ) FROM cuota c)
			ELSE
				CONCAT( d.idLC, '-', d.idSalida ) NOT IN ( SELECT CONCAT( c.idLC, '-', c.idSalida ) FROM cuota c) and
				(SELECT CONCAT( ca.IdLCAntiguo, '-', d.idSalida ) from cambio ca where ca.IdCambio=d.caracteristicas) NOT IN ( SELECT CONCAT( c.idLC, '-', c.idSalida ) FROM cuota c )
			END
union


Select d.idSalidaDet as IdSalidaDetalle,
		s.idSucursal as IdSucursal,
		s.idSalida as IdSalida,
		d.idLC as IdLC,
		d.fecIniContrato as fecIniContrato,
		d.fecFinContrato as fecFinContrato,
		s.idCliente as IdCliente,
		sc.nombreCliente as Cliente,
		sc.nombreContacto as Contacto,
		sc.direccion as DireccionCliente,
		sc.telefono as TelefonoContacto,
		lc.idMarca as idMarca,
		lc.marca as MarcaLC,
		lc.idModelo as idModelo,
		lc.nombreModelo as NombreModeloLC,
		lc.codigo as Codigo,
		lc.tamanoPantalla as TamanoPantalla,
		p.idProcesador as idProcesador,
		p.marca as marcaProcesador,
		p.tipo as TipoProcesador,
		p.generacion as GeneracionProcesador,
		if(v.idVideo is null,0,v.idVideo) as idVideo,
		if(v.marca is null,'',v.marca) as marcaVideo,
		if(v.nombreModelo is null,'',v.nombreModelo) as NombreModeloVideo,
		if(v.capacidad is null,0,v.capacidad) as CapacidadVideo,
		if(v.tipo is null,'',v.tipo) as tipoVideo,
		
		d.guiaSalida AS guia,
		cu.numFactura AS factura,
		cu.fecInicioPago AS fecInicioFactura,
		cu.fecFinPago AS fecFinFactura,
		cu.totalSoles AS MontoSoles,
		cu.totalDolares AS MontoDolares,
		ROUND((cu.totalDolares+(cu.totalSoles/3.5)),2) AS TotalDolares,
		DATEDIFF( CURDATE(), cu.fecFinPago ) AS diasVencidos,

	if(d.observacion is null,'',d.observacion) as CodigoAntiguo,
	
	IFNULL((Select dA.guiaSalida as GuiaAntigua
	From salida_det dA inner join laptop_cpu lc on dA.idLC=lc.idLC
	where dA.IdSalida=d.idSalida and lc.codigo=d.observacion), '') as GuiaAntigua,
	
	IFNULL((Select dA.idSalidaDet as IdSalidaDetAntigua
	From salida_det dA inner join laptop_cpu lc on dA.idLC=lc.idLC
	where dA.IdSalida=d.idSalida and lc.codigo=d.observacion), '') as IdSalidaDetAntigua		
		
From salida s INNER JOIN salida_det d on s.idSalida=d.idSalida
		LEFT JOIN vista_maestro_sucursal_cliente sc on s.idSucursal=sc.idSucursal
		left join  vista_maestro_laptops lc on d.idLC=lc.idLC
		left join  vista_maestro_procesador p on d.idProcesador=p.idProcesador 
		left join vista_maestro_video v on d.idVideo=v.idVideo ,
		cuota cu 
where d.fueDevuelto=0 and d.estado=4
and  (DATEDIFF( d.fecFinContrato , CURDATE())>=0  )
		AND
			CASE WHEN d.caracteristicas='' THEN
				CONCAT( d.idLC, '-', d.idSalida )= CONCAT( cu.idLC, '-', cu.idSalida ) 
			ELSE
				CONCAT( d.idLC, '-', d.idSalida )= CONCAT( cu.idLC, '-', cu.idSalida ) or
				(SELECT CONCAT( ca.IdLCAntiguo, '-', d.idSalida ) from cambio ca where ca.IdCambio=d.caracteristicas) = CONCAT( cu.idLC, '-', cu.idSalida )
			END
ORDER BY Cliente ;

create view vista_laptops_cuadro_vencimiento_bk as
Select d.idSalidaDet as IdSalidaDetalle,
		s.idSucursal as IdSucursal,
		s.idSalida as IdSalida,
		d.idLC as IdLC,
		d.fecIniContrato as fecIniContrato,
		d.fecFinContrato as fecFinContrato,
		s.idCliente as IdCliente,
		sc.nombreCliente as Cliente,
		sc.nombreContacto as Contacto,
		sc.direccion as DireccionCliente,
		sc.telefono as TelefonoContacto,
		lc.idMarca as idMarca,
		lc.marca as MarcaLC,
		lc.idModelo as idModelo,
		lc.nombreModelo as NombreModeloLC,
		lc.codigo as Codigo,
		lc.tamanoPantalla as TamanoPantalla,
		p.idProcesador as idProcesador,
		p.marca as marcaProcesador,
		p.tipo as TipoProcesador,
		p.generacion as GeneracionProcesador,
		if(v.idVideo is null,0,v.idVideo) as idVideo,
		if(v.marca is null,'',v.marca) as marcaVideo,
		if(v.nombreModelo is null,'',v.nombreModelo) as NombreModeloVideo,
		if(v.capacidad is null,0,v.capacidad) as CapacidadVideo,
		if(v.tipo is null,'',v.tipo) as tipoVideo,
		
		d.guiaSalida AS guia,
		'' AS factura,
		'' AS fecInicioFactura,
		'' AS fecFinFactura,
		0 AS MontoSoles,
		0 AS MontoDolares,
		0 AS TotalDolares,
		DATEDIFF( CURDATE(), d.fecIniContrato ) AS diasVencidos
		
From salida s INNER JOIN salida_det d on s.idSalida=d.idSalida
		LEFT JOIN vista_maestro_sucursal_cliente sc on s.idSucursal=sc.idSucursal
		left join  vista_maestro_laptops lc on d.idLC=lc.idLC
		left join  vista_maestro_procesador p on d.idProcesador=p.idProcesador 
		left join vista_maestro_video v on d.idVideo=v.idVideo ,
		cuota cu 
where d.fueDevuelto=0 and d.estado=4
and  (DATEDIFF( d.fecFinContrato , CURDATE())>=0  )
		AND
			CASE WHEN d.caracteristicas='' THEN
				CONCAT( d.idLC, '-', d.idSalida ) NOT IN ( SELECT CONCAT( c.idLC, '-', c.idSalida ) FROM cuota c)
			ELSE
				CONCAT( d.idLC, '-', d.idSalida ) NOT IN ( SELECT CONCAT( c.idLC, '-', c.idSalida ) FROM cuota c) and
				(SELECT CONCAT( ca.IdLCAntiguo, '-', d.idSalida ) from cambio ca where ca.IdCambio=d.caracteristicas) NOT IN ( SELECT CONCAT( c.idLC, '-', c.idSalida ) FROM cuota c )
			END
union


Select d.idSalidaDet as IdSalidaDetalle,
		s.idSucursal as IdSucursal,
		s.idSalida as IdSalida,
		d.idLC as IdLC,
		d.fecIniContrato as fecIniContrato,
		d.fecFinContrato as fecFinContrato,
		s.idCliente as IdCliente,
		sc.nombreCliente as Cliente,
		sc.nombreContacto as Contacto,
		sc.direccion as DireccionCliente,
		sc.telefono as TelefonoContacto,
		lc.idMarca as idMarca,
		lc.marca as MarcaLC,
		lc.idModelo as idModelo,
		lc.nombreModelo as NombreModeloLC,
		lc.codigo as Codigo,
		lc.tamanoPantalla as TamanoPantalla,
		p.idProcesador as idProcesador,
		p.marca as marcaProcesador,
		p.tipo as TipoProcesador,
		p.generacion as GeneracionProcesador,
		if(v.idVideo is null,0,v.idVideo) as idVideo,
		if(v.marca is null,'',v.marca) as marcaVideo,
		if(v.nombreModelo is null,'',v.nombreModelo) as NombreModeloVideo,
		if(v.capacidad is null,0,v.capacidad) as CapacidadVideo,
		if(v.tipo is null,'',v.tipo) as tipoVideo,
		
		d.guiaSalida AS guia,
		cu.numFactura AS factura,
		cu.fecInicioPago AS fecInicioFactura,
		cu.fecFinPago AS fecFinFactura,
		cu.totalSoles AS MontoSoles,
		cu.totalDolares AS MontoDolares,
		ROUND((cu.totalDolares+(cu.totalSoles/3.5)),2) AS TotalDolares,
		DATEDIFF( CURDATE(), cu.fecFinPago ) AS diasVencidos
		
From salida s INNER JOIN salida_det d on s.idSalida=d.idSalida
		LEFT JOIN vista_maestro_sucursal_cliente sc on s.idSucursal=sc.idSucursal
		left join  vista_maestro_laptops lc on d.idLC=lc.idLC
		left join  vista_maestro_procesador p on d.idProcesador=p.idProcesador 
		left join vista_maestro_video v on d.idVideo=v.idVideo ,
		cuota cu 
where d.fueDevuelto=0 and d.estado=4
and  (DATEDIFF( d.fecFinContrato , CURDATE())>=0  )
		AND
			CASE WHEN d.caracteristicas='' THEN
				CONCAT( d.idLC, '-', d.idSalida )= CONCAT( cu.idLC, '-', cu.idSalida ) 
			ELSE
				CONCAT( d.idLC, '-', d.idSalida )= CONCAT( cu.idLC, '-', cu.idSalida ) or
				(SELECT CONCAT( ca.IdLCAntiguo, '-', d.idSalida ) from cambio ca where ca.IdCambio=d.caracteristicas) = CONCAT( cu.idLC, '-', cu.idSalida )
			END
ORDER BY IdCliente ;


create view vista_laptops_por_vencer as
Select d.idSalidaDet as IdSalidaDetalle,
		s.idSucursal as IdSucursal,
		d.idLC as IdLC,
		d.fecIniContrato as fecIniContrato,
		d.fecFinContrato as fecFinContrato,
		s.idCliente as IdCliente,
		sc.nombreCliente as Cliente,
		sc.nombreContacto as Contacto,
		sc.direccion as DireccionCliente,
		sc.telefono as TelefonoContacto,
		lc.idMarca as idMarca,
		lc.marca as MarcaLC,
		lc.idModelo as idModelo,
		lc.nombreModelo as NombreModeloLC,
		lc.codigo as Codigo,
		lc.tamanoPantalla as TamanoPantalla,
		p.idProcesador as idProcesador,
		p.marca as marcaProcesador,
		p.tipo as TipoProcesador,
		p.generacion as GeneracionProcesador,
		if(v.idVideo is null,0,v.idVideo) as idVideo,
		if(v.marca is null,'',v.marca) as marcaVideo,
		if(v.nombreModelo is null,'',v.nombreModelo) as NombreModeloVideo,
		if(v.capacidad is null,0,v.capacidad) as CapacidadVideo,
		if(v.tipo is null,'',v.tipo) as tipoVideo
From salida s INNER JOIN salida_det d on s.idSalida=d.idSalida
		LEFT JOIN vista_maestro_sucursal_cliente sc on s.idSucursal=sc.idSucursal
		left join  vista_maestro_laptops lc on d.idLC=lc.idLC
		left join  vista_maestro_procesador p on d.idProcesador=p.idProcesador 
		left join vista_maestro_video v on d.idVideo=v.idVideo 
where d.fueDevuelto=0 and d.estado=4
and  (DATEDIFF( d.fecFinContrato , CURDATE())<7 and DATEDIFF( d.fecFinContrato , CURDATE())>=0  )
ORDER BY lc.idLC ;




DROP view IF EXISTS `vista_inventario_laptops`;
create view vista_inventario_laptops as
SELECT lc.idLC as idLC,
		lc.idMarca as idMarca,
		lc.marca as marcaLC,
		lc.idModelo as idModelo,
		lc.nombreModelo as nombreModeloLC,
		lc.codigo as codigo,
		lc.tamanoPantalla as tamanoPantalla,
		p.idProcesador as idProcesador,
		p.marca as marcaProcesador,
		p.tipo as tipoProcesador,
		p.generacion as generacionProcesador,
		if(v.idVideo is null,0,v.idVideo) as idVideo,
		if(v.marca is null,'',v.marca) as marcaVideo,
		if(v.nombreModelo is null,'',v.nombreModelo) as nombreModeloVideo,
		if(v.capacidad is null,0,v.capacidad) as capacidadVideo,
		if(v.tipo is null,'',v.tipo) as tipoVideo,
		lc.partNumber as partNumber,
		lc.serieFabrica as serieFabrica,
		lc.garantia as garantia,
		lc.fecInicioSeguro as fecInicioSeguro,
		lc.fecFinSeguro as fecFinSeguro,
		lc.ubicacion as idUbicacionSucursal,
		lc.observacion as observacion,
		lc.estado as idEstado,
		(SELECT nombreEstado from estados e where lc.estado=e.idEstado) as estado,
		IFNULL((SELECT direccion from cliente_sucursal cs where lc.ubicacion=cs.IdSucursal),lc.ubicacion) as ubicacion,
		IFNULL((SELECT ct.nombre_razonSocial from cliente ct inner join cliente_sucursal cs on ct.idCliente=cs.idCliente where lc.ubicacion=cs.IdSucursal),'') as cliente,
		IFNULL(d.idSalida,'') as idSalida
FROM vista_maestro_laptops lc 
		left join  vista_maestro_procesador p on lc.idProcesador=p.idProcesador 
		left join vista_maestro_video v on lc.idVideo=v.idVideo 
		left join salida_det d on lc.idLC=d.idLC and d.estado=6 and d.fueDevuelto=0
ORDER BY lc.idLC;



DROP view IF EXISTS `vista_inventario_memoria`;
create view vista_inventario_memoria as
Select 	me.idMemoria as IdMemoria,
		ma.nombre as categoria,
		m.nombre as TipoMemoria,
		me.busFrecuencia as frecuencia,
		me.capacidad as Capacidad,
		me.cantidad as Cantidad,
		me.tipo as Tipo2,
		me.estado as estado
From memoria me
	inner join modelo m on m.idModelo = me.idModelo
	inner join marca ma on m.idMarca = ma.idMarca;


DROP view IF EXISTS `vista_inventario_discos`;
create view vista_inventario_discos as
Select 	d.idDisco as IdDisco,
		m.nombre as TipoDisco,
		d.tamano as Tamano,
		d.capacidad as Capacidad,
		d.cantidad as Cantidad,
		d.estado as Estado
From disco_duro d
	inner join modelo m on m.idModelo = d.idModelo ;


DROP view IF EXISTS `vista_laptops_danados`;
create view vista_laptops_danados as
SELECT  lc.codigo as codigo,
		lc.idLC as idLC,
		lc.marca as marcaLC,
		lc.nombreModelo as nombreModeloLC,
		lc.observacion as observacion,
		lc.estado as idEstado,
		(select nombreEstado from estados e where e.idEstado=lc.estado) as nombreEstado
FROM vista_maestro_laptops lc 
where lc.estado=3 and lc.ubicacion='ALMACEN'
ORDER BY lc.idLC;



DROP view IF EXISTS `vista_lista_reparaciones`;
create view vista_lista_reparaciones as
SELECT r.idReparacion AS IdReparacion,
			 r.idLC AS IdLC,
			 r.usuario_ins AS NombreResponsable,
			(SELECT u.nombre FROM usuario u WHERE u.usuario=r.usuario_ins) AS Responsable,
			 r.estado AS IdEstado,
			 r.codigoLC AS CodigoLC,
			 CAST(r.fec_ins AS DATE) AS FechaProceso,
			(SELECT e.nombreEstado FROM estados e WHERE e.IdEstado=r.estado) AS Estado,
			CAST(fechaReparacion as DATE) AS FechaReparacion,
			(SELECT e.nombreEstado FROM estados e WHERE e.IdEstado=r.estadoLCAnt) AS EstadoAntesReparacion,
			(SELECT e.nombreEstado FROM estados e WHERE e.IdEstado=r.estadoLCAct) AS EstadoLuegoReparacion,
			r.observacionActual AS DescripcionComoSeEncontro,
			r.observacionReparacion AS DescripcionReparacion
FROM reparacion r ;


DROP view IF EXISTS `vista_lista_observaciones`;
create view vista_lista_observaciones as
Select o.idObservacionDeudas as IdObservacion,
			o.idCliente as IdCliente,
			(Select c.nombre_razonSocial From cliente c Where c.idCliente=o.idCliente) as Cliente,
			(Select c.nroDocumento From cliente c Where c.idCliente=o.idCliente) as RUC,
			o.idLC as IdLC,
			(Select lc.codigo From laptop_cpu lc Where lc.idLC=o.IdLC) as CodigoLC,
			IFNULL(o.idDevolucion, 0) AS IdDevolucion,
			IFNULL(o.idCambio, 0) AS IdCambio,
			o.observacionDeuda as ObservacionDeuda,
			o.guiaLevantamiento as GuiaLevantamiento,
			o.observacionLevantamiento as ObservacionLevantamiento,
			o.fechaLevantamiento as FechaLevantamiento,
			o.estado as IdEstado,
			(Select e.nombreEstado From estados e where e.idEstado=o.estado) as Estado
From observacion_deudas o ;


DROP view IF EXISTS `vista_procesador_marca`;
create view vista_procesador_marca as
SELECT
	m.idMarca as IdMarca,
	m.nombre as Nombre,
	m.idCategoria as IdCategoria,
	m.estado as Estado
FROM marca m 
WHERE m.idCategoria = 9  
	AND m.estado = 1 ;

DROP view IF EXISTS `vista_salida_tipo`;
create view vista_salida_tipo as
Select idAuxiliar, descripcion
from auxiliar
where cod_tabla="SALIDA_TIPO" and activo=1;




DROP view IF EXISTS `vista_laptops_disponibles_danados`;
create view vista_laptops_disponibles_danados as
SELECT
	lc.codigo AS codigo,
	lc.idLC AS idLC,
	lc.marca AS marcaLC,
	lc.nombreModelo AS nombreModeloLC,
	lc.observacion AS observacion,
	lc.estado AS idEstado,
	(	SELECT e.nombreEstado FROM	estados e WHERE	( e.idEstado = lc.estado )) AS nombreEstado 
FROM
	vista_maestro_laptops lc 
WHERE
		lc.estado = 2 or lc.estado = 3
ORDER BY
	lc.codigo;
	
DROP view IF EXISTS `vista_laptops_personal_prestamo`;
create view vista_laptops_personal_prestamo as
SELECT
	lc.codigo AS codigo,
	lc.idLC AS idLC,
	lc.marca AS marcaLC,
	lc.nombreModelo AS nombreModeloLC,
	lc.observacion AS observacion,
	lc.estado AS idEstado,
	(	SELECT e.nombreEstado FROM	estados e WHERE	( e.idEstado = lc.estado )) AS nombreEstado 
FROM
	vista_maestro_laptops lc 
WHERE
		lc.estado = 12 or lc.estado = 13
ORDER BY
	lc.codigo;

DROP view IF EXISTS `vista_estados_Venta_Personal_Prestamo`;
create view vista_estados_Venta_Personal_Prestamo as
SELECT *
FROM
	estados
WHERE
		idEstado=5 or idEstado=12 or idEstado=13
ORDER BY
	nombreEstado;

DROP view IF EXISTS `vista_estados_Disponible_Danado`;
create view vista_estados_Disponible_Danado as
SELECT *
FROM
	estados
WHERE
		idEstado=2 or idEstado=3
ORDER BY
	nombreEstado;