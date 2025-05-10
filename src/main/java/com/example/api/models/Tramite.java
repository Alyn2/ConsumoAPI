package com.example.api.models;

import jakarta.persistence.*;
import lombok.Data;

import java.time.LocalDate;

@Entity
@Table(name = "trámite")
@Data
public class Tramite {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "tramiteId")
    private Long id;

    @Column(name = "fechaRecepcion")
    private LocalDate fechaRecepcion;

    @Column(name = "Observación")
    private String observacion;

    @ManyToOne
    @JoinColumn(name = "idPersona")
    private Persona persona;

    @Column(name = "Cantidad_dias")
    private Integer cantidadDias;

    @Column(name = "fechaTermino")
    private LocalDate fechaTermino;

    private String asunto;
}
