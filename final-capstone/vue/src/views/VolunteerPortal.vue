<template>
 <div class="volunteerPortal">
     <h1></h1>
  <div class="adminView" v-if="$store.state.user.role === 'admin'">
     <h1>admin see dis</h1>
 </div>   
 <div>
     <div class="volunteerDirectory">
        <b-card>
            <h1>volunteer Directory</h1>
        </b-card>
     </div>
     <b-button v-b-toggle.collapse-1 variant="warning">Add Pet</b-button>
     <b-collapse id="collapse-1">
        <b-card>
            <add-pet-form />
        </b-card>
    </b-collapse> 
 <b-button><b-link to="update-pet"> 
          <img src="..\assets\pawPrint.png" class="img" height="50 px"/>
          Update Pet</b-link></b-button>
 
 </div>
</div>
</template>
<script>
import AddPetForm from '../components/AddPetForm.vue';

export default {
    components: { AddPetForm },
}
</script>
<style>
</style>

<b-link to="add-pet"> 
          <img src="..\assets\pawPrint.png" class="img" height="50 px"/></b-link>