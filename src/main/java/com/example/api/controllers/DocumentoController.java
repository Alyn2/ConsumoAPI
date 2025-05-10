package com.example.api.controllers;

import com.example.api.models.Derivacion;
import com.example.api.repositories.DocumentoRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import java.util.Base64;

@RestController
@RequestMapping("/documentos")
public class DocumentoController {

    @Autowired
    private DocumentoRepository documentoRepository;

    @GetMapping
    @CrossOrigin(origins = "*")
    public ResponseEntity<Object> getDocumentos(
            @RequestParam(required = false) String estado
    ) {
        return ResponseEntity.ok(documentoRepository.getDocumentos(estado));
    }

    @GetMapping("/{id}")
    @CrossOrigin(origins = "*")
    public ResponseEntity<Object> getDerivacion(
            @PathVariable Long id
    ) {
        Derivacion derivacion = documentoRepository.getDerivacion(id);
        derivacion.getDocumento().setBase64(Base64.getEncoder().encodeToString(derivacion.getDocumento().getAdjunto()));
        return ResponseEntity.ok(derivacion);
    }

}
