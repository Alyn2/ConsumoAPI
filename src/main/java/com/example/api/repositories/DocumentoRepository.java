package com.example.api.repositories;

import com.example.api.models.Derivacion;
import com.example.api.models.Documento;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

import java.util.List;

public interface DocumentoRepository extends JpaRepository<Documento, Long> {

    @Query("SELECT d FROM Documento d " +
            "WHERE (:estado IS NULL OR d.estado =: estado) ")
    List<Documento> getDocumentos(String estado);

    @Query("SELECT d FROM Derivacion d " +
            "WHERE d.documento.id = :id ")
    Derivacion getDerivacion(Long id);

}
