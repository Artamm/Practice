package Data;

import javax.persistence.*;

@MappedSuperclass
public class Person {
    public Person (){}
    @Column(name="Name")
    private String name;
    @Column(name="Surname")
    private String surname;


    public Person(String name, String surname) {
        this.name = name;
        this.surname = surname;
    }

    public String getName() {
        return name;
    }

    public String getSurname() {
        return surname;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setSurname(String surname) {
        this.surname = surname;
    }

    public int id;

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }
}
