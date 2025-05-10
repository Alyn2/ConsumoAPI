package com.example.api.models;

import jakarta.persistence.*;
import lombok.Data;

@Entity
@Table(name = "derivacion")
@Data
public class Derivacion {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "idDerivacion")
    private Long id;

    @ManyToOne
    @JoinColumn(name = "documentoid")
    private Documento documento;

    @ManyToOne
    @JoinColumn(name = "areaId")
    private Area area;

}
