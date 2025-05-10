package com.example.api.models;

import jakarta.persistence.*;
import lombok.Data;

import java.time.LocalDate;

@Entity
@Table(name = "documento")
@Data
public class Documento {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "documentoId")
    private Long id;

    @Column(name = "Tipo")
    private String tipo;

    @Column(name = "Estado")
    private String estado;

    @Column(name = "Fecha")
    private LocalDate fecha;

    @Column(name = "Requisitos")
    private String requisitos;

    @ManyToOne
    @JoinColumn(name = "tramiteid")
    private Tramite tramite;

    @Column(name = "venFecha")
    private LocalDate venFecha;

    private String descripcion;

    @Lob
    private byte[] adjunto;

    @Transient
    private String base64;

    @Column(name = "area_dirigida")
    private String areaDirigida;

}
