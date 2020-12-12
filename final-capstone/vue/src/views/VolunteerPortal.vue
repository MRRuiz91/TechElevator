<template>
 <div class="volunteerPortal">
     <div class="text-center text-white">
        <h1>Completing Families One Furry Friend at a Time</h1>
    </div>   
 
 <div class="row">
 <div class="col-sm-1">
 </div>
 <div class="col-sm-4"> 
        <b-card class="bg-secondary text-white">
            <b-tabs justified class=" bg-success text-white">
                <b-tab title="Pet Roster" active>
                    <pet-roster />
                </b-tab>
                <b-tab title="Add a New Pet">
                    <add-pet-form />
                </b-tab>
                <b-tab title="Update Selected Pet" v-bind:disabled=petSelected>
                    <update-pet-form />
                </b-tab>
            </b-tabs>
        </b-card>
 </div>
 <div class="col-sm-2">
 </div>
 <div class="volunteerDirectory col-sm-4">
        <b-card >
            <h1>volunteer Directory</h1>
            <div class="adminView" v-if="$store.state.user.role === 'admin'">
            <h1>admin see dis</h1>
            </div>
        </b-card>
 </div>
 <div class="col-sm-1">
 </div>
 </div>
</div>
</template>
<script>
import AddPetForm from '../components/AddPetForm.vue';
import UpdatePetForm from '../components/UpdatePetForm.vue';
import PetRoster from '../views/PetRoster.vue';

export default {
    components: { AddPetForm, PetRoster, UpdatePetForm },
    data() {
        return {
        }
    },
    computed: {
        petSelected() {
            return this.$store.state.selectedPet == null;
        }
    }
}
</script>
<style>
</style>