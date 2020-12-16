<template>
    <div class="volunteerPortal">
        <div class="text-center text-white mt-5">
            <h1>Completing Families One Furry Friend at a Time</h1>
        </div>   
 
        <div class="row m-5">
            <div class="col-sm tabs "> 
                <b-card id="outerCard" class=" border text-white">
                    <b-tabs justified class="bg-dark border-dark text-white" card>
                        <b-tab title="New Pet" lazy>
                            <add-pet-form />
                        </b-tab>
                        <b-tab title="Pet Roster" active >
                            <pet-roster />
                        </b-tab>
                        <b-tab title="Update Pet" lazy v-bind:disabled=petSelected>
                            <update-pet-form />
                        </b-tab>
                    </b-tabs>
                </b-card>
            </div>

            <div class="col-sm-0.5"></div>

            <div class="volunteerDirectory col-sm ">
                <b-card id="outerCard" class="bg-dark border text-white" >
                    <b-tabs justified class="bg-dark border-dark text-white" card>
                        <b-tab title="Volunteer Directory" active lazy>
                            <volunteer-directory />
                        </b-tab>
                        <b-tab v-if="$store.state.user.role === 'admin'" title="Review Pending Applications" lazy>
                            <approve-deny-application />
                        </b-tab>
                    </b-tabs>
                </b-card>
            </div>
        </div>
    </div>
</template>

<script>
import AddPetForm from '../components/AddPetForm.vue';
import ApproveDenyApplication from '../components/ApproveDenyApplication.vue';
import UpdatePetForm from '../components/UpdatePetForm.vue';
import VolunteerDirectory from '../components/VolunteerDirectory.vue';
import PetRoster from '../views/PetRoster.vue';
export default {
    components: { AddPetForm, PetRoster, UpdatePetForm, ApproveDenyApplication, VolunteerDirectory},
    data() {
        return {
             
        }
    },
    computed: {
        petSelected() {
            return this.$store.state.selectedPet == null;
        }
    },
    methods: {
    }
}
</script>

<style scoped>
    #outerCard {
  background-color: black !important;
}
</style>