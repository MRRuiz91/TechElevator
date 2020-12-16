<template>
    <b-table
        striped hover :dark="true"
        :items="volunteerList" :fields="fields" 
         responsive="sm" selected-variant="success"
    >
    </b-table>
</template>

<script>
import VolunteerService from '../services/VolunteerService'
export default {
    data() {
        return {
            fields : [ 'userId', 'firstName', 'lastName', 'username', 'role', 'email', 'phone'],
            volunteerList : []
        }
    },
    created() {
        VolunteerService.getVolunteerList().then(response => {
            this.volunteerList = response.data;
        })
    }
}
</script>

<style>

</style>