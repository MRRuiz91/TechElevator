<template>
    <b-table class="bg-dark text-white" variant="text-white"
        striped hover selectable :select-mode='single' 
        :items="$store.state.allPets" :fields="fields" 
        @row-selected="onRowSelected" responsive="sm"
    >

        <template #cell(updatePet)></template>
    </b-table>
</template>

<script>
// import UpdatePetForm from '../components/UpdatePetForm.vue'
import PetsService from '../services/PetsService'
export default {
    //components: { UpdatePetForm },
    data () {
        return {
            modes: ['single'],
            fields: [ 
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
                }
            ],
            selected: []
        }
    },
    created() {
        PetsService.getAllPets().then(response => {
            this.$store.commit("UPDATE_PET_ROSTER", response.data)
        })//.catch(error => {});
    },
    methods: {
        onRowSelected (items) {
            this.selected = items;
            this.$store.commit('SELECT_PET', this.selected)
        }
    }
}
</script>

<style>
</style>