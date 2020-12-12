<template>
    <b-table striped hover :items="$store.state.allPets" :fields="fields" class="bg-dark text-light">
        <template #cell(updatePet)>
        <b-button size="sm" class="mr-2 bg-success">1
          <router-link :to="{ name : 'updatePet' }">Update</router-link>
        </b-button>
        </template>
    </b-table>

</template>

<script>
// import UpdatePetForm from '../components/UpdatePetForm.vue'
import PetsService from '../services/PetsService'

export default {
  // components: { UpdatePetForm },
    data () {
       return {
            fields : [ 
                {
                    key: 'arrivalDate',
                    sortable: true
                }, 
                {
                    key: 'name',
                    sortable: true
                },
                {
                    key: 'age',
                    sortable: true
                }, 
                {
                    key: 'isAdopted',
                    label: 'Has a Home',
                    sortable: true
                }, 
                {   key: 'updatePet',
                    label: 'Update Pet',
                    sortable:false
                }
                ]
       }
    },
    created() {
        PetsService.getAllPets().then(response => {
            this.$store.commit("UPDATE_PET_ROSTER", response.data)
        })//.catch(error => {});
    }
}
</script>

<style>

</style>