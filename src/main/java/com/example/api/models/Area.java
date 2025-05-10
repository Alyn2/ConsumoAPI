package com.example.api.models;

import jakarta.persistence.*;
import lombok.Data;

@Entity
@Table(name = "area")
@Data
public class Area {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "Areaid")
    private Long id;

    private String nombre;

    @Column(name = "estadoArea")
    private String estado;

}
