package com.example.api.controllers;

import com.example.api.repositories.UsuarioRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/usuarios")
public class UsuarioController {

    @Autowired
    private UsuarioRepository usuarioRepository;

    @GetMapping
    @CrossOrigin(origins = "*")
    public ResponseEntity<Object> getUsuarios(
            @RequestParam(required = false) String estado
    ) {
        return ResponseEntity.ok(usuarioRepository.getUsuarios(estado));
    }

}
