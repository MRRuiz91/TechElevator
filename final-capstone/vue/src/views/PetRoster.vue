<template>
    <b-table
        striped hover selectable 
        :dark='true'
        sticky-header
        :items="$store.state.allPets" 
        :fields="fields" 
        @row-selected="onRowSelected" 
        responsive="sm" 
        :select-mode="selectMode" 
        selected-variant="success"
    >
    </b-table>
</template>

<script>

import PetsService from '../services/PetsService'
export default {
    data () {
        return {
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
            selectMode: 'single',
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