<template>
    <b-table
        striped hover selectable :dark='true' b-table-select-single 
        :items="$store.state.volunteers" :fields="fields" 
        @row-selected="onRowSelected" responsive="sm" selected-variant="success"
    >
    </b-table>
</template>

<script>
export default {
    data() {
        return {
            fields : [ 'User Id', 'Username', 'Role', 'Email', 'Phone Number']
        }
    },
    created() {
        
    }
}
</script>

<style>

</style>