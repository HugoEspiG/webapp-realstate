<template>
    <section style="background-color: #eee;">
  <div class="container py-5">
    <div style="text-align: center;"><h1 style="font-weight: bold;">Update Profile</h1><br></div>
    <div class="row">
      <div class="col-lg-4">
      
        <div class="card mb-4">
          <div class="card-body" style="text-align: center;">
            
            <div class="row">
              <div class="col-sm-3">
                <p class="mb-0" style="font-weight: bold;">Email</p>
              </div>
              <div class="col-sm-9" >
                <input type="text" :value="user.Email" readonly/>
              </div>
            </div>
            <hr>
            
              <div class="row">
                <div class="col-sm-3">
                  <p class="mb-0" style="font-weight: bold;">Phone</p>
                </div>
                <div class="col-sm-9" >
                  <input  v-if="user.Personal != null && user.Personal.Phone!=null" :value="user.Personal.Phone"/>
                  <input v-else/>
                </div>
              </div>
              
              <hr>
              <div class="row">
                <div class="col-sm-3">
                  <p class="mb-0" style="font-weight: bold;">Address</p>
                </div>
                <div class="col-sm-9" >
                  <input  v-if="user.Personal !=null && user.Personal.Address!=null" :value="user.Personal.Address"/>
                  <input v-else/>
                </div>
              </div>
              <hr>
              <div class="row" >
                <div class="col-sm-3">
                  <p class="mb-0" style="font-weight: bold;">Birthday</p>
                </div>
                <div class="col-sm-9">
                  <input v-if="user.Personal !=null && user.Personal.Birthday!=null" type="date" min="1900-01-01" max="2005-12-31"  :value="user.Personal.Birthday" readonly/>
                  <input v-else type="date" min="1900-01-01" max="2005-12-31"/>
                </div>
              </div>
              <div style="display: flex; justify-content: center;" >
                <Button variant="primary" class="mt-3 mw-25"><a href="javascript:void(0)" style="color: white; text-decoration: none !important;">Save</a> </Button>
              </div>
          </div>
        </div>
            <div class="card mb-4">
              <div class="card-body">
                <p class="mb-4" style="font-weight: bold; text-align: center;"> Personal </p>
                  <div class="row" v-if="user.Personal !=null && user.Personal.CivilStatus!=null">
                      <div class="col-sm-4">
                          <p class="mb-1" style="font-size: .77rem;">Civil status </p>
                      </div>
                      <div class="col-sm-8">
                        <select class="form-select" aria-label="Default select example" v-model="user.Personal.CivilStatus">
                          <option v-for="stete in stetes" :key="stete" :value="stete" :selected="user.Personal.CivilStatus">{{ stete }}</option>
                        </select>
                      </div>
                  </div>
                  <div class="row" v-else>
                      <div class="col-sm-4">
                          <p class="mb-1" style="font-size: .77rem;">Civil status </p>
                      </div>
                      <div class="col-sm-8">
                        <select class="form-select" aria-label="Default select example" v-model="estadoMarital">
                          <option v-for="stete in stetes" :key="stete" :value="stete" >{{ stete }}</option>
                        </select>
                      </div>
                  </div>
                  <div class="row" v-if="user.Personal!=null && (user.Personal.CivilStatus === 'Matrimonio' ||  user.Personal.CivilStatus === 'Union Libre')">
                    <br>
                      <p class="mb-4" style="font-weight: bold; text-align: center;"> cónyuge </p>
                     
                      <div class="col-sm-4">
                          <p class="mb-1" style="font-size: .77rem;">Name</p>
                      </div>
                      <div class="col-sm-8">
                        <input  v-if="user.Personal.Spouse != null && user.Personal.Spouse.Name!=null" :value="user.Personal.Spouse.Name"/>
                        <input v-else/>
                      </div>
                      
                      <div class="col-sm-4">
                          <p class="mb-1" style="font-size: .77rem;">Birthday</p>
                      </div>
                      <div class="col-sm-8">
                        <input v-if="user.Personal!=null && user.Personal.Spouse!=null && user.Personal.Spouse.Birthday!=null" type="date" min="1900-01-01" max="2005-12-31"  :value="user.Personal.Spouse.Birthday" readonly/>
                        <input v-else type="date" min="1900-01-01" max="2005-12-31"/>
                      </div>
                      
                      <div class="col-sm-4">
                          <p class="mb-1" style="font-size: .77rem;">Job</p>
                      </div>
                      <div class="col-sm-8">
                        <input  v-if="user.Personal!=null && user.Personal.Spouse != null && user.Personal.Spouse.Job!=null" :value="user.Personal.Spouse.Job"/>
                        <input v-else/>
                      </div>
                      
                      <div class="col-sm-4">
                          <p class="mb-1" style="font-size: .77rem;">Entidad</p>
                      </div>
                      <div class="col-sm-8">
                        <input  v-if="user.Personal!=null && user.Personal.Spouse != null && user.Personal.Spouse.JobEntity!=null" :value="user.Personal.Spouse.JobEntity"/>
                        <input v-else/>
                      </div>
                      
                      <div class="col-sm-4">
                          <p class="mb-1" style="font-size: .77rem;">Salary</p>
                      </div>
                      <div class="col-sm-8">
                        <input  v-if="user.Personal!=null && user.Personal.Spouse != null && user.Personal.Spouse.Salary!=null" :value="user.Personal.Spouse.Salary"/>
                        <input v-else/>
                      </div>
                  </div>
                  
                  <div class="row" v-if="(estadoMarital === 'Matrimonio' ||  estadoMarital === 'Union Libre')">
                    <br>
                      <p class="mb-4" style="font-weight: bold; text-align: center;"> cónyuge </p>
                     
                      <div class="col-sm-4">
                          <p class="mb-1" style="font-size: .77rem;">Name</p>
                      </div>
                      <div class="col-sm-8">
                        <input/>
                      </div>
                      
                      <div class="col-sm-4">
                          <p class="mb-1" style="font-size: .77rem;">Birthday</p>
                      </div>
                      <div class="col-sm-8">
                        <input type="date" min="1900-01-01" max="2005-12-31"/>
                      </div>
                      
                      <div class="col-sm-4">
                          <p class="mb-1" style="font-size: .77rem;">Job</p>
                      </div>
                      <div class="col-sm-8">
                        <input />
                      </div>
                      
                      <div class="col-sm-4">
                          <p class="mb-1" style="font-size: .77rem;">Entidad</p>
                      </div>
                      <div class="col-sm-8">
                        <input/>
                      </div>
                      
                      <div class="col-sm-4">
                          <p class="mb-1" style="font-size: .77rem;">Salary</p>
                      </div>
                      <div class="col-sm-8">
                        <input />
                      </div>
                  </div>
                  <div style="display: flex; justify-content: center;" >
                    <Button variant="primary" class="mt-3 mw-25"><a href="javascript:void(0)" style="color: white; text-decoration: none !important;">Save</a> </Button>
                  </div>
              </div>
            </div>        
      </div>
      
      <div class="col-lg-8">
        <div class="row">
          <div class="col-md-6" >
            <div class="card mb-4 mb-md-0">
              <div class="card-body" >
                <p class="mb-4" style="font-weight: bold; text-align: center;"> Family </p>
                <div class="row">
                    <div class="col-sm-4">
                        <p class="mb-1" style="font-size: .77rem;">Count</p>
                    </div>
                    <div class="col-sm-8">
                      <input  v-if="user.Family!=null && user.Family.FamilyCount != null" :value="user.Family.FamilyCount"/>
                      <input v-else/>
                    </div>
                </div>
                <hr>
                <div class="row">
                    <div class="col-sm-4">
                        <p class="mb-1" style="font-size: .77rem;">Dependientes</p>
                    </div>
                    <div class="col-sm-8">
                        <!-- rethinking of the DB format -->
                        <input/>
                    </div>
                </div>
                <div style="display: flex; justify-content: center;" >
                    <Button variant="primary" class="mt-3 mw-25"><a href="javascript:void(0)" style="color: white; text-decoration: none !important;">Save</a> </Button>
                  </div>
              </div>
            </div>
          </div>
          <div class="col-md-6">
            <div class="card mb-4 mb-md-0">
              <div class="card-body">
                <p class="mb-4" style="font-weight: bold; text-align: center;"> Labor </p>
                <div>
                  <div class="row">
                      <div class="col-sm-4">
                          <p class="mb-1" style="font-size: .77rem;">Estado</p>
                      </div>
                      <div class="col-sm-8">
                        <select class="form-select" aria-label="Default select example" v-model="employeeStatus">
                          <option v-for="stete in TF" :key="stete" :value="stete" >{{ stete }}</option>
                        </select>
                      </div>
                  </div>
                    <div class="row" v-if="employeeStatus">
                        <hr>
                        <div class="col-sm-4">
                            <p class="mb-1" style="font-size: .77rem;">Empresa</p>
                        </div>
                        <div class="col-sm-8">
                          <input  v-if="user.Labor!=null && user.Labor.Job != null" :value="user.Labor.Job"/>
                          <input v-else/>
                        </div>
                        <hr>
                        <div class="col-sm-4">
                            <p class="mb-1" style="font-size: .77rem;">Cargo</p>
                        </div>
                        <div class="col-sm-8">
                          <input  v-if="user.Labor!=null && user.Labor.JobTitle != null" :value="user.Labor.JobTitle"/>
                          <input v-else/>
                        </div>
                        <hr>
                        <div class="col-sm-4">
                            <p class="mb-1" style="font-size: .77rem;">Salary</p>
                        </div>
                        <div class="col-sm-8">
                          <input  v-if="user.Labor!=null && user.Labor.Salary != null" :value="user.Labor.Salary"/>
                          <input v-else/>
                        </div>
                    </div>
                    <hr>
                    <div class="row" >
                        <p class="mb-4" style="font-weight: bold; text-align: center;"> Obligaciones financieras </p>
                        <!--Json problem with parse-->
                        <div class="col-sm-4">
                            <p class="mb-1" style="font-size: .77rem;">Status</p>
                        </div>
                        <div class="col-sm-8">
                            <!-- rethinking of the DB format -->
                        </div>
                    </div>
                    
                  </div>
              </div>
            </div>
          </div>
        </div>
<br>
<div class="row">
          <div class="md-6" >
            <div class="card mb-4 mb-md-0">
              <div class="card-body">
                <p class="mb-4" style="font-weight: bold; text-align: center;"> Hobbies </p>
                <p class="mb-4" style="font-weight: bold; text-align: center;" > Sport </p>
                <div class="row">
                  <div class="col-6">
                    <div v-for="index in sport">
                      <input type="checkbox" :id="index" :value="index" v-model="sportSelect">
                      <label :for="index"> {{index}}</label>
                    </div>
                  </div>
                  <div class="col-6">
                    <div class="card bg-light mb-3">
                      <div class="card-header" style="text-align: center;">Deportes seleccionados</div>
                      <ul>
                        <div v-for="index in sportSelect">
                          <li>{{ index }}</li>
                        </div>
                      </ul>
                    </div>
                  </div>
                </div>
                <hr>
                <p class="mb-4" style="font-weight: bold; text-align: center;" > Literature </p>
                <div class="row">
                  <div class="col-sm-8">
                    <div class="card bg-light mb-3">
                      <div class="card-header" style="text-align: center;">Libros registrados</div>
                      <ol>
                        <div v-for="index in literatureSelect">
                          <li>{{ index }}</li>
                        </div>
                      </ol>
                    </div>
                  </div>
                  <div class="col">
                    
                      <div>
                        <textarea class="example-default-value" placeholder="Type here"
                        id="literature"></textarea>
                      </div>
                      <div>
                        <input type="button" value="Agregar"
                        @click="example_append('literature')" />
                      </div>
                    
                  </div>
                </div>
                <hr>
                <p class="mb-4" style="font-weight: bold; text-align: center;" > Food </p>
                <div class="row">
                  <div class="col-sm-8">
                    <div class="card bg-light mb-3">
                      <div class="card-header" style="text-align: center;">Comida registrada</div>
                      <ol>
                        <div v-for="index in foodSelect">
                          <li>{{ index }}</li>
                        </div>
                      </ol>
                    </div>
                  </div>
                  <div class="col">
                    
                      <div>
                        <textarea class="example-default-value" placeholder="Type here"
                        id="food"></textarea>
                      </div>
                      <div>
                        <input type="button" value="Agregar"
                        @click="example_append('food')" />
                      </div>
                    
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <div style="display: flex; justify-content: center;" >
    <Button variant="primary" class="mt-3 mw-25"><a href="/user/data" style="color: white; text-decoration: none !important;">Edit <i class="bi bi-pencil-square"></i></a> </Button>
  </div>
</section>
</template>
<script>

import InputItem from '../../../atoms/InputItem/InputItem.vue'
import Button from '../../../atoms/Button/Button.vue'
import PItem from '../../../atoms/PItem/PItem.vue'
import ErrorData from '../../../atoms/ErrorData/ErrorData.vue'
import {mapGetters } from 'vuex'
import { ref } from 'vue';
import axios from 'axios'

export default {
    name: 'User',
    
    components: {
        Button,
        PItem,
        InputItem,
        ErrorData
    },
    setup(){
      const stetes = ref(["Matrimonio","Solteria","Union Libre"]);
      const sport = ref(["Baloncesto", "Tenis", "Futbol", "Beisbol","Golf","Voleibol","Cicismo","Rugby","Natacion", "GYM"])
      const TF = ref([true,false]);
      const estadoMarital = ref('');
      const employeeStatus = ref('');
      const sportSelect = ref([]);
      const literatureSelect = ref([]);
      const foodSelect = ref([]);
      return {
        stetes,
        estadoMarital,
        TF,
        employeeStatus,
        sport,
        sportSelect,
        literatureSelect,
        foodSelect
        
      };
    },
    computed:{
        ...mapGetters(['user'])
    },
    methods:{
      example_append(args) {
          if(args === 'literature'){
            let textInput = document.getElementById('literature');

            if(textInput.value !== ""){
                this.literatureSelect.push(textInput.value);
                textInput.value="";
              }
          }
          if(args ==='food'){
            let textInput = document.getElementById('food');

            if(textInput.value !== ""){
                this.foodSelect.push(textInput.value);
                textInput.value="";
              }
          }
          
        },
      handleName(){
        
        let element = document.getElementById('NameSpan');
        document.getElementById('buttonIdNameIcon').className =`bi bi-check-square`;
        document.getElementById("buttonIdName").onclick=this.handleSummitName;
        if(element != null)
          element.outerHTML = `<input id='NameInput' value='${this.user.Name}' />`;
        
        },
      async handleSummitName(){
        let txt = document.getElementById('NameInput').value;
        if(txt && this.user.Name != txt){
            axios.put("Client/Update",{
              Email: this.user.Email,
              Name: txt
            }).then((response)=>{
              if(response.status == 200){
                alert("save");
                location.reload();
              }
            }).catch(e => {
              alert(e.response);
            } )
          }else{
            location.reload();
          }
        }
    }
};
</script>
<style></style>