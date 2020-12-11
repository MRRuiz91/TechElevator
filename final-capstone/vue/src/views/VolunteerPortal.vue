<template>
 <div class="volunteerPortal">
     <h1></h1>
  <div class="adminView" v-if="$store.state.user.role === 'admin'">
     <h1>admin see dis</h1>
 </div>   
 <div> 
     <b-button v-b-toggle.collapse-1 variant="warning">Add Pet</b-button>
     <b-button v-b-toggle.collapse-2 variant="warning">Update Pet</b-button>
     <b-collapse id="collapse-1" v-model="$store.state.showAddPetForm">
        <b-card>
            <add-pet-form />
        </b-card>
    </b-collapse> 
    <b-collapse id="collapse-2" v-model="$store.state.showUpdatePetForm">
        <b-card>
            <h1>hi</h1>
        </b-card>
    </b-collapse> 
 </div>
 <div class="volunteerDirectory">
        <b-card>
            <h1>volunteer Directory</h1>
        </b-card>
 </div>
</div>
</template>
<script>
import AddPetForm from '../components/AddPetForm.vue';

export default {
    components: { AddPetForm },
    data() {
        return {
        }
    }
}
</script>
<style>
</style>