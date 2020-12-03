CREATE EVENT update_salida_det_fechaFinalPlazoEvento
ON SCHEDULE EVERY 1 DAY STARTS '2020-12-02 00:01:00'
DO call update_salida_det_fechaFinalPlazoEvento();