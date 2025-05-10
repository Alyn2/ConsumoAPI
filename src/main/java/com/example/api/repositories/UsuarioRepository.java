package com.example.api.repositories;

import com.example.api.models.Usuario;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

import java.util.List;

public interface UsuarioRepository extends JpaRepository<Usuario, Long> {

    @Query("SELECT u FROM Usuario u " +
            "WHERE (:estado IS NULL OR u.estado =: estado) ")
    List<Usuario> getUsuarios(String estado);

}
