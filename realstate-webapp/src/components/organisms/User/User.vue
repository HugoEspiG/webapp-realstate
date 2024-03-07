<template>
    <div class="mt-2">
        <p class="fs-1">Bienvenido {{ $route.params.id }}</p>
        <div class="row">
            <div class="col-md-4">
                <p>Foto</p>
            </div>
            <div class="col-md-8">
                <div>
                    <p class="fs-3 mx-auto">Propiedades mas recientes encontradas para ti</p>
                </div>
                <div class="prueba">
                    <p class="fs-3">Tus datos personales</p>
                    <div class="text-end">
                        Aca ira toda la info
                    </div>
                    <Button @click="edit" variant="primary" size="lg" class="mt-2 text-end">
                        Editar
                    </Button>
                </div>
            </div>
            <p class="my-3" style="font-weight: bold;">{{ user.Rol }}</p>
        </div>
    </div>
    <div class="card mb-4">
        <div class="card-body" style="text-align: center;">

            <div class="row">
                <div class="col-sm-3">
                    <p class="mb-0" style="font-weight: bold;">Email</p>
                </div>
                <div class="col-sm-9">
                    <p class="text-muted mb-0">{{ user.Email }}</p>
                </div>
            </div>
            <hr>
            <div v-if="user.Personal != null">
                <div class="row" v-if="user.Personal.Phone != null">
                    <div class="col-sm-3">
                        <p class="mb-0" style="font-weight: bold;">Phone</p>
                    </div>
                    <div class="col-sm-9">
                        <p class="text-muted mb-0">{{ user.Personal.Phone }}</p>
                    </div>
                </div>

                <hr>
                <div class="row" v-if="user.Personal.Address != null">
                    <div class="col-sm-3">
                        <p class="mb-0" style="font-weight: bold;">Address</p>
                    </div>
                    <div class="col-sm-9">
                        <p class="text-muted mb-0">{{ user.Personal.Address }}</p>
                    </div>
                </div>
                <hr>
                <div class="row" v-if="user.Personal.Birthday != null">
                    <div class="col-sm-3">
                        <p class="mb-0" style="font-weight: bold;">Birthday</p>
                    </div>
                    <div class="col-sm-9">
                        <p class="text-muted mb-0">{{ user.Personal.Birthday }}</p>
                    </div>
                </div>
            </div>
            <div class="row" v-else>
                <ErrorData></ErrorData>
            </div>
        </div>
    </div>
    <div class="col-lg-8">
        <div class="row">
            <div class="col-md-6">
                <div class="card mb-4 mb-md-0">
                    <div class="card-body">
                        <p class="mb-4" style="font-weight: bold; text-align: center;"> Personal </p>
                        <div v-if="user.Personal != null">
                            <div class="row" v-if="user.Personal.Birthday != null">
                                <div class="col-sm-4">
                                    <p class="mb-1" style="font-size: .77rem;">Birthday</p>
                                </div>
                                <div class="col-sm-8">
                                    <p class="mb-0" style="font-size: .77rem;">{{ user.Personal.Birthday }}</p>
                                </div>
                            </div>
                            <div class="row" v-if="user.Personal.CivilStatus != null">
                                <div class="col-sm-4">
                                    <p class="mb-1" style="font-size: .77rem;">Civil status</p>
                                </div>
                                <div class="col-sm-8">
                                    <p class="mb-0" style="font-size: .77rem;">{{ user.Personal.CivilStatus }}</p>
                                </div>
                            </div>

                            <div class="row"
                                v-if="user.Personal.CivilStatus === 'Matrimonio' || user.Personal.CivilStatus === 'Union Libre'">
                                <hr>
                                <p class="mb-4" style="font-weight: bold; text-align: center;"> cónyuge </p>
                                <div v-if="user.Personal.Spouse != null">

                                    <div class="col-sm-4">
                                        <p class="mb-1" style="font-size: .77rem;">Name</p>
                                    </div>
                                    <div class="col-sm-8">
                                        <p class="mb-0" style="font-size: .77rem;">{{ user.Personal.Spouse.Name }}</p>
                                    </div>
                                    <hr>
                                    <div class="col-sm-4">
                                        <p class="mb-1" style="font-size: .77rem;">Birthday</p>
                                    </div>
                                    <div class="col-sm-8">
                                        <p class="mb-0" style="font-size: .77rem;">{{ user.Personal.Spouse.Birthday }}</p>
                                    </div>
                                    <hr>
                                    <div class="col-sm-4">
                                        <p class="mb-1" style="font-size: .77rem;">Job</p>
                                    </div>
                                    <div class="col-sm-8">
                                        <p class="mb-0" style="font-size: .77rem;">{{ user.Personal.Spouse.Job }}</p>
                                    </div>
                                    <hr>
                                    <div class="col-sm-4">
                                        <p class="mb-1" style="font-size: .77rem;">Entidad</p>
                                    </div>
                                    <div class="col-sm-8">
                                        <p class="mb-0" style="font-size: .77rem;">{{ user.Personal.Spouse.JobEntity }}</p>
                                    </div>
                                    <hr>
                                    <div class="col-sm-4">
                                        <p class="mb-1" style="font-size: .77rem;">Salary</p>
                                    </div>
                                    <div class="col-sm-8">
                                        <p class="mb-0" style="font-size: .77rem;">{{ user.Personal.Spouse.Salary }}</p>
                                    </div>
                                </div>
                                <div v-else>
                                    <ErrorData></ErrorData>
                                </div>
                            </div>
                        </div>
                        <div v-else>
                            <ErrorData></ErrorData>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-6">
                <div class="card mb-4 mb-md-0">
                    <div class="card-body" v-if="user.Family == null">
                        <p class="mb-4" style="font-weight: bold; text-align: center;"> Family </p>
                        <ErrorData></ErrorData>

                    </div>
                    <div class="card-body" v-else>
                        <p class="mb-4" style="font-weight: bold; text-align: center;"> Family </p>
                        <div class="row">
                            <div class="col-sm-4">
                                <p class="mb-1" style="font-size: .77rem;">Count</p>
                            </div>
                            <div class="col-sm-8">
                                <p class="mb-0" style="font-size: .77rem;">{{ user.Family.FamilyCount }}</p>
                            </div>
                        </div>
                        <hr>
                        <div class="row">
                            <div class="col-sm-4">
                                <p class="mb-1" style="font-size: .77rem;">Dependientes</p>
                            </div>
                            <div class="col-sm-8">
                                <!--Json problem-->
                                <p class="mb-0" style="font-size: .77rem;">{{ JSON.parse(user.Family.Dependientes).Number }}
                                </p>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <br>
        <div class="row">
            <div class="col-md-6">
                <div class="card mb-4 mb-md-0">
                    <div class="card-body">
                        <p class="mb-4" style="font-weight: bold; text-align: center;"> Labor </p>
                        <div v-if="user.Labor != null">
                            <div class="row">
                                <div class="col-sm-4">
                                    <p class="mb-1" style="font-size: .77rem;">Estado</p>
                                </div>
                                <div class="col-sm-8">
                                    <!--Json problem-->
                                    <p class="mb-0" style="font-size: .77rem;">{{ user.Labor.IsEmployee }}</p>
                                </div>
                            </div>
                            <div class="row" v-if="user.Labor.IsEmployee">
                                <hr>
                                <div class="col-sm-4">
                                    <p class="mb-1" style="font-size: .77rem;">Empresa</p>
                                </div>
                                <div class="col-sm-8">
                                    <p class="mb-0" style="font-size: .77rem;">{{ user.Labor.JobName }}</p>
                                </div>
                                <hr>
                                <div class="col-sm-4">
                                    <p class="mb-1" style="font-size: .77rem;">Cargo</p>
                                </div>
                                <div class="col-sm-8">
                                    <p class="mb-0" style="font-size: .77rem;">{{ user.Labor.JobTitle }}</p>
                                </div>
                                <hr>
                                <div class="col-sm-4">
                                    <p class="mb-1" style="font-size: .77rem;">Salary</p>
                                </div>
                                <div class="col-sm-8">
                                    <p class="mb-0" style="font-size: .77rem;">{{ user.Labor.salary }}</p>
                                </div>
                            </div>
                            <hr>
                            <div class="row" v-if="user.Labor.FinancialObligations">
                                <p class="mb-4" style="font-weight: bold; text-align: center;"> Obligaciones financieras
                                </p>
                                <!--Json problem with parse-->
                                <div class="col-sm-4">
                                    <p class="mb-1" style="font-size: .77rem;">Status</p>
                                </div>
                                <div class="col-sm-8">
                                    <p class="mb-0" style="font-size: .77rem;">{{
                                        JSON.parse(user.Labor.FinancialObligations).Status }}</p>
                                </div>
                            </div>
                            <div class="row" v-else>
                                <p class="mb-4" style="font-weight: bold; text-align: center;"> Obligaciones financieras
                                </p>
                                <ErrorData></ErrorData>
                            </div>
                        </div>
                        <div class="row" v-else>
                            <ErrorData></ErrorData>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-6">
                <div class="card mb-4 mb-md-0">
                    <div class="card-body" v-if="user.Hobbies == null">
                        <p class="mb-4" style="font-weight: bold; text-align: center;"> Hobbies </p>
                        <ErrorData></ErrorData>


                    </div>
                    <div class="card-body" v-else>
                        <p class="mb-4" style="font-weight: bold; text-align: center;"> Hobbies </p>
                        <div v-if="user.Hobbies.Sport">
                            <div v-if="JSON.parse(user.Hobbies.Sport).Status">
                                <p class="mb-4" style="font-weight: bold; text-align: center; color: green;"> Sport </p>
                                <div style="text-align: center;">
                                    <ul style="text-align: left; display: inline-block;">
                                        <li v-for="item in JSON.parse(user.Hobbies.Sport).Activity">
                                            {{ item }}
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <p v-else class="mb-4" style="font-weight: bold; text-align: center; color: red;"> Sport </p>
                            <hr>
                        </div>

                        <div v-if="user.Hobbies.Literature">
                            <div v-if="JSON.parse(user.Hobbies.Literature).Status">
                                <p class="mb-4" style="font-weight: bold; text-align: center; color: green;"> Literature
                                </p>
                                <div style="text-align: center;">
                                    <ul style="text-align: left; display: inline-block;">
                                        <li v-for="item in JSON.parse(user.Hobbies.Literature).Books">
                                            {{ item }}
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <p v-else class="mb-4" style="font-weight: bold; text-align: center; color: red;"> Literature
                            </p>
                            <hr>
                        </div>

                        <div v-if="user.Hobbies.Foods">
                            <div v-if="JSON.parse(user.Hobbies.Foods).Status">
                                <p class="mb-4" style="font-weight: bold; text-align: center; color: green;"> Foods </p>
                                <div class="row">
                                    <div class="col-sm-4">
                                        <p class="mb-1" style="font-size: .77rem;">Favorite food</p>
                                    </div>
                                    <div class="col-sm-8">
                                        <p class="mb-0" style="font-size: .77rem;">{{
                                            JSON.parse(user.Hobbies.Foods).FavoriteFood }}</p>
                                    </div>
                                </div>
                            </div>
                            <p v-else class="mb-4" style="font-weight: bold; text-align: center; color: red;"> Foods </p>
                            <hr>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</template>


<script>

import InputItem from '../../atoms/InputItem/InputItem.vue'
import Button from '../../atoms/Button/Button.vue'
import PItem from '../../atoms/PItem/PItem.vue'
import ErrorData from '../../atoms/ErrorData/ErrorData.vue'
import { mapGetters } from 'vuex'
import axios from 'axios'

export default {
    name: 'User',

    components: {
        Button,
        PItem,
        InputItem,
        ErrorData
    },
    computed: {
        ...mapGetters(['user'])
    },
    methods: {
        handleName() {

            let element = document.getElementById('NameSpan');
            document.getElementById('buttonIdNameIcon').className = `bi bi-check-square`;
            document.getElementById("buttonIdName").onclick = this.handleSummitName;
            if (element != null)
                element.outerHTML = `<input id='NameInput' value='${this.user.Name}' />`;

        },
        async handleSummitName() {
            let txt = document.getElementById('NameInput').value;
            if (txt && this.user.Name != txt) {
                axios.put("Client/Update", {
                    Email: this.user.Email,
                    Name: txt
                }).then((response) => {
                    if (response.status == 200) {
                        alert("save");
                        location.reload();
                    }
                }).catch(e => {
                    alert(e.response);
                })
            } else {
                location.reload();
            }
        }
    }
};
</script>
<style></style>