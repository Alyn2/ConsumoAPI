package com.example.api.models;

import jakarta.persistence.*;
import lombok.Data;

@Entity
@Table(name = "usuarios")
@Data
public class Usuario {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "Idusuario")
    private Long id;

    @ManyToOne
    @JoinColumn(name = "idPersona")
    private Persona persona;

    @Column(name = "Correo")
    private String correo;

    @Column(name = "Contraseña")
    private String contrasenia;

    @ManyToOne
    @JoinColumn(name = "id_rol")
    private Rol rol;

    private String estado;

}
