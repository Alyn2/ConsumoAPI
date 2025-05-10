package com.example.api.models;

import jakarta.persistence.*;
import lombok.Data;

@Entity
@Table(name = "persona")
@Data
public class Persona {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "Idpersona")
    private Long id;

    @Column(name = "Nombre")
    private String nombre;

    @Column(name = "Apellido")
    private String apellido;

    @Column(name = "Telefono")
    private Integer telefono;

    @Column(name = "Tipo_de_documento")
    private String tipoDocumento;

    @Column(name = "Numero_de_documento")
    private Integer numeroDocumento;

    @Column(name = "Cargo")
    private String cargo;
}
